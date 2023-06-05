using System.Collections;
using UniRx;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private CompositeDisposable disposable = new CompositeDisposable();

    [SerializeField] private CoinSpawner spawner;
    [SerializeField] private Player player;
    [SerializeField] private UIShop shopUI;

    private void OnDisable()
    {
        disposable.Clear();
    }

    private void Start()
    {
        shopUI.tickSpawnerIncreaseCount.OnClickAsObservable().Subscribe((value) => spawner.TickSpawner.IncreaseCount()).AddTo(disposable);
        spawner.TickSpawner.increaseCommand.Subscribe((value) => { shopUI.tickSpawnCount.text = value.ToString(); }).AddTo(disposable);

        shopUI.tickSpawnerUpgrade.OnClickAsObservable().Subscribe((value) => spawner.TickSpawner.Upgrade()).AddTo(disposable);
        spawner.TickSpawner.upgradeCommand.Subscribe((unit) => { Debug.Log(unit.ToString()); Debug.Log(unit.GetType()); }).AddTo(disposable);


    }

}
