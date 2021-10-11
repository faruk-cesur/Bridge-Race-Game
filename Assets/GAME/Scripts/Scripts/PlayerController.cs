using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;

    [SerializeField] private Transform _playerModel;
    [SerializeField] private Transform _playerModelPelvis;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    public List<Brick> collectedBrickListBlue;

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
                PlayerMovement();
                break;
            case GameState.LoseGame:
                break;
            case GameState.WinGame:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void PlayerMovement()
    {
        if (GameManager.Instance.isRunning)
        {
            characterController.CharacterRotation(_floatingJoystick.Horizontal, _floatingJoystick.Vertical, _playerModel);
        }

        characterController.CharacterMovement(_floatingJoystick.Horizontal, _floatingJoystick.Vertical);
    }

    private void OnTriggerEnter(Collider other)
    {
        Brick brick = other.GetComponentInParent<Brick>();
        if (brick)
        {
            if (brick.color == BrickColors.Blue)
            {
                collectedBrickListBlue.Add(other.gameObject.GetComponent<Brick>());
                _brickHeight = 0.25f + (collectedBrickListBlue.Count * 0.25f);
                other.gameObject.GetComponentInChildren<Collider>().enabled = false;
                other.gameObject.transform.SetParent(_playerModelPelvis);
                other.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                other.gameObject.transform.DOLocalMove(new Vector3(-0.4f, _brickHeight, 0f), 0.5f);
            }
        }
    }
}