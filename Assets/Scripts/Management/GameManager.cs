using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject enemies;
    public int score = 0;
    public bool canMove = false;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;
    void Awake()
    {
        Time.timeScale = 1f;
        Instance = this;
    }

    void Update()
    {
        if(enemies.transform.childCount <= 0)
        {
            GameManager.Instance.State = GameState.Win;
        }
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Start:
                break;
            case GameState.GamePlay:
                break;
            case GameState.Pause:
                break;
            case GameState.Lose:
                break;
            case GameState.Win:
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }

}

public enum GameState
{
    Start,
    GamePlay,
    Pause,
    Lose,
    Win
}
