using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent( typeof(Image) )]
public class WinLosePanel_Script : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textLabel;
    [SerializeField] Color wonColor;
    [SerializeField] Color lostColor;

    public void ChangeTheLabel(string newText) {
        textLabel.text = newText;
    }

    public void WinnerGraphic() {
        GetComponent<Image>().color = wonColor;
    }

    public void LoserGraphic()
    {
        GetComponent<Image>().color = lostColor;
    }
}
