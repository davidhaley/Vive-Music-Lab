using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    private GameObject[] gameObjects;

	// Use this for initialization
	void Awake () {
        gameObjects = GameObject.FindGameObjectsWithTag("StageAudioSource");
    }
	
    public void ToggleAudio()
    {
        foreach(GameObject go in gameObjects)
        {
            GvrAudioSource audioSource = go.GetComponent<GvrAudioSource>();

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }
    }
}
