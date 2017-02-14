using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

    public GameObject booth;
    public GvrAudioSource[] gvrAudioSources;

    [Header("Sync With Master Track")]
    public GvrAudioSource master;

    [Header("Room Effect Canvas")]
    public Text gvrRoomEffectText;

    private void Awake()
    {
        if (gvrAudioSources == null)
        {
            gvrAudioSources = gameObject.GetComponents<GvrAudioSource>();
        }
    }

    public void PlayAudioSource1()
    {
        if (!gvrAudioSources[0].isPlaying)
        {
            gvrAudioSources[0].timeSamples = master.timeSamples;
            gvrAudioSources[0].Play();
        }
        else if (gvrAudioSources[0].isPlaying)
        {
            gvrAudioSources[0].timeSamples = master.timeSamples;
            gvrAudioSources[0].Stop();
        }
    }

    public void PlayAudioSource2()
    {
        if (!gvrAudioSources[1].isPlaying)
        {
            gvrAudioSources[1].timeSamples = master.timeSamples;
            gvrAudioSources[1].Play();
        }
        else if (gvrAudioSources[1].isPlaying)
        {
            gvrAudioSources[1].timeSamples = master.timeSamples;
            gvrAudioSources[1].Stop();
        }
    }
    public void PlayAudioSource3()
    {
        if (!gvrAudioSources[2].isPlaying)
        {
            gvrAudioSources[2].timeSamples = master.timeSamples;
            gvrAudioSources[2].Play();
        }
        else if (gvrAudioSources[2].isPlaying)
        {
            gvrAudioSources[2].timeSamples = master.timeSamples;
            gvrAudioSources[2].Stop();
        }
    }

    public void PlayAudioSource4()
    {
        if (!gvrAudioSources[3].isPlaying)
        {
            gvrAudioSources[3].timeSamples = master.timeSamples;
            gvrAudioSources[3].Play();
        }
        else if (gvrAudioSources[3].isPlaying)
        {
            gvrAudioSources[3].timeSamples = master.timeSamples;
            gvrAudioSources[3].Stop();
        }
    }
    public void PlayAudioSource5()
    {
        if (!gvrAudioSources[4].isPlaying)
        {
            gvrAudioSources[4].timeSamples = master.timeSamples;
            gvrAudioSources[4].Play();
        }
        else if (gvrAudioSources[4].isPlaying)
        {
            gvrAudioSources[4].timeSamples = master.timeSamples;
            gvrAudioSources[4].Stop();
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
