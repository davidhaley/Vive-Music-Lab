using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModulationContaminateHint : MonoBehaviour
{
    private StatusIndicator statusIndicator;
    private bool lightsOn;

    private void Awake()
    {
        statusIndicator = gameObject.GetComponent<StatusIndicator>();
        statusIndicator.image.CrossFadeAlpha(0f, 0f, false);
        statusIndicator.image.CrossFadeColor(statusIndicator.activeColor, statusIndicator.fadeTime * 1.2f, false, false);
        lightsOn = true;
    }

    public void ToggleHidden()
    {
        if (!lightsOn)
        {
            statusIndicator.image.CrossFadeAlpha(0f, 0f, false);
            lightsOn = true;
        }
        else if (lightsOn)
        {
            statusIndicator.image.CrossFadeAlpha(100f, 0f, false);
            lightsOn = false;
        }
    }
}
