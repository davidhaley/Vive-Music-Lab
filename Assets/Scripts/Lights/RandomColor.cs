using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour {

    private bool ready = true;
    private Color color;

    public delegate void RandColor(Color color);

    public static event RandColor RandomizeColor;

    public void Randomize(float time)
    {
        if (ready)
        {
            StartCoroutine(ChangeColor(time));
        }
    }

    IEnumerator ChangeColor(float time)
    {
        ready = false;

        yield return new WaitForSeconds(time);
        Color newColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        color = newColor;
        RandomizeColor(color);

        ready = true;
    }
}
