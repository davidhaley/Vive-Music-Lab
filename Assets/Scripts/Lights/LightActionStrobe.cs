using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightActionStrobe : ILightAction {

    private bool ready = true;

    IEnumerator ILightAction.ModulateLight(Light light, float speed, float upperIntensityBounds, float lowerIntensityBounds)
    {
        if (ready)
        {
            ready = false;
            float onOff = Mathf.Lerp(0f, 1f, 0f);

            if (onOff == 1 || onOff == 0)
            {
                yield return new WaitForSeconds(speed);
                light.enabled = !light.enabled;
                ready = true;
            }
        }
    }
}
