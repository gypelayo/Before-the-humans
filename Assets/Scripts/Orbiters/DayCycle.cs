using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public float timeRate = 1;
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.right * timeRate * Time.deltaTime);
    }
}
