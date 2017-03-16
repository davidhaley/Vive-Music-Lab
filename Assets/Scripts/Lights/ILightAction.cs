using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ILightAction
{
    IEnumerator ModulateLight(Light light, float speed, float upperIntensityBounds, float lowerIntensityBounds);
}
