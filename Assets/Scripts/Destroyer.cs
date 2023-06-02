using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Collider col;
    private CompositeDisposable disposable = new CompositeDisposable();

    void Start()
    {
        col = GetComponent<Collider>();
        col.OnTriggerEnterAsObservable()
            .Where((other) => other.GetComponent<IDestroyable>() != null)
            .Subscribe((other) => other.GetComponent<IDestroyable>().DestroyCommand.Execute())
            .AddTo(disposable);
    }
}
