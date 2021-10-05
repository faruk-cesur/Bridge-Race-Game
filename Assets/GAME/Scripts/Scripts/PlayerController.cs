using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject playerModel;

    #endregion

    private void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameState.StartGame:
                AnimationController.Instance.IdleAnimation();
                break;
            case GameState.MainGame:
                ResetPlayerTransform();
                AnimationController.Instance.RunAnimation();
                break;
            case GameState.LoseGame:
                AnimationController.Instance.LoseAnimation();
                break;
            case GameState.WinGame:
                AnimationController.Instance.WinAnimation();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #region PlayerMovement

    #endregion

    #region Methods

    private void ResetPlayerTransform()
    {
        playerModel.transform.rotation = Quaternion.identity;
        playerModel.transform.position = new Vector3(0, 0, -6);
    }

    #endregion
}