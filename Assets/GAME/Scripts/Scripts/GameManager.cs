using System;
using UnityEngine;

public enum GameState
{
    PrepareGame,
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
                case GameState.PrepareGame:
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

        CurrentGameState = GameState.PrepareGame;
    }
/*
    public void StartGame()
    {
        CurrentGameState = GameState.MainGame;
        UIManager.Instance.MainGameUI();
        AnimationController.Instance.RunAnimation();
    }

    public void RestartGame()
    {
        UIManager.Instance.RetryButton();
    }

    public void NextLevel()
    {
        UIManager.Instance.NextLevelButton();
    }

    public void LoseGame()
    {
        StartCoroutine(UIManager.Instance.DurationLoseGameUI());
    }

    public void WinGame()
    {
        UIManager.Instance.WinGameUI();
    }
    
 */
}