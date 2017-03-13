using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLightmaps : MonoBehaviour
{

    LightmapData[] lightmapData;
    private bool lightmapEnabled = true;

    void Start()
    {
        // Save reference to existing scene lightmap data.
        lightmapData = LightmapSettings.lightmaps;
    }

    public void Toggle()
    {
        if (lightmapEnabled)
        {
            // Disable lightmaps in scene by removing the lightmap data references
            LightmapSettings.lightmaps = new LightmapData[] { };
            lightmapEnabled = false;
        }
        else if (!lightmapEnabled)
        {
            // Reenable lightmap data in scene.
            LightmapSettings.lightmaps = lightmapData;
            lightmapEnabled = true;
        }
    }
}
