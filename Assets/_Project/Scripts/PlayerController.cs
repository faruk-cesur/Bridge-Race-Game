using System;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;

    public List<Brick> collectedBrickListBlue;

    [SerializeField] private Transform _playerModel;
    [SerializeField] private Transform _playerModelPelvis;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private CinemachineVirtualCamera _camera;

    private float _brickHeight = 0.5f;
    private float _startingCameraFOV;
    private bool _isRunning;

    private void Start()
    {
        _startingCameraFOV = _camera.m_Lens.FieldOfView;
    }

    private void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameState.StartGame:
                CheckCharacterMovement();
                AnimationManager.Instance.RunAnimation(_animator, _isRunning);
                break;
            case GameState.MainGame:
                CheckCharacterMovement();
                AnimationManager.Instance.RunAnimation(_animator, _isRunning);
                characterController.ResetCharacterTransform(_playerModel);
                SetCameraFOVByBrickNumber();
                break;
            case GameState.LoseGame:
                break;
            case GameState.WinGame:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void FixedUpdate()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameState.StartGame:
                break;
            case GameState.MainGame:
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
        if (_isRunning)
        {
            characterController.CharacterRotation(_floatingJoystick.Horizontal, _floatingJoystick.Vertical, _playerModel);
        }

        characterController.CharacterMovement(_floatingJoystick.Horizontal, _floatingJoystick.Vertical);
    }

    private void OnTriggerEnter(Collider other)
    {
        characterController.CollectBrickTrigger(other, _brickHeight, _playerModelPelvis, collectedBrickListBlue, BrickColors.Blue);
        StartCoroutine(characterController.LastBridgeTrigger(other));
        characterController.FinishLineTrigger(other, _animator, _playerModel);
    }

    private void CheckCharacterMovement()
    {
        characterController.CheckCharacterMovement(out _isRunning);
    }

    private void SetCameraFOVByBrickNumber()
    {
        _camera.m_Lens.FieldOfView = Mathf.Lerp(_camera.m_Lens.FieldOfView, _startingCameraFOV + collectedBrickListBlue.Count, 2 * Time.deltaTime);
    }
}