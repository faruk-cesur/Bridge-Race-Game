using System;
using UnityEngine;


public class CameraManager : MonoBehaviour
{
    private static CameraManager _instance;
    public static CameraManager Instance => _instance;

    public GameObject prepareGameCam, mainGameCam, winGameCam, loseGameCam;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        PrepareGameCamera();
    }

    public void PrepareGameCamera()
    {
        prepareGameCam.SetActive(true);
        mainGameCam.SetActive(false);
        winGameCam.SetActive(false);
        loseGameCam.SetActive(false);
    }

    public void MainGameCamera()
    {
        prepareGameCam.SetActive(false);
        mainGameCam.SetActive(true);
        winGameCam.SetActive(false);
        loseGameCam.SetActive(false);
    }

    public void WinGameCamera()
    {
        prepareGameCam.SetActive(false);
        mainGameCam.SetActive(false);
        winGameCam.SetActive(true);
        loseGameCam.SetActive(false);
    }

    public void LoseGameCamera()
    {
        prepareGameCam.SetActive(false);
        mainGameCam.SetActive(false);
        winGameCam.SetActive(false);
        loseGameCam.SetActive(true);
    }
}