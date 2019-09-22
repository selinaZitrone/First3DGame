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
                
    }
}
