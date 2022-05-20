using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab;
    public Transform brickSpawnerParent1;
    public Transform brickSpawnerParent2;
    public Transform brickSpawnerParent3;

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
    private bool _isFloorSpawned;
    public bool isTouchBlue;
    public bool isTouchGreen;
    public bool isTouchPink;
    public bool isTouchOrange;

    private void Awake()
    {
        gameObject.GetComponent<Collider>().enabled = false;
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameState.MainGame)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        #region SpawnPlatformBricks

        // Herhangi bir karakter zemine ayak bastığında rastgele pozisyonlarda ve rastgele renklerde 63 adet brick oluşturur.

        if ((other.CompareTag("Blue") || other.CompareTag("Green") || other.CompareTag("Pink") || other.CompareTag("Orange")) && gameObject.CompareTag("BrickSpawner1") && GameManager.Instance.CurrentGameState == GameState.MainGame && !_isFloorSpawned)
        {
            _isFloorSpawned = true; // Running Once
            SpawnPlatformBricks(brickSpawnerParent1);
            CalculateBrickColors();
        }

        if ((other.CompareTag("Blue") || other.CompareTag("Green") || other.CompareTag("Pink") || other.CompareTag("Orange")) && gameObject.CompareTag("BrickSpawner2") && GameManager.Instance.CurrentGameState == GameState.MainGame && !_isFloorSpawned)
        {
            _isFloorSpawned = true; // Running Once
            SpawnPlatformBricks(brickSpawnerParent2);
            CalculateBrickColors();
        }

        if ((other.CompareTag("Blue") || other.CompareTag("Green") || other.CompareTag("Pink") || other.CompareTag("Orange")) && gameObject.CompareTag("BrickSpawner3") && GameManager.Instance.CurrentGameState == GameState.MainGame && !_isFloorSpawned)
        {
            _isFloorSpawned = true; // Running Once
            SpawnPlatformBricks(brickSpawnerParent3);
            CalculateBrickColors();
        }

        #endregion


        #region BricksSetActiveTrue

        // Zemine basan karakterin rengi ne ise o renkteki brickler görünür olur.

        if (other.CompareTag("Blue") && !isTouchBlue)
        {
            isTouchBlue = true;
            foreach (var brick in bricksList)
            {
                if (brick.CompareTag("BrickBlue"))
                {
                    brick.SetActive(true);
                    brick.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    brick.transform.DOScale(new Vector3(3f, 3f, 3f), 0.25f).OnComplete(() => brick.transform.DOScale(new Vector3(2f, 2f, 2f), 0.25f));
                }
            }
        }

        if (other.CompareTag("Green") && !isTouchGreen)
        {
            isTouchGreen = true;
            foreach (var brick in bricksList)
            {
                if (brick.CompareTag("BrickGreen"))
                {
                    brick.SetActive(true);
                    brick.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    brick.transform.DOScale(new Vector3(3f, 3f, 3f), 0.25f).OnComplete(() => brick.transform.DOScale(new Vector3(2f, 2f, 2f), 0.25f));
                }
            }
        }

        if (other.CompareTag("Pink") && !isTouchPink)
        {
            isTouchPink = true;
            foreach (var brick in bricksList)
            {
                if (brick.CompareTag("BrickPink"))
                {
                    brick.SetActive(true);
                    brick.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    brick.transform.DOScale(new Vector3(3f, 3f, 3f), 0.25f).OnComplete(() => brick.transform.DOScale(new Vector3(2f, 2f, 2f), 0.25f));
                }
            }
        }

        if (other.CompareTag("Orange") && !isTouchOrange)
        {
            isTouchOrange = true;
            foreach (var brick in bricksList)
            {
                if (brick.CompareTag("BrickOrange"))
                {
                    brick.SetActive(true);
                    brick.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    brick.transform.DOScale(new Vector3(3f, 3f, 3f), 0.25f).OnComplete(() => brick.transform.DOScale(new Vector3(2f, 2f, 2f), 0.25f));
                }
            }
        }

        #endregion
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
            brick.SetActive(false);
        }
    }

    private void SpawnPlatformBricks(Transform parent)
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                var prefab = Instantiate(brickPrefab, Vector3.zero, Quaternion.Euler(0, 90, 0), parent);
                prefab.transform.localPosition = new Vector3(_xValue, 0, _zValue);
                _xValue += 2;
                bricksList.Add(prefab);
            }

            _xValue = -8;
            _zValue -= 2;
        }
    }
}