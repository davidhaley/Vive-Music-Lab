using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class LightShow : MonoBehaviour
{
    public bool hideOnAwake;
    public bool playOnAwake;
    public bool mainLightsOffOnAwake;

    private GameObject[] lightShowLights;
    private GameObject[] mainLights;

    private static bool mainLightsEnabled = true;
    private bool lightShowEnabled = false;
    private bool flashLightHintShown = false;

    public delegate bool LightStatus(bool status);

    public static event LightStatus MainLights;

    private void Awake()
    {
        lightShowLights = GameObject.FindGameObjectsWithTag("LightShow");
        mainLights = GameObject.FindGameObjectsWithTag("MainLights");

        if (hideOnAwake)
        {
            foreach (GameObject go in lightShowLights)
            {
                go.GetComponent<LightShowLight>().Enabled = false;
                go.GetComponent<Light>().enabled = false;
            }
        }

        if (playOnAwake)
        {
            ToggleLightShow();
        }

        if (mainLightsOffOnAwake)
        {
            ToggleMainLights();
        }
    }

    public void ToggleLightShow()
    {
        if (lightShowEnabled)
        {
            foreach (GameObject go in lightShowLights)
            {
                go.GetComponent<LightShowLight>().Enabled = false;
                go.GetComponent<LightShowLight>().StopRotate();
                go.GetComponent<Light>().enabled = false;
            }

            lightShowEnabled = false;
        }
        else if (!lightShowEnabled)
        {
            foreach (GameObject go in lightShowLights)
            {
                go.GetComponent<LightShowLight>().Enabled = true;
                go.GetComponent<LightShowLight>().StartRotate();
                go.GetComponent<Light>().enabled = true;
            }

            lightShowEnabled = true;
        }
    }

    public void ToggleMainLights()
    {
        if (mainLightsEnabled)
        {
            foreach (GameObject go in mainLights)
            {
                go.GetComponent<Light>().enabled = false;
                mainLightsEnabled = false;
            }

            if (!flashLightHintShown)
            {
                Hand hand = Player.instance.leftHand;
                if (hand != null)
                {
                    ControllerButtonHints.ShowButtonHint(hand, EVRButtonId.k_EButton_SteamVR_Touchpad);
                    ControllerButtonHints.ShowTextHint(hand, EVRButtonId.k_EButton_SteamVR_Touchpad, "Flashlight");
                    flashLightHintShown = true;
                }
            }
        }
        else if (!mainLightsEnabled)
        {
            foreach (GameObject go in mainLights)
            {
                go.GetComponent<Light>().enabled = true;
                mainLightsEnabled = true;
            }
        }
    }

    public static bool MainLightsEnabled()
    {
        return MainLights(mainLightsEnabled);
    }
}
