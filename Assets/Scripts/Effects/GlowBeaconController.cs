using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowBeaconController : MonoBehaviour
{
    private Light beacon;
    [SerializeField]
    private float beaconRate = 1;
    private void Start()
    {
        beacon = GetComponent<Light>();
    }

    private void Update()
    {
        beacon.intensity = (Mathf.Sin(Time.time * beaconRate) + 1.4f) / 2;
    }
}
