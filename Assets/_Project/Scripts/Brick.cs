using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public enum BrickColors
{
    Default,
    Blue,
    Green,
    Pink,
    Orange
}

public class Brick : MonoBehaviour
{
    [OnValueChanged("CurrentColor")] public BrickColors color;

    [ReorderableList] [SerializeField] private List<Material> _materials;

    [SerializeField] private MeshRenderer _meshRenderer;

    private Vector3 _spawnPosition;

    private void Awake()
    {
        Invoke(nameof(GetPosition), 0.01f);
    }

    private void Update()
    {
        if (gameObject.CompareTag("Empty"))
        {
            gameObject.tag = "Untagged";
            var spawnedBrick = Instantiate(gameObject, _spawnPosition, Quaternion.identity);
            spawnedBrick.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            spawnedBrick.GetComponent<Collider>().enabled = true;
        }
    }

    public void GetPosition()
    {
        _spawnPosition = transform.position;
    }

    public void CurrentColor()
    {
        switch (color)
        {
            case BrickColors.Default:
                _meshRenderer.sharedMaterial = _materials[0];
                gameObject.tag = "BrickDefault";
                break;
            case BrickColors.Blue:
                _meshRenderer.sharedMaterial = _materials[1];
                gameObject.tag = "BrickBlue";
                break;
            case BrickColors.Green:
                _meshRenderer.sharedMaterial = _materials[2];
                gameObject.tag = "BrickGreen";
                break;
            case BrickColors.Pink:
                _meshRenderer.sharedMaterial = _materials[3];
                gameObject.tag = "BrickPink";
                break;
            case BrickColors.Orange:
                _meshRenderer.sharedMaterial = _materials[4];
                gameObject.tag = "BrickOrange";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}