using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler gameHandler;
    public GameObject enemy, buttonsPanel;
    public int bulletLimit1 = 0;
    public int bulletLimit2 = 0;
    public int P1Health = 5;
    public int P2Health = 5;
    public Image player1Health;
    public Image player2Health;
    public GameObject P1Wins;
    public GameObject P2Wins;

    public GameObject playersToSpawn;
    public float timeLeft = 3.0f;
    [SerializeField] Text startText; // used for showing countdown from 3, 2, 1 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
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
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            playersToSpawn.gameObject.SetActive(true);
            Time.timeScale = 1;
            startText.gameObject.SetActive(false);
        }
    }
    public void AddBulletLimit1()
    {
        bulletLimit1++;
    }
    public void AddBulletLimit2()
    {
        bulletLimit2++;
    }
    public void MinusBulletLimit1()
    {
        bulletLimit1--;
    }
    public void MinusBulletLimit2()
    {
        bulletLimit2--;
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
