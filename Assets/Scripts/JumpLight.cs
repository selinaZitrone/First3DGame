using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLight : MonoBehaviour
{
    [SerializeField] private Color[] jumpLightColors = { Color.green, Color.red };
    private void OnEnable()
    {
        SpaceShip_Movement.hasJumped += IHeardSomeoneJump;
        SpaceShip_Movement.hasStoppedJumping += IHeardSomeoneStopJumping;
    }

   

    private void OnDisable()
    {
        SpaceShip_Movement.hasJumped -= IHeardSomeoneJump;
        SpaceShip_Movement.hasStoppedJumping -= IHeardSomeoneStopJumping;
    }

    private void IHeardSomeoneJump()
    {
        if (jumpLightColors.Length >= 2)
        {
            GetComponent<MeshRenderer>().material.color = jumpLightColors[0];
        }
        
    }
    private void IHeardSomeoneStopJumping()
    {
        if (jumpLightColors.Length >= 2)
        {
            GetComponent<MeshRenderer>().material.color = jumpLightColors[1];
        }
    }
}
