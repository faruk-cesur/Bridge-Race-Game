using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public enum BridgeColors
{
    Blue,
    Green,
    Pink,
    Orange
}

public class Bridge : MonoBehaviour
{
    public int usedBridgeBlue = 0;
    public int usedBridgeGreen = 0;
    public int usedBridgePink = 0;
    public int usedBridgeOrange = 0;
    
    

    [OnValueChanged("CurrentColor")] public BridgeColors color;

    [ReorderableList] [SerializeField] private List<Material> materials;

    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private GameObject parentObject;

    private bool _isCharacterTouch;
    
    
    private void CurrentColor()
    {
        switch (color)
        {
            case BridgeColors.Blue:
                meshRenderer.sharedMaterial = materials[0];
                break;
            case BridgeColors.Green:
                meshRenderer.sharedMaterial = materials[1];
                break;
            case BridgeColors.Pink:
                meshRenderer.sharedMaterial = materials[2];
                break;
            case BridgeColors.Orange:
                meshRenderer.sharedMaterial = materials[3];
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterController character = other.GetComponentInParent<CharacterController>();
        if (character)
        {
            if (!_isCharacterTouch)
            {
                _isCharacterTouch = true;
                
                if (character.CompareTag("Blue") && GameManager.Instance.collectedBrickBlueList.Count > 0)
                {
                    Instantiate(gameObject, new Vector3(transform.localPosition.x, transform.localPosition.y + 0.30f, transform.localPosition.z + 0.6f),transform.localRotation,parentObject.transform);
                    Destroy(GameManager.Instance.collectedBrickBlueList[GameManager.Instance.collectedBrickBlueList.Count -1]);
                    GameManager.Instance.collectedBrickBlueList.RemoveAt(GameManager.Instance.collectedBrickBlueList.Count-1);
                }
            }
        }
    }
}