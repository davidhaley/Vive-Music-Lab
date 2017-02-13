using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

    public GameObject booth;
    public GvrAudioSource[] audioSources;

    private void Awake()
    {
        if (audioSources == null)
        {
            audioSources = gameObject.GetComponents<GvrAudioSource>();
        }
    }

    public void PlayAudioSource1()
    {
        if (!audioSources[0].isPlaying)
        {
            audioSources[0].Play();
        }
        else if (audioSources[0].isPlaying)
        {
            audioSources[0].Stop();
        }
    }

    public void PlayAudioSource2()
    {
        if (!audioSources[1].isPlaying)
        {
            audioSources[1].Play();
        }
        else if (audioSources[1].isPlaying)
        {
            audioSources[1].Stop();
        }
    }
    public void PlayAudioSource3()
    {
        if (!audioSources[2].isPlaying)
        {
            audioSources[2].Play();
        }
        else if (audioSources[2].isPlaying)
        {
            audioSources[2].Stop();
        }
    }

    public void PlayAudioSource4()
    {
        if (!audioSources[3].isPlaying)
        {
            audioSources[3].Play();
        }
        else if (audioSources[3].isPlaying)
        {
            audioSources[3].Stop();
        }
    }
    public void PlayAudioSource5()
    {
        if (!audioSources[4].isPlaying)
        {
            audioSources[4].Play();
        }
        else if (audioSources[4].isPlaying)
        {
            audioSources[4].Stop();
        }
    }
}
