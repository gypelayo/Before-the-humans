using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCameraController : MonoBehaviour
{
    private Button switchCamera;
    [SerializeField]
    private GameObject roverVision;
    [SerializeField]
    private RenderTexture satelliteCamera;
    [SerializeField]
    private RenderTexture roverCamera;
    private RenderTexture currentCameraFeed;


    private void Start()
    {
        currentCameraFeed = satelliteCamera;
        switchCamera = GetComponent<Button>();
        switchCamera.onClick.AddListener(SwitchCam);
    }

    private void SwitchCam()
    {
        if (currentCameraFeed == satelliteCamera)
        {
            roverVision.SetActive(true);
            currentCameraFeed = roverCamera;
            GetComponent<RawImage>().texture = satelliteCamera;
        }
        else if (currentCameraFeed == roverCamera)
        {
            roverVision.SetActive(false);
            currentCameraFeed=satelliteCamera;
            GetComponent<RawImage>().texture = roverCamera;
        }

    }
}
