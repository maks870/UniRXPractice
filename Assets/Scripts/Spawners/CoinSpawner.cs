using UniRx;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Click Spawner Settings")]
    [SerializeField] private int clickCount = 1;

    [Space(5)]
    [Header("TickSpawner Settings")]
    [SerializeField] private int tickCount = 0;
    [SerializeField] private float tickTime = 5;

    [SerializeField] private GameObject coinPrefab;

    [HideInInspector] public ReactiveProperty<int> coinCount;
    [HideInInspector] public ReactiveProperty<Coin> newCoin = new ReactiveProperty<Coin>();

    private MethodSpawner clickSpawner;
    private MethodSpawner tickSpawner;

    public MethodSpawner ClickSpawner => clickSpawner;
    public MethodSpawner TickSpawner => tickSpawner;

    void Awake()
    {
        clickSpawner = new ClickSpawner(clickCount, SpawnCoins);
        tickSpawner = new TikSpawner(tickCount, tickTime, SpawnCoins);
        tickSpawner.Use();
    }


    private void SpawnCoins(int count)
    {
        float xRand;
        float yRand;
        float zRand;

        for (; count > 0; count--)
        {
            Vector3 spawnPosition = transform.position;
            xRand = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            yRand = Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2);
            zRand = Random.Range(-transform.localScale.z / 2, transform.localScale.z / 2);

            spawnPosition += new Vector3(xRand, yRand, zRand);

            newCoin.Value = Instantiate(coinPrefab, spawnPosition, Quaternion.identity).GetComponent<Coin>();
        }
    }
}
