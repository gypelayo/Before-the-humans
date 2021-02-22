using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMeshController : MonoBehaviour
{
    [SerializeField]
    private WheelCollider wheelCollider;

    private void Update()
    {
        Quaternion quaternion;
        Vector3 position;

        wheelCollider.GetWorldPose(out position, out quaternion);
        transform.rotation = quaternion;
        transform.position = position;
    }
}
