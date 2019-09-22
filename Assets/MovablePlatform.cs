using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    [SerializeField]private Transform startPosition;
    [SerializeField] private Transform endPosition;
    private bool moveTowardsStart;
    [SerializeField] private float velocity;
    private float journeyLength;
    private float startTime;
    private Vector3 oldPosition;
    private Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        moveTowardsStart = false;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition.position, endPosition.position);
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform();

    }

    private void movePlatform()
    {
        Vector3 startpos, endpos;
        if (!moveTowardsStart)
        {
            startpos = startPosition.position;
            endpos = endPosition.position;
        } else
        {
            startpos = endPosition.position;
            endpos = startPosition.position;
        }

        float distCovered = (Time.time - startTime) * velocity;
        float fractionOfJourney = distCovered / journeyLength;
        if (transform.position == startPosition.position)
        {
            moveTowardsStart = false;
            startTime = Time.time;
        }
        if(transform.position == endPosition.position)
        {
            moveTowardsStart = true;
            startTime = Time.time;

        }
        transform.position = Vector3.Lerp(startpos, endpos, fractionOfJourney);

        oldPosition = newPosition;
        newPosition = transform.position;

        if (player != null && playerTouching)
        {
            player.transform.position += newPosition - oldPosition;
            playerTouching = false;
        }
    }

    GameObject player;
    bool playerTouching = false;

    private void OnCollisionStay(Collision collision)
    {

        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<SpaceShip_Movement>()) {
            player = collision.gameObject;
            playerTouching = true;
        }
    }
}
