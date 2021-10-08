using System;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    public float runSpeed;
    public float angleSpeed;

    private Rigidbody _rigidbody;
    private bool _isGameStarted;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void CharacterMovement(float horizontalMove, float verticalMove, Transform playerModel)
    {
        _rigidbody.velocity = new Vector3(horizontalMove, 0f, verticalMove) * runSpeed;

        var rotation = playerModel.rotation;
        rotation = Quaternion.Slerp(rotation, rotation = Quaternion.LookRotation((verticalMove * transform.forward + horizontalMove * transform.right).normalized), Time.fixedDeltaTime * angleSpeed);
        playerModel.rotation = rotation;
    }
    
    public void ResetCharacterTransform(Transform playerModel)
    {
        if (!_isGameStarted)
        {
            _isGameStarted = true;
            var transform1 = playerModel.transform;
            transform1.localRotation = Quaternion.identity;
            transform1.localPosition = new Vector3(0, 0, 0);
        }
    }
}