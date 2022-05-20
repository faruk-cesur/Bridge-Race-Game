using System;
using System.Collections.Generic;
using Cinemachine.Utility;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIController : MonoBehaviour
{
    public enum Floor
    {
        FirstFloor,
        SecondFloor,
        ThirdFloor
    }

    [SerializeField] private BrickSpawner _brickSpawner1;
    [SerializeField] private BrickSpawner _brickSpawner2;
    [SerializeField] private BrickSpawner _brickSpawner3;
    [SerializeField] private BrickSpawner _currentBrickSpawner;

    [SerializeField] private CharacterController _characterController;
    private Rigidbody _rigidbody;

    private Floor _currentFloor;
    private Vector3 _randomBrickPosition;
    private List<Vector3> _currentBrickPositionList;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentBrickSpawner = _brickSpawner1;
    }

    private void FixedUpdate()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameState.StartGame:
                break;
            case GameState.MainGame:
                AIMoveToBricks();
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
        if (gameObject.CompareTag("Pink") && other.CompareTag("BrickSpawner1"))
        {
            _currentFloor = Floor.FirstFloor;
            _currentBrickSpawner = _brickSpawner1;
            _currentBrickPositionList = _currentBrickSpawner.pinkBricksPositionList;
            GenerateRandomBrickPosition();
        }

        if (gameObject.CompareTag("Pink") && other.CompareTag("BrickSpawner2"))
        {
            _currentFloor = Floor.SecondFloor;
            _currentBrickSpawner = _brickSpawner2;
            _currentBrickPositionList = _currentBrickSpawner.pinkBricksPositionList;
            GenerateRandomBrickPosition();
        }

        if (gameObject.CompareTag("Pink") && other.CompareTag("BrickSpawner3"))
        {
            _currentFloor = Floor.ThirdFloor;
            _currentBrickSpawner = _brickSpawner3;
            _currentBrickPositionList = _currentBrickSpawner.pinkBricksPositionList;
            GenerateRandomBrickPosition();
        }

        if (gameObject.CompareTag("Green") && other.CompareTag("BrickSpawner1"))
        {
            _currentFloor = Floor.FirstFloor;
            _currentBrickSpawner = _brickSpawner1;
            _currentBrickPositionList = _currentBrickSpawner.greenBricksPositionList;
            GenerateRandomBrickPosition();
        }

        if (gameObject.CompareTag("Green") && other.CompareTag("BrickSpawner2"))
        {
            _currentFloor = Floor.SecondFloor;
            _currentBrickSpawner = _brickSpawner2;
            _currentBrickPositionList = _currentBrickSpawner.greenBricksPositionList;
            GenerateRandomBrickPosition();
        }

        if (gameObject.CompareTag("Green") && other.CompareTag("BrickSpawner3"))
        {
            _currentFloor = Floor.ThirdFloor;
            _currentBrickSpawner = _brickSpawner3;
            _currentBrickPositionList = _currentBrickSpawner.greenBricksPositionList;
            GenerateRandomBrickPosition();
        }

        if (gameObject.CompareTag("Orange") && other.CompareTag("BrickSpawner1"))
        {
            _currentFloor = Floor.FirstFloor;
            _currentBrickSpawner = _brickSpawner1;
            _currentBrickPositionList = _currentBrickSpawner.orangeBricksPositionList;
            GenerateRandomBrickPosition();
        }

        if (gameObject.CompareTag("Orange") && other.CompareTag("BrickSpawner2"))
        {
            _currentFloor = Floor.SecondFloor;
            _currentBrickSpawner = _brickSpawner2;
            _currentBrickPositionList = _currentBrickSpawner.orangeBricksPositionList;
            GenerateRandomBrickPosition();
        }

        if (gameObject.CompareTag("Orange") && other.CompareTag("BrickSpawner3"))
        {
            _currentFloor = Floor.ThirdFloor;
            _currentBrickSpawner = _brickSpawner3;
            _currentBrickPositionList = _currentBrickSpawner.orangeBricksPositionList;
            GenerateRandomBrickPosition();
        }
        
        Brick brick = other.GetComponentInParent<Brick>();
        if (brick)
        {
            // todo listeden çıkarma doğru çalışmıyor 
            if (brick.color == BrickColors.Pink && gameObject.CompareTag("Pink"))
            {
                _currentBrickPositionList.Remove(_randomBrickPosition);
                GenerateRandomBrickPosition();
            }

            if (brick.color == BrickColors.Green && gameObject.CompareTag("Green"))
            {
                _currentBrickPositionList.Remove(_randomBrickPosition);
                GenerateRandomBrickPosition();
            }

            if (brick.color == BrickColors.Orange && gameObject.CompareTag("Orange"))
            {
                _currentBrickPositionList.Remove(_randomBrickPosition);
                GenerateRandomBrickPosition();
            }
        }
    }

    private void GenerateRandomBrickPosition()
    {
        _randomBrickPosition = _currentBrickPositionList[Random.Range(0, _currentBrickPositionList.Count - 1)];
    }

    private void AIMoveToBricks()
    {
        var difference = _randomBrickPosition - transform.position;
        _rigidbody.velocity = difference.normalized * Time.fixedDeltaTime * 250;
    }
}