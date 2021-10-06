using System;
using DG.Tweening;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    #region Fields
    
    public float runSpeed;
    public float angleSpeed;

    [SerializeField] private Transform _playerModel;
    [SerializeField] private FloatingJoystick _floatingJoystick;

    private Rigidbody _rigidbody;
    private bool _isGameStarted;

    
    

    #endregion

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameState.StartGame:
                AnimationController.Instance.IdleAnimation();
                break;
            case GameState.MainGame:
                ResetPlayerTransform();
                PlayerMovement();
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

    private void PlayerMovement()
    {
        _rigidbody.velocity = new Vector3(_floatingJoystick.Horizontal,0f,_floatingJoystick.Vertical) * runSpeed;
        _playerModel.rotation = Quaternion.Slerp(_playerModel.rotation,_playerModel.rotation = Quaternion.LookRotation((_floatingJoystick.Vertical * transform.forward + _floatingJoystick.Horizontal * transform.right).normalized), Time.fixedDeltaTime * angleSpeed);
    }

    #endregion

    #region Methods

    private void ResetPlayerTransform()
    {
        if (!_isGameStarted)
        {
            _isGameStarted = true;
            _playerModel.transform.localRotation = Quaternion.identity;
            _playerModel.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Brick brick = other.GetComponentInParent<Brick>();
        if (brick.color == BrickColors.Blue)
        {
            brick.collectedBrick++;
            other.gameObject.GetComponentInChildren<Collider>().enabled = false;
            other.gameObject.transform.SetParent(_playerModel);
            other.gameObject.transform.DOMove(transform.position,1f);
        }
    }

    #endregion
}