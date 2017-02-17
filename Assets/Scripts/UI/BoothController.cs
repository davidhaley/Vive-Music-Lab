using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoothController : MonoBehaviour {

    public GameObject booth;
    [Space(1)]
    [Header("VISIBILITY")]
    [Space(5)]
    public float fadeSpeed = 1f;
    private CanvasGroup canvasGroup;
    private bool visible = false;

    private void Awake()
    {
        //Hide booth on awake
        canvasGroup = booth.GetComponentInChildren<CanvasGroup>();
        canvasGroup.alpha = 0f;

        FadeBooth();
    }

    public void FadeBooth()
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
