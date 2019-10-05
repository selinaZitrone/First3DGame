using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu_Script : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI exampleLabel = null;

    private void Start()
    {
        exampleLabel.text = "is not working";
    }

    public void ChangeTheExample(string newExample)
    {
        SceneManager.LoadScene("SelinaScene");
    }
}
