using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler gameHandler;
    public GameObject enemy, buttonsPanel;
    public int P1Health = 5;
    public int P2Health = 5;
    public Image player1Health;
    public Image player2Health;
    public GameObject P1Wins;
    public GameObject P2Wins;
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameHandler == null)
        {
            gameHandler = this;
        }
        else
        {
            Destroy(this);
            Debug.LogWarning("Second GameHandler");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPlayer1Health()
    {
        player1Health.fillAmount -= 0.2f;
    }
    public void SetPlayer2Health()
    {
        player2Health.fillAmount -= 0.2f;
    }
    public void Buttons()
    {
        buttonsPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void RetryButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1); // exits the game
    }
    public void ExitTheGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit(); //quits game within Unity as well
    }
}
