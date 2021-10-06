using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public enum BrickColors
{
    Blue,Green,Pink,Orange
}

public class Brick : MonoBehaviour
{

    public int collectedBrick = 0;
    
    [OnValueChanged("CurrentColor")]
    public BrickColors color;

    [ReorderableList]
    [SerializeField] private List<Material> materials;

    [SerializeField] private MeshRenderer meshRenderer;

    private void CurrentColor()
    {
        switch (color)
        {
            case BrickColors.Blue:
                meshRenderer.sharedMaterial = materials[0];
                break;
            case BrickColors.Green:
                meshRenderer.sharedMaterial = materials[1];
                break;
            case BrickColors.Pink:
                meshRenderer.sharedMaterial = materials[2];
                break;
            case BrickColors.Orange:
                meshRenderer.sharedMaterial = materials[3];
                break;
        }
    }
}
