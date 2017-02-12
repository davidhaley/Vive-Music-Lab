using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLightShow : MonoBehaviour {

    public GameObject[] mainLights;
    public GameObject[] lightShowLights;
    private bool mainLightsEnabled = true;

    private void Awake()
    {
        mainLights = GameObject.FindGameObjectsWithTag("MainLights");
        lightShowLights = GameObject.FindGameObjectsWithTag("LightShow");

        foreach (GameObject light in lightShowLights)
        {
            light.SetActive(false);
        }
    }

    public void ToggleLights()
    {
        if (mainLightsEnabled)
        {
            foreach (GameObject light in mainLights)
            {
                light.GetComponent<Light>().enabled = false;
            }

            foreach (GameObject light in lightShowLights)
            {
                light.SetActive(true);
            }

            mainLightsEnabled = false;
        }
        else if (!mainLightsEnabled)
        {
            foreach (GameObject light in mainLights)
            {
                light.GetComponent<Light>().enabled = true;
            }

            foreach (GameObject light in lightShowLights)
            {
                light.SetActive(false);
            }

            mainLightsEnabled = true;
        }
    }
}
