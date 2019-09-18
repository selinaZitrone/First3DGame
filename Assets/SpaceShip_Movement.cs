using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip_Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 moveVector;
    [SerializeField]
    private float moveSpeed = 1;
    public float upForce = 100;
    [SerializeField]
    private float rotateSpeed = 1;

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
        this._rigidbody.velocity = moveVector;



    }

    private void FixedUpdate()
    {
        // https://www.youtube.com/watch?v=hG9SzQxaCm8
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * upForce);
        }

        float viewRotation = Input.GetAxis("Mouse X");
        Vector3 angularVelocity = this._rigidbody.angularVelocity;
        angularVelocity.y = viewRotation * 20;
        this._rigidbody.angularVelocity = angularVelocity;
    }
}
