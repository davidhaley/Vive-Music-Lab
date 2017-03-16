using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightActionFade : ILightAction {

    private bool ready = true;

    IEnumerator ILightAction.ModulateLight(Light light, float speed, float upperIntensityBounds, float lowerIntensityBounds)
    {
        if (ready)
        {
            ready = false;
            light.intensity = Mathf.PingPong(Time.time * speed, upperIntensityBounds);
            yield return (ready = true);
        }
    }
}
