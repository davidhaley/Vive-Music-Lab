using UnityEngine;
using System.Collections;

public class BakedLightsController : MonoBehaviour
{

    //reference to existing scene lightmap data.
    LightmapData[] lightmap_data;
    private bool lightMapEnabled = true;

    // Use this for initialization
    void Start()
    {
        // Save reference to existing scene lightmap data.
        lightmap_data = LightmapSettings.lightmaps;
    }

    public void toggleLightmaps()
    {
        if (lightMapEnabled)
        {
            // Disable lightmaps in scene by removing the lightmap data references
            LightmapSettings.lightmaps = new LightmapData[] { };
            lightMapEnabled = false;
        }
        else if (!lightMapEnabled)
        {
            // Reenable lightmap data in scene.
            LightmapSettings.lightmaps = lightmap_data;
            lightMapEnabled = true;
        }
    }
}