using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] TriggerEvent fillTrigger;
    [SerializeField] TriggerEvent pushDownTrigger;
    // Start is called before the first frame update
    void Start()
    {
        fillTrigger.Triggered += Filled;
        pushDownTrigger.Triggered += Push;
        GameController.Instance.AddHole();
    }

    private void Filled(Collider coll)
    {
        coll.GetComponent<IHoled>().Holed();
        fillTrigger.Triggered -= Filled;
    }

    private void Push(Collider coll)
    {
        var rb = coll.GetComponent<Rigidbody>();
        rb.velocity = rb.velocity *0.2f;
        rb.angularVelocity = rb.angularVelocity *0.2f;
        rb.AddForce(Vector3.down * 20, ForceMode.Impulse);
        pushDownTrigger.Triggered -= Push;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
