using System;
using Cinemachine.Utility;
using UnityEngine;

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
                AICollectBrick();
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
        }
        if (gameObject.CompareTag("Pink") && other.CompareTag("BrickSpawner2"))
        {
            _currentFloor = Floor.SecondFloor;
            _currentBrickSpawner = _brickSpawner2;
        }
        if (gameObject.CompareTag("Pink") && other.CompareTag("BrickSpawner3"))
        {
            _currentFloor = Floor.ThirdFloor;
            _currentBrickSpawner = _brickSpawner3;
        }
        
        if (gameObject.CompareTag("Green") && other.CompareTag("BrickSpawner1"))
        {
            _currentFloor = Floor.FirstFloor;
            _currentBrickSpawner = _brickSpawner1;
        }
        if (gameObject.CompareTag("Green") && other.CompareTag("BrickSpawner2"))
        {
            _currentFloor = Floor.SecondFloor;
            _currentBrickSpawner = _brickSpawner2;
        }
        if (gameObject.CompareTag("Green") && other.CompareTag("BrickSpawner3"))
        {
            _currentFloor = Floor.ThirdFloor;
            _currentBrickSpawner = _brickSpawner3;
        }
        
        if (gameObject.CompareTag("Orange") && other.CompareTag("BrickSpawner1"))
        {
            _currentFloor = Floor.FirstFloor;
            _currentBrickSpawner = _brickSpawner1;
        }
        if (gameObject.CompareTag("Orange") && other.CompareTag("BrickSpawner2"))
        {
            _currentFloor = Floor.SecondFloor;
            _currentBrickSpawner = _brickSpawner2;
        }
        if (gameObject.CompareTag("Orange") && other.CompareTag("BrickSpawner3"))
        {
            _currentFloor = Floor.ThirdFloor;
            _currentBrickSpawner = _brickSpawner3;
        }
    }

    private void AICollectBrick()
    {
        var difference = _currentBrickSpawner.blueBricksPositionList[0] - transform.position;
       // _rigidbody.velocity = Vector3.Lerp(_rigidbody.velocity ,difference.normalized *5 , 2f);
       _rigidbody.velocity = difference.normalized * Time.fixedDeltaTime * 250;
        // todo devam et
        //_characterController.CharacterMovement(5,5);
    }
}