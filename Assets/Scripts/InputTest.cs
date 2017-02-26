using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {

    public void Update()
    {
        if (GvrViewer.Instance.Triggered)
        {
            Debug.Log("gvr viewer instance triggered");
        }
    }

    public void OnEnter()
    {
        Debug.Log("entered");
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    public void OnClicked()
    {
        Debug.Log("clicked");
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    public void OnExit()
    {
        Debug.Log("exit");
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
