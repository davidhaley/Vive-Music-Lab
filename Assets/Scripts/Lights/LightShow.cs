using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShow : MonoBehaviour
{

    public bool hideOnAwake;
    public bool playOnAwake;
    public bool mainLightsOffOnAwake;

    private GameObject[] lightShowLights;
    private GameObject[] mainLights;
    private GameObject[] gameObjects;

    private bool mainLightsEnabled = true;
    private bool lightShowEnabled = false;

    private void Awake()
    {
        lightShowLights = GameObject.FindGameObjectsWithTag("LightShow");
        mainLights = GameObject.FindGameObjectsWithTag("MainLights");

        if (hideOnAwake)
        {
            foreach (GameObject go in lightShowLights)
            {
                go.GetComponent<LightController>().enableScript = false;
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
                go.GetComponent<LightController>().enableScript = false;
                go.GetComponent<Light>().enabled = false;
            }

            lightShowEnabled = false;
        }
        else if (!lightShowEnabled)
        {
            foreach (GameObject go in lightShowLights)
            {
                go.GetComponent<LightController>().enableScript = true;
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
            }
        }
        else if (!mainLightsEnabled)
        {
            foreach (GameObject go in mainLights)
            {
                go.GetComponent<Light>().enabled = true;
            }
        }
    }
}
