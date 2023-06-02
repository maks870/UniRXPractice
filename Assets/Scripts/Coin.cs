using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Coin : MonoBehaviour, IDestroyable
{
    [SerializeField] private float fallForce = 1;
    [SerializeField] private Rigidbody rb;

    public CompositeDisposable disposable = new CompositeDisposable();
    private ReactiveCommand destroyCommand = new ReactiveCommand();

    public ReactiveCommand DestroyCommand => destroyCommand;

    private void OnDisable()
    {
        disposable.Clear();
    }

    private void Start()
    {
        destroyCommand.Subscribe((value) => Destroy(gameObject)).AddTo(disposable);
    }

    private void FixedUpdate()
    {
        Fall();
    }

    private void Fall()
    {
        rb.AddForce(-Vector3.up * fallForce, ForceMode.Acceleration);
    }
}
