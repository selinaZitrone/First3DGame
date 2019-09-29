using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpaceShip_Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 moveVector;
    [SerializeField]
    private float moveSpeed = 1;
    public float upForce = 100;
    [SerializeField]
    private float rotateSpeed = 1;

    public delegate void HasJumped();
    public static event HasJumped hasJumped;
    public static event HasJumped hasStoppedJumping;

    public UnityEvent furz;
    OnTouchLose onTouchLose;
    OnTouchWin onTouchWin;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        onTouchLose = FindObjectOfType<OnTouchLose>();
        onTouchWin = FindObjectOfType<OnTouchWin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onTouchLose != null)
        {
            if (onTouchLose.gameLost | onTouchWin.gameWon)
                return;
        }
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

        if (Input.GetKey(KeyCode.F))
        {
            furz.Invoke();
        }

        // https://www.youtube.com/watch?v=hG9SzQxaCm8
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            _rigidbody.AddForce(Vector3.up * upForce);
            canJump = false;
            jumpTimer = jumpDelay;

            if(hasJumped != null)
            {
                hasJumped();
            }

        }

        moveVector.Normalize();

        moveVector = moveVector * moveSpeed;

        moveVector.y = _rigidbody.velocity.y;
        this._rigidbody.velocity = moveVector;
    }

    private void FixedUpdate()
    {
       if (jumpTimer >= 0)
        {
            jumpTimer -= Time.fixedDeltaTime;
        }

        rotateViewX();
        
    }


    private void rotateViewX()
    {
        float viewRotationX = Input.GetAxis("Mouse X");
        Vector3 angularVelocity = this._rigidbody.angularVelocity;
        angularVelocity.y = viewRotationX * 20;
        this._rigidbody.angularVelocity = angularVelocity;
    }

    bool canJump;
    private float jumpTimer;
    [SerializeField] private float jumpDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<JumpbarePlatfom>())
        {
            if (jumpTimer < 0) canJump = true;
            if (hasStoppedJumping != null)
            {
                hasStoppedJumping();
            }

            other.GetComponent<JumpbarePlatfom>().switchColor(1);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<JumpbarePlatfom>())
        {
            if (jumpTimer < 0) canJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<JumpbarePlatfom>())
        {
            other.GetComponent<JumpbarePlatfom>().switchColor(0);

        }
    }

}
