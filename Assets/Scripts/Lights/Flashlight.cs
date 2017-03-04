using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Flashlight : MonoBehaviour {

    private Hand hand;
    private Light flashLight;
    private ControllerHints controllerHints;
    private bool on = false;

    private void OnEnable()
    {
        SteamVRControllerEvents.OnLeftTouchpadDown += OnLeftTouchpadDown;
        LightShow.MainLights += MainLightsStatus;
    }

    private void Awake()
    {
        flashLight = GetComponent<Light>();
        controllerHints = FindObjectOfType<ControllerHints>();

        if (flashLight.enabled)
        {
            flashLight.enabled = false;
        }
    }

    private void Update()
    {
        //If flashlight is on, update, otherwise don't bother
        if (on)
        {
            hand = Player.instance.leftHand;
            gameObject.transform.SetParent(hand.transform);
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.rotation = hand.transform.rotation;
        }
    }

    public void ToggleFlashLight()
    {
        if (!on)
        {
            flashLight.enabled = true;
            on = true;
            controllerHints.DisableHints();
        }
        else if (on)
        {
            flashLight.enabled = false;
            on = false;
        }
    }

    private void OnLeftTouchpadDown()
    {
        ToggleFlashLight();
    }

    private bool MainLightsStatus(bool status)
    {
        Debug.Log("lights are... " + status);
        return status;
    }
}
