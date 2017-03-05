using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContaminateZone : MonoBehaviour {

    public AudioVisualizer audioVisualizer;
    public GameObject reference;

    private StatusIndicator statusIndicator;
    private ParamCubeScale paramCubeScale;
    private BoxCollider boxCollider;
    private bool lightsOn;

    private void Awake()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        boxCollider.enabled = true;

        statusIndicator = gameObject.GetComponent<StatusIndicator>();
        statusIndicator.image.CrossFadeAlpha(0f, 0f, false);

        lightsOn = true;
    }

    private void Update()
    {
        if (!lightsOn && paramCubeScale != null)
        {
            paramCubeScale.enabled = true;
        }
        else if (lightsOn && paramCubeScale != null)
        {
            paramCubeScale.enabled = false;
        }
    }

    public void ToggleHidden()
    {
        if (!lightsOn)
        {
            statusIndicator.image.CrossFadeAlpha(0f, 0f, false);
            boxCollider.enabled = false;
            lightsOn = true;
        }
        else if (lightsOn)
        {
            statusIndicator.image.CrossFadeAlpha(100f, 0f, false);
            boxCollider.enabled = true;
            lightsOn = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Contaminated")
        {
            statusIndicator = gameObject.GetComponent<StatusIndicator>();
            statusIndicator.image.CrossFadeColor(statusIndicator.activeColor, statusIndicator.fadeTime * 1.2f, false, false);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Contaminated")
        {
            paramCubeScale = col.gameObject.GetComponent<ParamCubeScale>();
            paramCubeScale.audioVisualizer = audioVisualizer;
            paramCubeScale.band = 1;
            paramCubeScale.startScale = 0.75f;
            paramCubeScale.scaleMagnitude = 2f;
            paramCubeScale.useBuffer = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Contaminated")
        {
            paramCubeScale = col.gameObject.GetComponent<ParamCubeScale>();
            paramCubeScale.audioVisualizer = null;

            gameObject.GetComponent<StatusIndicator>().ToggleColor();
        }
    }
}
