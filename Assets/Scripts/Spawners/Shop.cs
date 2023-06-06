using TMPro;
using UniRx;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Prices")]
    [SerializeField] private int increaseCost = 10;
    [SerializeField] private int increaseRise = 10;
    [SerializeField] private int upgradeCost = 10;
    [SerializeField] private int upgradeRise = 10;

    [Space(5)]
    [Header("Dependencies")]
    [SerializeField] private CoinSpawner spawner;
    [SerializeField] private Player player;
    [SerializeField] private UIShop shopUI;

    private CompositeDisposable disposable = new CompositeDisposable();

    private void OnDisable()
    {
        disposable.Clear();
    }

    private void Start()
    {
        shopUI.tickSpawnerIncreaseCount.OnClickAsObservable().Subscribe((value) => BuyTickIncrease()).AddTo(disposable);
        spawner.TickSpawner.increaseCommand.Subscribe((value) => { shopUI.tickSpawnCountTxt.text = value.ToString(); }).AddTo(disposable);
        shopUI.tickSpawnerIncreaseCount.GetComponentInChildren<TextMeshProUGUI>().text = increaseCost.ToString();


        shopUI.tickSpawnerUpgrade.OnClickAsObservable().Subscribe((value) => BuyTickUpgrade()).AddTo(disposable);
        TikSpawner tikSpawner = (TikSpawner)spawner.TickSpawner;
        tikSpawner.upgradeCommand.Subscribe((value) => { shopUI.tickTimeTxt.text = value.ToString(); }).AddTo(disposable);
        shopUI.tickSpawnerUpgrade.GetComponentInChildren<TextMeshProUGUI>().text = upgradeCost.ToString();
    }

    private bool SpendCoin(int spendCount)
    {
        int coin = player.coinCount.Value;

        if (coin - spendCount <= 0)
        {
            StopAllCoroutines();
            StartCoroutine(shopUI.NotifyLackCoin());

            return false;
        }

        player.coinCount.Value -= spendCount;
        return true;
    }

    private void BuyTickIncrease()
    {
        if (!SpendCoin(increaseCost))
            return;

        spawner.TickSpawner.IncreaseCount();
        increaseCost += increaseRise;
        shopUI.tickSpawnerIncreaseCount.GetComponentInChildren<TextMeshProUGUI>().text = increaseCost.ToString();
    }

    private void BuyTickUpgrade()
    {
        if (!SpendCoin(upgradeCost))
            return;

        spawner.TickSpawner.Upgrade();
        upgradeCost += upgradeRise;
        shopUI.tickSpawnerUpgrade.GetComponentInChildren<TextMeshProUGUI>().text = upgradeCost.ToString();
    }
}
