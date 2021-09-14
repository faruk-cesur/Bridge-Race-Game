using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    #region Fields

    #endregion

    private void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameState.PrepareGame:
                AnimationController.Instance.IdleAnimation();
                break;
            case GameState.MainGame:

                break;
            case GameState.LoseGame:
                break;
            case GameState.WinGame:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #region PlayerMovement

    #endregion
}