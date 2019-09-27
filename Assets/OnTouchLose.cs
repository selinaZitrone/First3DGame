using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class OnTouchLose : MonoBehaviour
{
    [SerializeField] GameObject lostPanel;
    public bool gameLost;
    private void Start()
    {
        lostPanel.SetActive(false);
        gameLost = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameLost)
        {
            RestartGame();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.GetComponent<SpaceShip_Movement>())
        {
            Debug.Log("you lose!!");
            PlayerLost();
                            
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void PlayerLost()
    {
        gameLost = true;
        lostPanel.SetActive(true);
    }
}
