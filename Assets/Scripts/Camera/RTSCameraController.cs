using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCameraController : MonoBehaviour
{
    public static RTSCameraController instance;

    public Transform cameraTransform;
    public Transform followTransform;

    public float normalSpeed;
    public float fastSpeed;

    public float movementSpeed;
    public float movementTime;

    public float zoomAmount;
    public float rotationAmount;

    public Quaternion newRotation;
    public Vector3 newPosition;
    public float newZoom;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public Vector3 rotateStartPosition;
    public Vector3 rotateCurrentPosition;

    private Camera cameraMain;

    [SerializeField]
    private GameObject RoverUI;

    [SerializeField]
    private float maxZoomOut = 50;
    [SerializeField]
    private float maxZoomIn = 5;
    [SerializeField]
    private GameObject RoverVision;
    public bool canControl = true;

    void Start()
    {
        instance = this;
        cameraMain = cameraTransform.gameObject.GetComponent<Camera>();

        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraMain.fieldOfView;


    }

    void Update()
    {
        if (followTransform != null)
        {
            HandleMouseInput();
            HandleMovementInput();
            transform.position = followTransform.position;
        }
        else
        {
            HandleMouseInput();
            HandleMovementInput();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !RoverVision.activeInHierarchy)
        {
            followTransform = null;
            RoverUI.SetActive(false);
        }
    }

    private void HandleMouseInput()
    {
        if (canControl)
        {


            if (Input.mouseScrollDelta.y != 0)
            {
                newZoom -= Input.mouseScrollDelta.y;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Plane plane = new Plane(Vector3.up, Vector3.zero);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                float entry;

                if (plane.Raycast(ray, out entry))
                {
                    dragStartPosition = ray.GetPoint(entry);
                }
            }

            if (Input.GetMouseButton(0))
            {
                Plane plane = new Plane(Vector3.up, Vector3.zero);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                float entry;

                if (plane.Raycast(ray, out entry))
                {
                    dragCurrentPosition = ray.GetPoint(entry);

                    newPosition = transform.position + dragStartPosition - dragCurrentPosition;
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                rotateStartPosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(1))
            {
                rotateCurrentPosition = Input.mousePosition;

                Vector3 difference = rotateStartPosition - rotateCurrentPosition;

                rotateStartPosition = rotateCurrentPosition;

                newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
            }
        }
    }
    private void HandleMovementInput()
    {
        if (canControl)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementSpeed = fastSpeed;
            }
            else
            {
                movementSpeed = normalSpeed;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                newPosition += (transform.forward * movementSpeed);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                newPosition += (transform.forward * (-movementSpeed));
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                newPosition += (transform.right * movementSpeed);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                newPosition += (transform.right * (-movementSpeed));
            }
            if (Input.GetKey(KeyCode.Q))
            {
                newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
            }
            if (Input.GetKey(KeyCode.E))
            {
                newRotation *= Quaternion.Euler(Vector3.up * (-rotationAmount));
            }

            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);

            float nextFieldOfView = Mathf.Lerp(cameraMain.fieldOfView, newZoom, Time.deltaTime * movementTime);

            if (nextFieldOfView > maxZoomIn && nextFieldOfView < maxZoomOut)
            {
                cameraMain.fieldOfView = nextFieldOfView;
            }
            else
            {
                if (nextFieldOfView < maxZoomIn)
                {
                    newZoom = maxZoomIn;
                }
                if (nextFieldOfView > maxZoomOut)
                {
                    newZoom = maxZoomOut;
                }
                Debug.Log("Current newZoom: " + newZoom);
            }
        }
    }
}
