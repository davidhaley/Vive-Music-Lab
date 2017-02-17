using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sequencer : MonoBehaviour {

    public GameObject kick;
    public GameObject snare;
    public GameObject hat;

    private Button[] kicks;
    private Button[] snares;
    private Button[] hats;

    public Sequencer(Button[] kicks, Button[] snares, Button[] hats)
    {
        this.kicks = kicks;
        this.snares = snares;
        this.hats = hats;
    }

    private void Awake()
    {
        kicks = kick.GetComponentsInChildren<Button>();
        snares = snare.GetComponentsInChildren<Button>();
        hats = hat.GetComponentsInChildren<Button>();

        foreach(Button kick in kicks)
        {
            kick.onClick.AddListener(() => { myFunctionForOnClickEvent(); });  // <-- you assign a method to the button OnClick event here
            kick.onClick.AddListener(() => { myAnotherFunctionForOnClickEvent(); }); // <-- you can assign multiple methods
        }
    }

    void myFunctionForOnClickEvent()
    {
        Debug.Log("function 1");
    }

    void myAnotherFunctionForOnClickEvent()
    {
        Debug.Log("function 2");
    }
}

