using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotate {

    void Rotate(GameObject gameObject, float xAngle, float yAngle, float zAngle, float period, float rotationSpeed);

}
