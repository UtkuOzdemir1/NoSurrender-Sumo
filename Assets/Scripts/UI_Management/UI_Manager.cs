using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject LoseMenu;
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject WinMenu;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI startTimeText;
    [SerializeField] TextMeshProUGUI scoreText;

    float currentTime = 0f;
    public float countdownTime = 60f;

    float curTime = 0f;
    public float startTime = 60f;

    void Start()
    {
        curTime = startTime;
        currentTime = countdownTime;
    }

    void Update()
    {
        
        scoreText.text = GameManager.Instance.score.ToString("0");

        if (GameManager.Instance.State == GameState.Start)
        {
            StartTimer();
        }
        if (GameManager.Instance.State == GameState.GamePlay)
        {
            GamePlay();
        }
        if (GameManager.Instance.State == GameState.Pause)
        {
            Pause();
        }
        if (GameManager.Instance.State == GameState.Lose)
        {
            Lose();
        }
        if (GameManager.Instance.State == GameState.Win)
        {
            Win();
        }

    }
    public void GamePlay()
    {
        CountdownTimer();
        Time.timeScale = 1f;
        StartMenu.SetActive(false);
        GameManager.Instance.canMove = true;
    }

    public void Lose()
    {
        LoseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Win()
    {
        WinMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Pause()
    {   // to do - game must stop while in pause menu
        PauseMenu.SetActive(true);
        GameManager.Instance.State = GameState.Pause;
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        GameManager.Instance.State = GameState.GamePlay;
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void CountdownTimer()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            GameManager.Instance.State = GameState.Win;
        }
    }

    public void StartTimer()
    {

        curTime -= 1 * Time.deltaTime;
        startTimeText.text = curTime.ToString("0");

        if (curTime <= 0)
        {
            curTime = 0;
            GameManager.Instance.State = GameState.GamePlay;
        }
    }
}
