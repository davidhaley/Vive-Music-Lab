using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour {

    private GameObject fogMachine;
    private bool fogEnabled;

	// Use this for initialization
	void Awake() {
        fogMachine = GameObject.FindGameObjectWithTag("FogMachine");
        fogMachine.SetActive(false);
        Debug.Log(fogMachine.activeSelf);
	}
	
	public void Toggle()
    {
        if (!fogEnabled)
        {
            fogMachine.gameObject.SetActive(true);
            fogEnabled = true;
        }
        else if (fogEnabled)
        {
            fogMachine.gameObject.SetActive(false);
            fogEnabled = false;
        }
    }
}
