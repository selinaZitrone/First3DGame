using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip_Movement : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public Vector3 moveVector;
    public float moveSpeed = 1;
    public float upForce = 1;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;
       
        if (Input.GetKey(KeyCode.W))
        {
            moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.A)){
            moveVector -= transform.right;
        }

        if (Input.GetKey(KeyCode.D)){
            moveVector += transform.right;
        }

        moveVector.Normalize();

        moveVector = moveVector * moveSpeed;

        moveVector.y = _rigidbody.velocity.y;
        _rigidbody.velocity = moveVector;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * upForce);
        }
    }
}
