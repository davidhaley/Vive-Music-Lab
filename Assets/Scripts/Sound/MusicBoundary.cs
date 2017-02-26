using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MusicBoundary : MonoBehaviour {

    public MusicController musicController;
    public Sequencer sequencer;
    private GvrAudioSource[] gvrAudioSources;


    //When the player enters this game object's collider...
    // If "PLAY master on collide" is enabled, play the master track
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "MainCamera")
        {
            if (musicController != null && musicController.master != null && musicController.playMasterOnColliderEnter && !musicController.master.isPlaying)
            {
                musicController.master.Play();
            }
        }
    }

    //When the player exits this game object's collider...
    // If "STOP master on collide" is enabled, stop the master track.
    // If "STOP audio on collide" is enabled, stop any audio source that is playing.
    private void OnTriggerExit(Collider col)
    {
        if (col.name == "MainCamera")
        {
            if (musicController != null)
            {
                if (musicController.master != null && musicController.stopMasterOnColliderExit && musicController.master.isPlaying)
                {
                    musicController.master.Stop();
                }

                if (musicController.gvrAudioSources != null && musicController.stopAudioOnColliderExit)
                {
                    foreach (GvrAudioSource gvrAudioSource in musicController.gvrAudioSources)
                    {
                        if (gvrAudioSource.isPlaying)
                        {
                            gvrAudioSource.Stop();
                        }
                    }
                }
            }

            //Stop all sequencer audio
            if (sequencer != null)
            {
                sequencer.running = false;
                sequencer.StopAllCoroutines();
            }
        }
    }
}
