using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public System.Action Triggered;

    private void OnTriggerEnter(Collider other)
    {
        Triggered?.Invoke();
    }
}
