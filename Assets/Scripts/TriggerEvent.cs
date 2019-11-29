using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public System.Action<Collider> Triggered;

    private void OnTriggerEnter(Collider other)
    {
        Triggered?.Invoke(other);
    }
}
