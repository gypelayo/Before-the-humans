using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RoverUIController : MonoBehaviour
{
    [SerializeField]
    private Button brakeButton;
    [SerializeField]
    private Image brakeButtonImage = null;
    [SerializeField]
    private bool brakeOn = true;
    [SerializeField]
    private RoverBaseController roverController;
    [SerializeField]
    private Text speedometer;
    [SerializeField]
    private Rigidbody roverRb;

    private void OnEnable()
    {
        roverController.isSelected = true;
    }
    private void OnDisable()
    {
        roverController.isSelected = false;
    }
    private void Start()
    {
        brakeButton.onClick.AddListener(ToggleBrakes);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleBrakes();
        }
    }
    private void FixedUpdate()
    {
        speedometer.text = Mathf.Round(roverRb.velocity.magnitude).ToString() + "m/s";
    }

    public void ToggleBrakes()
    {
        if (roverController.isBrakeOn)
        {
            roverController.ToggleBrakes();

            brakeButtonImage.color = Color.green;
        }
        else
        {
            roverController.ToggleBrakes();
            brakeButtonImage.color = Color.red;
        }
    }
}
