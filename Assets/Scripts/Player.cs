using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UIPlayer playerUI;
    [SerializeField] private CoinSpawner spawner;

    private CompositeDisposable disposable = new CompositeDisposable();

    public ReactiveProperty<int> currentSpawnCount = new IntReactiveProperty(1);
    public ReactiveProperty<int> coinCount = new IntReactiveProperty();


    private void OnDisable()
    {
        disposable.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        coinCount.Subscribe((value) => playerUI.UpdateCoinText(value)).AddTo(disposable);
        coinCount.Value = 0;
        playerUI.SpawnButton.OnClickAsObservable().Subscribe((unit) => spawner.SpawnCoins(currentSpawnCount.Value)).AddTo(disposable);
        spawner.newCoin.Subscribe((coin) => CollectOnDestroy(coin)).AddTo(disposable);
        spawner.newCoin.
    }

    private void CollectOnDestroy(Coin coin)
    {
        if (coin != null)
            coin.DestroyCommand.Subscribe((unit) => coinCount.Value++).AddTo(coin.disposable);
    }
}
