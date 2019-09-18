using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip_Movement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Vector3 moveVector;
    public float moveSpeed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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

        rigidbody.velocity = moveVector;
    }
}
