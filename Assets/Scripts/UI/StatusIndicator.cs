using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour {

    public Color activeColor;
    public float fadeTime = 0.1f;
    public bool colorOnce;

    [Header("Accepts Two Types of Images")]
    [Space(5)]
    public RawImage rawImage;
    public MaskableGraphic image;
    private bool toggled = false;

    public void ToggleColor()
    {
        if (!toggled)
        {
            if (rawImage != null)
            {
                rawImage.CrossFadeColor(activeColor, fadeTime * 1.2f, false, true);
            }
            else if (image != null)
            {
                image.CrossFadeColor(activeColor, fadeTime * 1.2f, false, true);
            }

            toggled = true;
        }
        else if (toggled)
        {
            if (colorOnce)
            {
                return;
            }

            if (rawImage != null)
            {
                rawImage.CrossFadeColor(Color.white, fadeTime * 1.2f, false, true);
            }
            else if (image != null)
            {
                image.CrossFadeColor(Color.white, fadeTime * 1.2f, false, true);
            }

            toggled = false;
        }

    }
}
