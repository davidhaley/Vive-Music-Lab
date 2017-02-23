using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothController : MonoBehaviour {

    public FadeController fadeController;

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "MainCamera")
        {
            fadeController.ToggleFade();
        }
    }
}
