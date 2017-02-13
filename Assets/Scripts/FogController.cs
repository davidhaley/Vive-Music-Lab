using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour {

    private ParticleSystem fogParticleSystem;
    private bool fogEnabled;

	void Awake() {
        fogParticleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        fogParticleSystem.gameObject.SetActive(false);
        fogEnabled = false;
	}
	
	public void Toggle()
    {
        if (!fogEnabled)
        {
            fogParticleSystem.gameObject.SetActive(true);
            fogEnabled = true;
        }
        else if (fogEnabled)
        {
            fogParticleSystem.gameObject.SetActive(false);
            fogEnabled = false;
        }
    }
}
