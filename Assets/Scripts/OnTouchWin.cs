using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTouchWin : MonoBehaviour
{
    WinLosePanel_Script lostPanel;
    public bool gameWon;

    private void Awake()
    {
        lostPanel = FindObjectOfType<WinLosePanel_Script>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //winPanel.SetActive(false);
        gameWon = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.GetComponent<SpaceShip_Movement>())
        {
            PlayerWon();
        }
    }

    private void PlayerWon()
    {
        lostPanel.ChangeTheLabel("you won!");
        lostPanel.WinnerGraphic();
        lostPanel.gameObject.SetActive(true);
        gameWon = true;
    }

}
