using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public enum BrickColors
{
    Blue,
    Green,
    Pink,
    Orange
}

public class Brick : MonoBehaviour
{
    [OnValueChanged("CurrentColor")] public BrickColors color;

    [ReorderableList] [SerializeField] private List<Material> materials;

    [SerializeField] private MeshRenderer meshRenderer;

    public void CurrentColor()
    {
        switch (color)
        {
            case BrickColors.Blue:
                meshRenderer.sharedMaterial = materials[0];
                gameObject.tag = "BrickBlue";
                break;
            case BrickColors.Green:
                meshRenderer.sharedMaterial = materials[1];
                gameObject.tag = "BrickGreen";
                break;
            case BrickColors.Pink:
                meshRenderer.sharedMaterial = materials[2];
                gameObject.tag = "BrickPink";
                break;
            case BrickColors.Orange:
                meshRenderer.sharedMaterial = materials[3];
                gameObject.tag = "BrickOrange";
                break;
        }
    }
}