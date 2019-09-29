using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTouchWin : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    public bool gameWon;

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
        gameWon = false;
    }

    private void Update()
    {
        PlayAgain();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.GetComponent<SpaceShip_Movement>())
        {
            Debug.Log("you win!");
            PlayerWon();
        }
    }

    private void PlayerWon()
    {
        winPanel.SetActive(true);
        gameWon = true;
    }
    private void PlayAgain()
    {
        if(Input.GetKeyDown(KeyCode.Space) && gameWon)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
