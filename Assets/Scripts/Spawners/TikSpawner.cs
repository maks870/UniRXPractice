using System;
using UniRx;
using UnityEngine;

public class TikSpawner : MethodSpawner
{
    private float tikTime;
    private float time = 0;
    public new ReactiveCommand<float> upgradeCommand = new ReactiveCommand<float>();


    public TikSpawner(int spawnCount, float tikTime, Action<int> spawnAction) : base(spawnCount, spawnAction)
    {
        this.tikTime = tikTime;
    }

    private void SpawnPerSeconds()
    {
        time += Time.deltaTime;

        if (time >= tikTime)
        {
            time = 0;
            base.Use();
        }
    }

    public override void Use()
    {
        Observable.EveryUpdate().Subscribe((value) => SpawnPerSeconds());
    }

    public override void Upgrade()
    {
        tikTime /= 2;
        upgradeCommand.Execute(tikTime);
    }
}
