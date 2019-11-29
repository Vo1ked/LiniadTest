using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnImpulse : MonoBehaviour
{
    [SerializeField] TriggerEvent _leftTrigger;
    [SerializeField] TriggerEvent _rightTrigger;
    [SerializeField] Transform _leftDirection;
    [SerializeField] Transform _rightDirection;
    [SerializeField]Vector3 _pushDirection;
    // Start is called before the first frame update
    void Start()
    {
        _leftTrigger.Triggered += SetLeftDirection;
        _rightTrigger.Triggered += SetRightDirection;
    }

    void SetLeftDirection(Collider coll)
    {
        _pushDirection = _rightDirection.transform.position - transform.position;
        _pushDirection.Normalize();
    }

    void SetRightDirection(Collider coll)
    {
        _pushDirection = _leftDirection.transform.position - transform.position;
        _pushDirection.Normalize();
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(_pushDirection * 15, ForceMode.Impulse);
    }
}
