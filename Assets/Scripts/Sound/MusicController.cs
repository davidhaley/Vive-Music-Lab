using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{

    public AudioSource[] audioSources;
    public bool stopAudioOnColliderExit;

    [Header("Sync With Master Track (Optional)")]
    public AudioSource master;
    public bool playMasterOnAwake;
    public bool playMasterOnColliderEnter;
    public bool stopMasterOnColliderExit;

    [Header("Room Effect Canvas (Optional)")]
    public Text roomEffectText;

    private void Awake()
    {
        if (playMasterOnAwake && master != null)
        {
            master.playOnAwake = true;
        }
        else if (!playMasterOnAwake && master != null)
        {
            master.playOnAwake = false;
        }
    }

    private void OnDisable()
    {
        if (master != null && master.isPlaying)
        {
            master.Stop();
        }

        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    public void PlayMaster()
    {
        if (master != null && master.isPlaying == false)
        {
            master.Play();
        }
    }

    public void StopMaster()
    {
        if (master != null && master.isPlaying == true)
        {
            master.Stop();
        }
    }

    public void PlayAudioSources()
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

    public void PlayAudioSource(int index)
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

    public void ToggleGVRRoomEffect()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.bypassEffects == false)
            {
                audioSource.bypassEffects = true;
                roomEffectText.text = "Enable Room Effect:";
            }
            else if (audioSource.bypassEffects == true)
            {
                audioSource.bypassEffects = false;
                roomEffectText.text = "Disable Room Effect:";
            }
        }
    }

    public bool IsPlaying()
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
