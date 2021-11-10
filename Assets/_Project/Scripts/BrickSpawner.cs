using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BrickSpawner : Singleton<BrickSpawner>
{
    public GameObject brickPrefab;

    public List<GameObject> bricksList;

    public List<Vector3> blueBricksPositionList;
    public List<Vector3> greenBricksPositionList;
    public List<Vector3> pinkBricksPositionList;
    public List<Vector3> orangeBricksPositionList;

    private int _blueNumber;
    private int _greenNumber;
    private int _pinkNumber;
    private int _orangeNumber;
    private int _xValue = -8;
    private int _zValue = 6;
    private int _colorValue;

    private bool _isUsed;

    private void Awake()
    {
        StartingSpawn();

        CalculateBrickColors();
    }

    private void CalculateBrickColors()
    {
        foreach (var brick in bricksList)
        {
            while (!_isUsed)
            {
                _colorValue = Random.Range(1, 5);

                if (_colorValue == 1 && _blueNumber < 18)
                {
                    brick.GetComponent<Brick>().color = BrickColors.Blue;
                    brick.GetComponent<Brick>().CurrentColor();
                    _blueNumber++;
                    _isUsed = true;
                    blueBricksPositionList.Add(brick.transform.position);
                }

                else if (_colorValue == 2 && _greenNumber < 15)
                {
                    brick.GetComponent<Brick>().color = BrickColors.Green;
                    brick.GetComponent<Brick>().CurrentColor();
                    _greenNumber++;
                    _isUsed = true;
                    greenBricksPositionList.Add(brick.transform.position);
                }

                else if (_colorValue == 3 && _pinkNumber < 15)
                {
                    brick.GetComponent<Brick>().color = BrickColors.Pink;
                    brick.GetComponent<Brick>().CurrentColor();
                    _pinkNumber++;
                    _isUsed = true;
                    pinkBricksPositionList.Add(brick.transform.position);
                }

                else if (_colorValue == 4 && _orangeNumber < 15)
                {
                    brick.GetComponent<Brick>().color = BrickColors.Orange;
                    brick.GetComponent<Brick>().CurrentColor();
                    _orangeNumber++;
                    _isUsed = true;
                    orangeBricksPositionList.Add(brick.transform.position);
                }
            }

            _isUsed = false;
        }
    }

    private void StartingSpawn()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                var prefab = Instantiate(brickPrefab, new Vector3(_xValue, 0, _zValue), Quaternion.Euler(0, 90, 0));
                _xValue += 2;
                bricksList.Add(prefab);
            }

            _xValue = -8;
            _zValue -= 2;
        }
    }
}