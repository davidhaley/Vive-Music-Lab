using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDemoCanvas : MonoBehaviour {

    public GameObject canvas;
    private bool visible;

    private void Awake()
    {
        canvas.SetActive(false);
        visible = false;
    }

    public void Show()
    {
        if (visible)
        {
            canvas.SetActive(false);
            visible = false;
        }
        else if (!visible)
        {
            canvas.SetActive(true);
            visible = true;
        }
    }
}
