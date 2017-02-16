﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeButton : MonoBehaviour {

    public Image backgroundImage;
    public MaskableGraphic foregroundImage;

    public float fadeTime = 1.2f;
    public bool faded = false;

    public void Update()
    {
        if (faded)
        {
            backgroundImage.fillAmount -= 1.0f / fadeTime * Time.deltaTime;
        }
    }

    public void Fade()
    {
        foregroundImage.CrossFadeColor(Color.black, fadeTime * 1.2f, false, true);
        faded = true;
    }
}