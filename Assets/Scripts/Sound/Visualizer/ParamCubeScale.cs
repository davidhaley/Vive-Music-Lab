using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCubeScale : ParamCube {

    protected override void Modulate(float[] audio)
    {
        transform.localScale = new Vector3(transform.localScale.x, (audio[band] * scaleMagnitude) + startScale, transform.localScale.z);
        Color color = new Color(audio[band], audio[band], audio[band]);
        material.SetColor("_EmissionColor", color);
        material.EnableKeyword("_EMISSION");

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(audio[band]);

        material.SetColor("_EmissionColor", finalColor);
    }
}
