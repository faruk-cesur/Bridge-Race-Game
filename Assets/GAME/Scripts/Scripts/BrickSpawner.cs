using System;
using System.Collections.Generic;
using UnityEngine;


public class BrickSpawner : Singleton<BrickSpawner>
{
    public List<GameObject> bricksList;

    public List<Vector3> bricksPositionList;

    private void Awake()
    {
        foreach (var brick in bricksList)
        {
            bricksPositionList.Add(brick.transform.position);
        }
    }
}