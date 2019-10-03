using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnTouchLose : MonoBehaviour
{
    WinLosePanel_Script lostPanel;
    public bool gameLost;

    private void Awake()
    {
        lostPanel = FindObjectOfType<WinLosePanel_Script>();
        Debug.Log(lostPanel);
    }
    private void Start()
    {
        gameLost = false;
        lostPanel.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.GetComponent<SpaceShip_Movement>())
        {
            WeLost();

        }
    }

    public void RestartGame()
    {
        Debug.Log("Button clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void WeLost()
    {
        gameLost = true;
        lostPanel.ChangeTheLabel("you lose!!!");
        lostPanel.LoserGraphic();
        lostPanel.gameObject.SetActive(true);
    }
}
