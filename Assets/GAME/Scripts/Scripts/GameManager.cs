﻿using System;
using UnityEngine;

public enum GameState
{
    StartGame,
    MainGame,
    LoseGame,
    WinGame
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameState _currentGameState;

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set
        {
            switch (value)
            {
                case GameState.StartGame:
                    break;
                case GameState.MainGame:
                    break;
                case GameState.LoseGame:
                    break;
                case GameState.WinGame:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }

            _currentGameState = value;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        CurrentGameState = GameState.StartGame;
    }

    public void StartGame()
    {
        CurrentGameState = GameState.MainGame;
        UIManager.Instance.MainGameUI();
        CameraManager.Instance.MainGameCamera();
    }

    public void RestartGame()
    {
        UIManager.Instance.RetryButton();
    }

    public void LoseGame()
    {
        CameraManager.Instance.LoseGameCamera();
        CurrentGameState = GameState.LoseGame;
        StartCoroutine(UIManager.Instance.DurationLoseGameUI());
    }

    public void WinGame()
    {
        UIManager.Instance.UpdateGoldInfo();
        CurrentGameState = GameState.WinGame;
        StartCoroutine(UIManager.Instance.DurationWinGameUI());
    }
}