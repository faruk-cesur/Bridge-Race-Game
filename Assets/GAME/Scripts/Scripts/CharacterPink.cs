using System.Collections.Generic;
using UnityEngine;


public class CharacterPink : MonoBehaviour
{
    public CharacterController characterController;
    
    public List<Brick> collectedBrickListPink;

    [SerializeField] private Transform _playerModel;
    [SerializeField] private Transform _playerModelPelvis;

    private float _brickHeight = 0.5f;

    /*private void PlayerMovement()
    {
        characterController.CharacterRotation(_floatingJoystick.Horizontal, _floatingJoystick.Vertical, _playerModel);
        characterController.CharacterMovement(_floatingJoystick.Horizontal, _floatingJoystick.Vertical);
    }*/
    private void OnTriggerEnter(Collider other)
    {
        characterController.CharacterOnTriggerEnter(other,_brickHeight,_playerModelPelvis,collectedBrickListPink,BrickColors.Pink);
    }
}