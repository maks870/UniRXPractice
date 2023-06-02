using UniRx;
using UnityEngine;

public interface IDestroyable
{
    public ReactiveCommand DestroyCommand { get; }
}
