using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

    public GameObject canvas;
    private bool visible;

    private void Awake()
    {
        canvas.gameObject.SetActive(false);
        visible = false;
    }

    public void Show()
    {
        if (visible)
        {
            canvas.gameObject.SetActive(false);
            visible = false;
        }
        else if (!visible)
        {
            canvas.gameObject.SetActive(true);
            visible = true;
        }
    }
}
