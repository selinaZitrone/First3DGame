using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WinLosePanel_Script : MonoBehaviour
{
    [SerializeField] GameObject panel = null;
    [SerializeField] TextMeshProUGUI textLabel = null;
    [SerializeField] Color wonColor = Color.green;
    [SerializeField] Color lostColor = Color.red;
    public bool gameLost;
    public bool gameWon;

    private void Start()
    {
        gameLost = false;
        gameWon = false;
        panel.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.StartListening("death", PlayerLost);
        EventManager.StartListening("won", PlayerWon);
    }

    private void OnDisable()
    {
        EventManager.StopListening("death", PlayerLost);
        EventManager.StopListening("won", PlayerWon);
    }

    private void PlayerLost()
    {
        gameLost = true;
        ChangeTheLabel("you lose!!!");
        LoserGraphic();
        panel.SetActive(true);
    }

    private void PlayerWon()
    {
        ChangeTheLabel("you won!");
        WinnerGraphic();
        panel.SetActive(true);
        gameWon = true;
        
    }

    public void ChangeTheLabel(string newText)
    {
        textLabel.text = newText;
    }

    public void WinnerGraphic()
    {
        panel.GetComponent<Image>().color = wonColor;
    }

    public void LoserGraphic()
    {
        panel.GetComponent<Image>().color = lostColor;
    }

    public void RestartGame()
    {
        Debug.Log("Button clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
