using System;
using UniRx;

public abstract class MethodSpawner
{
    protected int spawnCount;
    protected ReactiveCommand<int> spawnCommand = new ReactiveCommand<int>();
    public ReactiveCommand upgradeCommand = new ReactiveCommand();
    public ReactiveCommand<int> increaseCommand = new ReactiveCommand<int>();

    public MethodSpawner(int spawnCount, Action<int> spawnAction)
    {
        this.spawnCount = spawnCount;
        spawnCommand.Subscribe((value) => spawnAction(value));
    }

    public virtual void Use()
    {
        spawnCommand.Execute(spawnCount);
    }

    public virtual void Upgrade()
    {
        upgradeCommand.Execute();
    }

    public virtual void IncreaseCount()
    {
        spawnCount++;
        increaseCommand.Execute(spawnCount);
    }
}
