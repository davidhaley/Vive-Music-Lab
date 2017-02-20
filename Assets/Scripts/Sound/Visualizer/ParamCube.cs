using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {

    public AudioVisualizer audioVisualizer;
    public int band;
    public float startScale;
    public float scaleMagnitude;
    public bool useBuffer;

    void Update () {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (audioVisualizer.bandBuffer[band] * scaleMagnitude) + startScale, transform.localScale.z);
        }

        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (audioVisualizer.freqBands[band] * scaleMagnitude) + startScale, transform.localScale.z);
        }
    }
}
