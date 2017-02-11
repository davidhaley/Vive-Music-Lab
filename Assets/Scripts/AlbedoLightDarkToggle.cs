using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbedoLightDarkToggle : MonoBehaviour {

    public Material material;

    private bool lightsOn = true;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    public void toggleAlbedo()
    {
        if (lightsOn)
        {
            material.color = Color.black;
            lightsOn = false;
        }
        else if (!lightsOn)
        {
            material.color = Color.white;
            lightsOn = true;
        }
    }
}
