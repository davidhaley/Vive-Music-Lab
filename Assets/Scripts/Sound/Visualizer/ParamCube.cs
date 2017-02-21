using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {

    public AudioVisualizer audioVisualizer;
    public int band;
    public float startScale;
    public float scaleMagnitude;
    public bool useBuffer;

    private Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    void Update () {
        if (useBuffer)
        {
            Modulate(audioVisualizer.audioBandBuffer);
        }

        if (!useBuffer)
        {
            Modulate(audioVisualizer.audioBand);
        }
    }

    private void Modulate(float[] audio)
    {
        transform.localScale = new Vector3(transform.localScale.x, (audio[band] * scaleMagnitude) + startScale, transform.localScale.z);
        Color color = new Color(audio[band], audio[band], audio[band]);
        material.SetColor("_EmissionColor", color);
    }
}
