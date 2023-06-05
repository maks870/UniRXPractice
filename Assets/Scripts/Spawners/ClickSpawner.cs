using System;

public class ClickSpawner : MethodSpawner
{
    public ClickSpawner(int spawnCount, Action<int> spawnAction) : base(spawnCount, spawnAction)
    {
    }
}
