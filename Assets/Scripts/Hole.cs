using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] TriggerEvent trigger;
    // Start is called before the first frame update
    void Start()
    {
        trigger.Triggered += Filled;
        GameController.Instance.AddHole();
    }

    private void Filled()
    {
        GameController.Instance.RemoveHole();
        trigger.Triggered -= Filled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
