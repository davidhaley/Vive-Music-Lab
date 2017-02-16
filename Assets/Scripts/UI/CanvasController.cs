using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public GameObject booth;
    private CanvasGroup canvasGroup;

    public float fadeSpeed = 1f;

    private bool visible = false;

    private void Awake()
    {
        canvasGroup = booth.GetComponentInChildren<CanvasGroup>();
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }

    public void FadeCanvas()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        if (!visible)
        {
            gameObject.SetActive(true);

            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime / fadeSpeed;
                yield return null;
            }

            visible = true;
        }
        else if (visible)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime / fadeSpeed;
                yield return null;
            }

            visible = false;
            gameObject.SetActive(false);
        }
    }
}
