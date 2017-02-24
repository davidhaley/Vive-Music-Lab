using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour {

    [Space(1)]
    [Header("VISIBILITY")]
    [Space(5)]
    public bool uiVisibleOnStart;
    public float fadeSpeed = 1f;
    private CanvasGroup canvasGroup;
    private bool visible;
    private GameObject refObj;

    private void Awake()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
        {
            gameObject.AddComponent<CanvasGroup>();
        }

        canvasGroup = GetComponentInChildren<CanvasGroup>();
        refObj = gameObject;

        SetState();
    }

    private void SetState()
    {
        if (!uiVisibleOnStart)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
            visible = false;
        }
        else if (uiVisibleOnStart)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            visible = true;
        }
    }

    public void ToggleFade()
    {
        StartCoroutine(StartFade());
    }

    IEnumerator StartFade()
    {
        if (!visible)
        {
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime / fadeSpeed;
                canvasGroup.blocksRaycasts = true;
                yield return null;
            }

            visible = true;
        }
        else if (visible)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime / fadeSpeed;
                canvasGroup.blocksRaycasts = false;
                yield return null;
            }

            gameObject.SetActive(false);
            visible = false;
        }
    }
}
