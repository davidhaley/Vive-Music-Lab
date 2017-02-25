using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

    public GvrAudioSource[] gvrAudioSources;

    [Header("Sync With Master Track (Optional)")]
    public GvrAudioSource master;

    [Header("Room Effect Canvas (Optional)")]
    public Text gvrRoomEffectText;

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
                if (master != null)
                {
                    master.Play();
                }

                gvrAudioSource.Play();
            }
            else if (gvrAudioSource.isPlaying)
            {
                if (master != null)
                {
                    master.Stop();
                }

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
            master.Play();
            gvrAudioSources[index].Play();
        }
        else if (gvrAudioSources[index].isPlaying)
        {
            master.Stop();
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
