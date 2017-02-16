using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

    public GameObject booth;
    public GvrAudioSource[] gvrAudioSources;

    [Header("Sync With Master Track (Optional)")]
    public GvrAudioSource master;

    [Header("Room Effect Canvas (Optional)")]
    public Text gvrRoomEffectText;

    public void PlayAudioSource(GvrAudioSource audioSource)
    {
        if (master != null)
        {
            audioSource.timeSamples = master.timeSamples;
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void ToggleGVRRoomEffect()
    {
        foreach(GvrAudioSource gvrAudioSource in gvrAudioSources)
        {
            if (gvrAudioSource.bypassRoomEffects == false)
            {
                gvrAudioSource.bypassRoomEffects = true;
                gvrRoomEffectText.text = "Enable Room Effect:";
            }
            else if (gvrAudioSource.bypassRoomEffects == true)
            {
                gvrAudioSource.bypassRoomEffects = false;
                gvrRoomEffectText.text = "Disable Room Effect:";
            }
        }
    }
}
