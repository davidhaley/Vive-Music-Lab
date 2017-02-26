using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

    public GvrAudioSource[] gvrAudioSources;
    public bool stopAudioOnColliderExit;

    [Header("Sync With Master Track (Optional)")]
    public GvrAudioSource master;
    public bool playMasterOnAwake;
    public bool playMasterOnColliderEnter;
    public bool stopMasterOnColliderExit;

    [Header("Room Effect Canvas (Optional)")]
    public Text gvrRoomEffectText;

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

        foreach (GvrAudioSource gvrAudioSource in gvrAudioSources)
        {
            if (gvrAudioSource.isPlaying)
            {
                gvrAudioSource.Stop();
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
        foreach(GvrAudioSource gvrAudioSource in gvrAudioSources)
        {
            if (master != null)
            {
                gvrAudioSource.timeSamples = master.timeSamples;
            }

            if (!gvrAudioSource.isPlaying)
            {
                gvrAudioSource.Play();
            }
            else if (gvrAudioSource.isPlaying)
            {
                gvrAudioSource.Stop();
            }
        }
    }

    public void PlayAudioSource(int index)
    {
        if (master != null)
        {
            gvrAudioSources[index].timeSamples = master.timeSamples;
        }

        if (!gvrAudioSources[index].isPlaying)
        {
            gvrAudioSources[index].Play();
        }
        else if (gvrAudioSources[index].isPlaying)
        {
            gvrAudioSources[index].Stop();
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
