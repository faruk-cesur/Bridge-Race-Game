using UnityEngine;


public class CameraManager : MonoBehaviour
{
    public static Camera Cam;
    public static CameraManager Instance;

    public PlayerController player;

    public Transform playerModel, cameraPosition, prepareCam, mainGameCam, winGameCam, loseGameCam;

    private void Awake()
    {
        Cam = Camera.main;
        Instance = this;
    }

    private void Update()
    {
    }
}