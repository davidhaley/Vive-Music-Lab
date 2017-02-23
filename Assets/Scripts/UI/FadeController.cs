using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour {

    [Space(1)]
    [Header("VISIBILITY")]
    [Space(5)]
    public bool visibleOnStart;
    public float fadeSpeed = 1f;
    private CanvasGroup canvasGroup;
    private bool visible;
    private GameObject refObj;

    private void Awake()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>();
        refObj = gameObject;

        SetState();
    }

    private void SetState()
    {
        if (!visibleOnStart)
        {
            canvasGroup.alpha = 0f;
            gameObject.SetActive(false);
            visible = false;
        }
        else if (visibleOnStart)
        {
            canvasGroup.alpha = 1f;
            gameObject.SetActive(true);
            visible = true;
        }
    }

    public void ToggleFade()
    {
        if (refObj.activeSelf == false)
        {
            refObj.SetActive(true);
        }

        StartCoroutine(StartFade());
    }

    IEnumerator StartFade()
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
