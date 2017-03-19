using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShowLight : MonoBehaviour
{
    //---------------------------------------------------------
    //Light mode fade over time or strobe (on/off switch)
    //---------------------------------------------------------
    [Header("Strobe (Fade Default)")]
    public bool strobe;
    public float speed = 3f;
    [Range(2f, 8f)]     public float upperIntensityBounds = 8f;
    [Range(0.5f, 8f)]   public float lowerIntensityBounds = 1f;
    [Space(15)]

    //---------------------------------------------------------
    //Light intensity modulates by audio amplitude
    //---------------------------------------------------------
    [Space(15)]
    public AudioVisualizer audioVisualizer;
    public bool visualize;
    public float scaleMagnitude = 1f;
    [Range(0, 7)]      public int band;
    [Range(0f, 8f)]    public float minIntensity = 0f;
    [Range(0f, 8f)]    public float maxIntensity = 8f;
    [Space(15)]

    //---------------------------------------------------------
    //Light rotates over time
    //---------------------------------------------------------
    [Header("Rotation")]
    [Space(15)]
    private IRotate rotateType = new RotateDynamic();
    [Range(-360f, 360f)] public float xAngle;
    [Range(-360f, 360f)] public float yAngle;
    [Range(-360f, 360f)] public float zAngle;
    [Range(0.10f, 8f)]   public float period = 1f;
    public float rotationSpeed;
    private bool rotate = false;
    [Space(15)]

    //---------------------------------------------------------
    //Change color of light to a random color at fixed time intervals
    //---------------------------------------------------------
    [Header("Randomize Color")]
    [Space(15)]
    public bool colorRandomizer;
    public float randomizeTime;

    private ILightAction lightAction;
    private RandomColor randomColor;
    private Light lightObj;
    private Color color;
    private bool coRoutinesStopped;
    private bool lightEnabled;

    private void OnEnable()
    {
        RandomColor.RandomizeColor += SetRandColor;
    }

    private void OnDisable()
    {
        RandomColor.RandomizeColor -= SetRandColor;
    }

    private void Awake()
    {
        lightObj = this.gameObject.GetComponent<Light>();

        lightAction = GetLightAction();

        if (visualize)
        {
            strobe = colorRandomizer = false;
        }
    }

    void Update()
    {
        if (!Enabled && !coRoutinesStopped)
        {
            StopAllCoroutines();
            coRoutinesStopped = true;
        }

        if (!visualize)
        {
            lightAction = GetLightAction();
            StartCoroutine(lightAction.ModulateLight(lightObj, speed, upperIntensityBounds, lowerIntensityBounds));
        }
        else if (visualize)
        {
            lightObj.intensity = ((audioVisualizer.audioBandBuffer[band] * scaleMagnitude) * (maxIntensity - minIntensity) + minIntensity);
        }

        if (rotate)
        {
            rotateType.Rotate(gameObject, xAngle, yAngle, zAngle, period, rotationSpeed);
        }

        if (colorRandomizer)
        {
            if (gameObject.GetComponent<RandomColor>() == null)
            {
                randomColor = gameObject.AddComponent<RandomColor>();
            }

            randomColor.Randomize(randomizeTime);
        }
    }

    public void StartRotate()
    {
        rotate = true;
    }

    public void StopRotate()
    {
        rotate = false;
    }

    public bool Enabled
    {
        get { return lightEnabled; }
        set
        {
            lightEnabled = value;
            //Coroutines allowed when light is enabled
            coRoutinesStopped = false;
        }
    }

    private void SetRandColor(Color color)
    {
        lightObj.color = color;
    }

    private ILightAction GetLightAction()
    {
        if (strobe)
        {
            lightAction = new LightActionStrobe();
        }
        else if (!strobe)
        {
            lightAction = new LightActionFade();
        }

        return lightAction;
    }
}


