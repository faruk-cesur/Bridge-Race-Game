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

    private Rigidbody _rigidbody;
    private float _brickHeight = 0.5f;
    private float _startingCameraFOV;
    private bool _isRunning;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
            characterController.CharacterRotation(_rigidbody.velocity, _playerModel);
        }

        if (!characterController.isGameFinished)
        {
            _rigidbody.velocity = new Vector3(_floatingJoystick.Horizontal, 0f, _floatingJoystick.Vertical).normalized * (characterController.runSpeed * Time.fixedDeltaTime);
        }
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