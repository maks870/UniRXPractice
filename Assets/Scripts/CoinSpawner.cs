using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    public ReactiveProperty<int> coinCount;
    public ReactiveProperty<Coin> newCoin = new ReactiveProperty<Coin>();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnCoins(int count)
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
