using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpbarePlatfom : MonoBehaviour
{
    [SerializeField] private Color[] colors = null;
    [SerializeField] private Color[] colors_2 = null;
    public void switchColor(int colorIndex)
    {
        if (colors.Length > 0)
        {
            GetComponent<MeshRenderer>().materials[0].color = colors[colorIndex];
        }
        if (colors_2.Length > 0)
        {
            GetComponent<MeshRenderer>().materials[1].color = colors_2[colorIndex];
        }
    }
}
