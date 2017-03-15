using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource[] audioSources;

    [Header("Sync With Master Track (Optional)")]
    public AudioSource master;

    private void OnDisable()
    {
        StopMaster();
        StopAll();
    }

    public void PlayMaster()
    {
        if (master != null && !master.isPlaying)
        {
            master.Play();
        }
    }

    public void StopMaster()
    {
        if (master != null && master.isPlaying)
        {
            master.Stop();
        }
    }

    public void TogglePlayAll()
    {
        foreach (AudioSource audioSource in audioSources)
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
    }

    public void StopAll()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    public void TogglePlayOne(int index)
    {
        if (master != null)
        {
            audioSources[index].timeSamples = master.timeSamples;
        }

        if (!audioSources[index].isPlaying)
        {
            audioSources[index].Play();
        }
        else if (audioSources[index].isPlaying)
        {
            audioSources[index].Stop();
        }
    }

    public bool IsAnyPlaying()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.isPlaying)
            {
                return true;
            }
        }
        return false;
    }
}
