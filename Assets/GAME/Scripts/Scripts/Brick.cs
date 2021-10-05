﻿using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public enum BrickColors
{
    Blue,Green,Pink,Orange
}

public class Brick : MonoBehaviour
{

    [OnValueChanged("Degistir")]
    public BrickColors color;

    [ReorderableList]
    [SerializeField] private List<Material> materials;

    [SerializeField] private MeshRenderer meshRenderer;
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void Degistir()
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