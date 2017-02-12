using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour {

    public AudioClip clip;
    private GvrAudioSource gvrAudioSource;

    private void Awake()
    {
        gvrAudioSource = gameObject.AddComponent<GvrAudioSource>();
        gvrAudioSource.clip = clip;
        gvrAudioSource.loop = false;
        gvrAudioSource.playOnAwake = false;
        gvrAudioSource.bypassRoomEffects = true;
    }

    public void Play()
    {
        gvrAudioSource.Play();
    }
}
