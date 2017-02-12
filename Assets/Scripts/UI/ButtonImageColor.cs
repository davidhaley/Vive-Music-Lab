using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImageColor : MonoBehaviour
{
    public MaskableGraphic foregroundImage;
    public Color toggleColor;
    public float fadeTime;

    private bool toggled = false;


    public void Toggle()
    {
        if (!toggled)
        {
            foregroundImage.CrossFadeColor(toggleColor, fadeTime * 1.2f, false, true);
            toggled = true;
        }
        else if (toggled)
        {
            foregroundImage.CrossFadeColor(Color.white, fadeTime * 1.2f, false, true);
            toggled = false;
        }
    }
}