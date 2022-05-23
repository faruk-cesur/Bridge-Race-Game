using System;
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
    [HideInInspector] public bool isGameFinished;

    public float runSpeed;
    public float rotationSpeed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GetComponent<PlayerController>();
        characterGreen = GetComponent<CharacterGreen>();
        characterPink = GetComponent<CharacterPink>();
        characterOrange = GetComponent<CharacterOrange>();
    }

    public void CharacterRotation(Vector3 rigidbodyVelocity, Transform playerModel)
    {
        if (!isGameFinished)
        {
            playerModel.rotation = Quaternion.Slerp(playerModel.rotation, Quaternion.LookRotation(rigidbodyVelocity), Time.fixedDeltaTime * rotationSpeed);
        }
    }

    public void CollectBrickTrigger(Collider other, float brickHeight, Transform playerModelPelvis, List<Brick> collectedBrickList, BrickColors color)
    {
        Brick brick = other.GetComponentInParent<Brick>();
        if (brick)
        {
            if (brick.color == color)
            {
                brick.tag = "BrickTaken";
                collectedBrickList.Add(other.gameObject.GetComponent<Brick>());
                brickHeight = 0.25f + (collectedBrickList.Count * 0.25f);
                other.gameObject.GetComponentInChildren<Collider>().enabled = false;
                other.gameObject.transform.SetParent(playerModelPelvis);
                other.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                other.gameObject.transform.DOLocalMove(new Vector3(-0.4f, brickHeight, 0f), 0.5f);
                UIManager.Instance.gold++;
            }
        }
    }

    public IEnumerator LastBridgeTrigger(Collider other)
    {
        if (other.CompareTag("LastBridge"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.transform.DOMove(new Vector3(transform.position.x, transform.position.y + 0.20f, transform.position.z + 1.5f), 0.5f);
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }

    public void FinishLineTrigger(Collider other, Animator animator, Transform playerModel)
    {
        if (other.CompareTag("FinishLine"))
        {
            isGameFinished = true;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.transform.DOMove(new Vector3(0, transform.position.y + 0.20f, transform.position.z + 1.5f), 0.5f);
            playerModel.localRotation = Quaternion.Euler(0, 180, 0);
            _rigidbody.velocity = Vector3.zero;
            AnimationManager.Instance.WinAnimation(animator);
            CameraManager.Instance.WinGameCamera();
            GameManager.Instance.WinGame();
        }
    }


    public void CheckCharacterMovement(out bool isRunning)
    {
        if (_rigidbody.velocity == Vector3.zero)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }
    }
}