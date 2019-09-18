using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alessio_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("burst"))
        {
            print("your are bursting");
            gameObject.transform.Translate(new Vector3(0f, 0f, 1f));
        }
    }
}
