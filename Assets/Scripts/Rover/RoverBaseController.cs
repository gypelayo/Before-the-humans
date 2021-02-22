using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverBaseController : MonoBehaviour
{
    public float torque = 200;
    public float maxSteerAngle = 30;
    private Rigidbody rb;

    [SerializeField]
    private Transform colliders;
    [SerializeField]
    private Transform meshes = null;
    [SerializeField]
    private List<WheelCollider> wheelColliders = null;
    [SerializeField]
    private List<GameObject> wheels;
    public bool isBrakeOn = false;
    [SerializeField]
    private float maxSpeed = 5;
    public bool isSelected = false;
    void Awake()
    {
        wheelColliders = new List<WheelCollider>();
        wheels = new List<GameObject>();
        rb = transform.GetChild(0).GetComponent<Rigidbody>();
    }

    void Start()
    {
        for (int i = 0; i < colliders.childCount; ++i)
        {
            wheelColliders.Add(colliders.transform.GetChild(i).GetComponent<WheelCollider>());
        }

        for (int i = 0; i < meshes.childCount; ++i)
        {
            wheels.Add(meshes.transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        float s = Input.GetAxis("Horizontal");

        TurnAxis(s, 3);

    }

    void FixedUpdate()
    {
        if (isSelected)
        {
            float a = Input.GetAxis("Vertical");

            Go(a);

            if (isBrakeOn)
            {
                Brake();
            }
            else
            {
                ReleaseBrake();
            }

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
    }

    /// <summary>
    /// Method to toggle brake
    /// </summary>
    public void ToggleBrakes()
    {
        isBrakeOn = !isBrakeOn;
    }

    /// <summary>
    /// Method to turn wheels by axis index
    /// </summary>
    /// <param name="steer"></param>
    /// <param name="axisIndex"></param>
    private void TurnAxis(float steer, int axisIndex)
    {
        switch (axisIndex)
        {
            case 1:
                TurnWheel(steer, wheelColliders[0], wheels[0]);
                TurnWheel(steer, wheelColliders[1], wheels[1]);
                break;

            case 2:
                TurnWheel(steer, wheelColliders[2], wheels[2]);
                TurnWheel(steer, wheelColliders[3], wheels[3]);
                break;

            case 3:
                TurnWheel(steer, wheelColliders[4], wheels[4]);
                TurnWheel(steer, wheelColliders[5], wheels[5]);
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// Method to move rover forward with acceleration
    /// </summary>
    /// <param name="acceleration"></param>
    void Go(float acceleration)
    {
        int index = 0;
        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            ApplyAccelerationToWheel(acceleration, wheelCollider, wheels[index]);
            index++;
        }
    }

    /// <summary>
    /// Method which applies acceleration to individual wheel
    /// </summary>
    /// <param name="acceleration"></param>
    /// <param name="wheelCollider"></param>
    /// <param name="wheelMesh"></param>
    private void ApplyAccelerationToWheel(float acceleration, WheelCollider wheelCollider, GameObject wheelMesh)
    {
        acceleration = Mathf.Clamp(acceleration, -1, 1);
        float thrustTorque = acceleration * torque;
        wheelCollider.motorTorque = thrustTorque;
    }

    /// <summary>
    /// Method to turn individual wheel
    /// </summary>
    /// <param name="steer"></param>
    /// <param name="wheelCollider"></param>
    /// <param name="wheelMesh"></param>
    private void TurnWheel(float steer, WheelCollider wheelCollider, GameObject wheelMesh)
    {
        steer = Mathf.Clamp(steer, -2, 2) * maxSteerAngle;
        wheelCollider.steerAngle = steer;
    }

    /// <summary>
    /// Brake method
    /// </summary>
    private void Brake()
    {
        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            wheelCollider.brakeTorque = 1000;
        }
    }

    /// <summary>
    /// Release Brake methos
    /// </summary>
    private void ReleaseBrake()
    {
        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            wheelCollider.brakeTorque = 0;
        }
    }
}
