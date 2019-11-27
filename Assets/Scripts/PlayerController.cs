using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();   
    }

    private void Start()
    {
        GameController.Instance.swipeManager.Swiped += Move;
    }

    private void Move(SwipeManager.Swipe swipe)
    {
        Vector3 direction = Vector2.zero;
        float power = 10;
        switch (swipe)
        {
            case SwipeManager.Swipe.None:
                break;
            case SwipeManager.Swipe.Up:
                direction = Vector3.forward;
                break;
            case SwipeManager.Swipe.Down:
                direction = Vector3.back;
                break;
            case SwipeManager.Swipe.Left:
                direction = Vector3.left;
                break;
            case SwipeManager.Swipe.Right:
                direction = Vector3.right;
                break;
        }
        _rigidbody.AddForce(direction * power, ForceMode.Impulse);
    }

    private void OnDestroy()
    {
        GameController.Instance.swipeManager.Swiped -= Move;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            collision.gameObject.tag = "Untagged";
        }
    }
}
