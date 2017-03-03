using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeButton : MonoBehaviour {

    //public Image backgroundImage;
    public MaskableGraphic foregroundImage;
    public MaskableGraphic backgroundImage;

    public float fadeTime = 1.2f;
    public bool faded = false;

    public void Fade()
    {
        backgroundImage.CrossFadeAlpha(0f, fadeTime * 1.2f, false);
        foregroundImage.CrossFadeAlpha(0f, fadeTime * 1.2f, false);
        faded = true;
    }
}