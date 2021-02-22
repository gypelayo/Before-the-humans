using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    [SerializeField]
    GameObject RoverUI;

    private void OnMouseDown()
    {
        RTSCameraController.instance.followTransform = transform;
        if (gameObject.tag == "Player")
        {
            RoverUI.SetActive(true);
        }
    }
}
