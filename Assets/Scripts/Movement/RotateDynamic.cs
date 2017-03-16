using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDynamic : MonoBehaviour, IRotate {

    private float time;

    void IRotate.Rotate(GameObject gameObj, float xAngle, float yAngle, float zAngle, float period, float rotationSpeed)
    {
        time = time + (Time.deltaTime * rotationSpeed);
        float phase = Mathf.Sin(time / period);
        gameObj.transform.localRotation = Quaternion.Euler(new Vector3(phase * xAngle, phase * yAngle, phase * zAngle));
    }
}
