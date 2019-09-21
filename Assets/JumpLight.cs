using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLight : MonoBehaviour
{

    private void OnEnable()
    {
        SpaceShip_Movement.hasJumped += IHeardSomeoneJump;
    }

    private void OnDisable()
    {
        SpaceShip_Movement.hasJumped -= IHeardSomeoneJump;
    }

    private void IHeardSomeoneJump()
    {
        Debug.Log("someone jumped!");
    }
}
