﻿using System;
using System.Collections.Generic;
using UnityEngine;


public class CharacterGreen : MonoBehaviour
{
    public CharacterController characterController;
    public List<Brick> collectedBrickListGreen;

    [SerializeField] private Transform _playerModelPelvis;
    [SerializeField] private Animator _animator;

    private float _brickHeight = 0.5f;
    private bool _isRunning;

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
                break;
            case GameState.LoseGame:
                break;
            case GameState.WinGame:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        characterController.CollectBrickTrigger(other, _brickHeight, _playerModelPelvis, collectedBrickListGreen, BrickColors.Green);
    }

    private void CheckCharacterMovement()
    {
        characterController.CheckCharacterMovement(out _isRunning);
    }
}