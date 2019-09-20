using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpbarePlatfom : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    public void switchColor(int colorIndex)
    {
        if (colors.Length > 0)
        {
            GetComponent<MeshRenderer>().material.color = colors[colorIndex];
        }
    }
}
