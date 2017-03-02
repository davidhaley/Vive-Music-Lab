using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class LightController : MonoBehaviour
{

    //This becomes enabled when the canvas button is selected
    [HideInInspector]
    public bool enableScript = false;

    [Header("MODES")]
    [Space(5)]

    [Header("Strobe")]
    [Space(3)]
    public bool strobe;
    public float strobeSpeed = 10f;
    [Range(3f, 8f)]
    public float upperIntensityBound;
    [Range(0f, 8f)]
    public float lowerIntensityBound;
    [Space(5)]

    [Header("Light Switch")]
    [Space(3)]
    public bool lightSwitch;
    [Range(0f, 1f)]
    public float onOffSpeed;
    [Space(5)]

    [Header("Light Audio Visualizer")]
    [Space(3)]
    public AudioVisualizer audioVisualizer;
    public bool lightAudioVisualizer;
    [Range(0, 7)]
    public int band;
    [Range(0f, 8f)]
    public float minIntensity = 0f;
    [Range(0f, 8f)]
    public float maxIntensity = 8f;
    public float scaleMagnitude = 1f;
    [Space(5)]


    [Header("OPTIONS")]
    [Space(5)]

    [Header("Color Randomizer")]
    [Space(3)]
    public bool colorRandomizer;
    public float changeColorInSeconds;
    [Space(5)]

    [Header("Rotation")]
    [Space(3)]
    public bool rotate;
    public float rotationSpeed;

    private Light lightObj;
    private Color color;

    //State Variables
    private bool toggleLightReady = true;
    private bool switchColorReady = true;
    private bool coRoutinesStopped;
    private float onOff;

    public float xAngle;
    public float yAngle;
    public float zAngle;
    public float period;
    private float time;

    private void Awake()
    {
        lightObj = this.gameObject.GetComponent<Light>();

        if (lightAudioVisualizer)
        {
            lightSwitch = false;
            colorRandomizer = false;
            strobe = false;
        }
    }

    void Update()
    {

        if (!enableScript && !coRoutinesStopped)
        {
            StopAllCoroutines();
            coRoutinesStopped = true;
        }
        else if (enableScript)
        {
            RotateLight();

            if (lightSwitch && toggleLightReady && !strobe)
            {
                StartCoroutine("ToggleLight");
                coRoutinesStopped = false;

            }
            else if (!lightSwitch && !lightAudioVisualizer && strobe)
            {
                StartCoroutine("StrobeLight");
                coRoutinesStopped = false;
            }

            if (colorRandomizer && switchColorReady)
            {
                StartCoroutine(SwitchColor(ChangeColorInSeconds));
                coRoutinesStopped = false;
            }

            if (lightAudioVisualizer)
            {
                lightObj.intensity = ((audioVisualizer.audioBandBuffer[band] * scaleMagnitude) * (maxIntensity - minIntensity) + minIntensity);
            }
        }
    }

    public float ChangeColorInSeconds { get; set; }

    private void RotateLight()
    {
        time = time + (Time.deltaTime * rotationSpeed);
        float phase = Mathf.Sin(time / period);
        transform.localRotation = Quaternion.Euler(new Vector3(phase * xAngle, phase * yAngle, phase * zAngle));
    }

    IEnumerator ToggleLight()
    {
        toggleLightReady = false;

        onOff = Mathf.Lerp(0f, 1f, 0f);

        if (onOff == 1 || onOff == 0)
        {
            yield return new WaitForSeconds(onOffSpeed);
            lightObj.enabled = !lightObj.enabled;
            toggleLightReady = true;
        }
    }

    IEnumerator StrobeLight()
    {
        lightObj.intensity = Mathf.PingPong(Time.time * strobeSpeed, upperIntensityBound);
        yield return null;
    }

    IEnumerator SwitchColor(float changeColorInSeconds)
    {
        switchColorReady = false;
        yield return new WaitForSeconds(changeColorInSeconds);
        color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        lightObj.color = color;
        switchColorReady = true;
    }
}


