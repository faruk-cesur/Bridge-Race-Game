﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    [HideInInspector] public PlayerController player;
    [HideInInspector] public CharacterGreen characterGreen;
    [HideInInspector] public CharacterPink characterPink;
    [HideInInspector] public CharacterOrange characterOrange;

    public float runSpeed;
    public float angleSpeed;

    private Rigidbody _rigidbody;
    private bool _isGameStarted;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GetComponent<PlayerController>();
        characterGreen = GetComponent<CharacterGreen>();
        characterPink = GetComponent<CharacterPink>();
        characterOrange = GetComponent<CharacterOrange>();
    }

    public void CharacterMovement(float horizontalMove, float verticalMove)
    {
        _rigidbody.velocity = new Vector3(horizontalMove, 0f, verticalMove) * runSpeed;
    }

    public void CharacterRotation(float horizontalMove, float verticalMove, Transform playerModel)
    {
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

    public void CollectBrickTrigger(Collider other, float brickHeight, Transform playerModelPelvis, List<Brick> collectedBrickList, BrickColors color)
    {
        Brick brick = other.GetComponentInParent<Brick>();
        if (brick)
        {
            if (brick.color == color)
            {
                collectedBrickList.Add(other.gameObject.GetComponent<Brick>());
                brickHeight = 0.25f + (collectedBrickList.Count * 0.25f);
                other.gameObject.GetComponentInChildren<Collider>().enabled = false;
                other.gameObject.transform.SetParent(playerModelPelvis);
                other.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                other.gameObject.transform.DOLocalMove(new Vector3(-0.4f, brickHeight, 0f), 0.5f);
            }
        }
    }

    public IEnumerator LastBridgeTrigger(Collider other)
    {
        FinishBridgeTrigger finishBridgeTrigger = other.GetComponentInParent<FinishBridgeTrigger>();

        if (finishBridgeTrigger)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.transform.DOMove(new Vector3(transform.position.x, transform.position.y +0.20f, transform.position.z + 2),0.5f);
            other.gameObject.GetComponent<Collider>().isTrigger = false;
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }

    public void CheckCharacterMovement(out bool isRunning)
    {
        if (_rigidbody.velocity.x == 0 && _rigidbody.velocity.y == 0 && _rigidbody.velocity.z == 0)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }
    }
}