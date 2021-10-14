using System;
using System.Collections.Generic;
using UnityEngine;


public class CharacterPink : MonoBehaviour
{
    public CharacterController characterController;

    public List<Brick> collectedBrickListPink;

    [SerializeField] private Transform _playerModel;
    [SerializeField] private Transform _playerModelPelvis;

    private float _brickHeight = 0.5f;

    private void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameState.StartGame:
                AnimationController.Instance.IdleAnimation();
                break;
            case GameState.MainGame:
                characterController.ResetCharacterTransform(_playerModel);
                //PlayerMovement();
                break;
            case GameState.LoseGame:
                break;
            case GameState.WinGame:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    /*private void PlayerMovement()
    {
        characterController.CharacterRotation(_floatingJoystick.Horizontal, _floatingJoystick.Vertical, _playerModel);
        characterController.CharacterMovement(_floatingJoystick.Horizontal, _floatingJoystick.Vertical);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        characterController.CollectBrickTrigger(other, _brickHeight, _playerModelPelvis, collectedBrickListPink, BrickColors.Pink);
    }
}