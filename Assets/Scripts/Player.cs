using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UIPlayer playerUI;
    [SerializeField] private CoinSpawner spawner;

    private CompositeDisposable disposable = new CompositeDisposable();

    public ReactiveProperty<int> coinCount = new IntReactiveProperty();


    private void OnDisable()
    {
        disposable.Clear();
    }

    void Start()
    {
        coinCount.Subscribe((value) => playerUI.UpdateCoinText(value)).AddTo(disposable);
        coinCount.Value = 0;
        playerUI.SpawnButton.OnClickAsObservable().Subscribe((unit) => spawner.ClickSpawner.Use()).AddTo(disposable);
        spawner.newCoin.Subscribe((coin) => CollectOnDestroy(coin)).AddTo(disposable);
    }

    private void CollectOnDestroy(Coin coin)
    {
        if (coin != null)
            coin.DestroyCommand.Subscribe((unit) => coinCount.Value++).AddTo(coin.disposable);
    }
}
