using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour {

    public Color activeColor;
    public float fadeTime = 0.1f;
    public bool colorOnce;

    private MaskableGraphic foregroundImage;
    private bool toggled = false;
    private bool colored = false;

    private void Awake()
    {
        foregroundImage = GetComponent<Image>();
    }

    public void ToggleColor()
    {
        if (!toggled)
        {
            foregroundImage.CrossFadeColor(activeColor, fadeTime * 1.2f, false, true);
            toggled = true;
        }
        else if (toggled)
        {
            if (colorOnce)
            {
                return;
            }

            foregroundImage.CrossFadeColor(Color.white, fadeTime * 1.2f, false, true);
            toggled = false;
        }
    }
}
