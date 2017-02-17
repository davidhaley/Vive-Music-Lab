using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    [Header("Enable Script")]
    public bool enableScript = false;

    [Header("Strobe (Default Mode)")]
    public float strobeSpeed = 10f;
    [Range(3f,8f)] public float upperIntensityBound;
    [Range(0f, 8f)] public float lowerIntensityBound;

    [Header("Light Switch (Optional Mode)")]
    public bool lightSwitch;
    [Range(0f, 1f)]
    public float onOffSpeed;

    [Header("Color Randomizer (Optional Mode)")]
    public bool colorRandomizer;
    //public float changeColorInSeconds;

    [Header("Rotation")]
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
    }

void Update () {

        if (!enableScript && !coRoutinesStopped)
        {
            StopAllCoroutines();
            coRoutinesStopped = true;
        }
        else if (enableScript)
        {
            RotateLight();

            if (lightSwitch && toggleLightReady)
            {
                StartCoroutine("ToggleLight");
                coRoutinesStopped = false;

            }
            else if (!lightSwitch)
            {
                StartCoroutine("StrobeLight");
                coRoutinesStopped = false;
            }

            if (colorRandomizer && switchColorReady)
            {
                StartCoroutine(SwitchColor(ChangeColorInSeconds));
                coRoutinesStopped = false;
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


