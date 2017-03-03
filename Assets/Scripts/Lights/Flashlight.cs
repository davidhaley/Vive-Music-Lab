using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Flashlight : MonoBehaviour {

    private Hand hand;
    private Light flashLight;
    private ControllerHints controllerHints;
    private bool on = false;

    private void Awake()
    {
        flashLight = GetComponent<Light>();
        controllerHints = FindObjectOfType<ControllerHints>();

        if (flashLight.enabled)
        {
            flashLight.enabled = false;
        }
    }

    private void Start()
    {
        hand = Player.instance.leftHand;
        gameObject.transform.SetParent(hand.transform);
        gameObject.transform.localPosition = Vector3.zero;
    }

    private void Update()
    {
        gameObject.transform.rotation = hand.transform.rotation;

        if (hand.controller != null && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
        {
            ToggleFlashLight();
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
}
