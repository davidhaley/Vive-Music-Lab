﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLightShow : MonoBehaviour {

    private GameObject[] lightShowLights;
    private ToggleLightmaps toggleLightMaps;
    private GameObject[] gameObjects;

    private Color32 lightsOffColor = new Color32(64, 64, 64, 1);
    private Color32 lightsOnColor = Color.white;

    private bool mainLightsEnabled = true;

    private void Awake()
    {
        lightShowLights = GameObject.FindGameObjectsWithTag("LightShow");
        toggleLightMaps = GetComponent<ToggleLightmaps>();
        gameObjects = GameObject.FindGameObjectsWithTag("ToggleMaterialDarkBright");
    }

    public void ToggleLights()
    {
        if (mainLightsEnabled)
        {
            toggleLightMaps.Toggle();

            foreach (GameObject go in gameObjects)
            {
                go.GetComponent<Renderer>().material.color = lightsOffColor;
            }

            foreach (GameObject light in lightShowLights)
            {
                light.SetActive(true);
            }

            mainLightsEnabled = false;
        }
        else if (!mainLightsEnabled)
        {
            toggleLightMaps.Toggle();

            foreach (GameObject go in gameObjects)
            {
                go.GetComponent<Renderer>().material.color = lightsOnColor;
            }


            foreach (GameObject light in lightShowLights)
            {
                light.SetActive(false);
            }
        }
    }
}
