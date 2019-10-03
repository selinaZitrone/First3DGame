using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationVelocity;
    public bool invertedView;

   private void Update()
    {
        RotateOnX();
    }

    private void RotateOnX()
    {
        float viewRotationY = Input.GetAxis("Mouse Y");
        if (invertedView) viewRotationY *= -1;
        transform.Rotate(new Vector3(-viewRotationY*rotationVelocity, 0f, 0f));
    }

    

}
