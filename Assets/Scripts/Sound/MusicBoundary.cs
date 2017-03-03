//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using UnityEngine.UI;

//public class MusicBoundary : MonoBehaviour {

//    public MusicController musicController;
//    public Sequencer sequencer;
//    public StatusIndicator[] statusIndicators;

//    private ButtonImageColor[] buttonImageColors;
//    private GvrAudioSource[] gvrAudioSources;


//    //When the player enters this game object's collider...
//    // If "PLAY master on collide" is enabled, play the master track
//    private void OnTriggerEnter(Collider col)
//    {
//        if (col.name == "MainCamera")
//        {
//            if (musicController != null && musicController.master != null && musicController.playMasterOnColliderEnter && !musicController.master.isPlaying)
//            {
//                musicController.master.Play();
//            }
//        }
//    }

//    //When the player exits this game object's collider...
//    // If "STOP master on collide" is enabled, stop the master track.
//    // If "STOP audio on collide" is enabled, stop any audio source that is playing.
//    private void OnTriggerExit(Collider col)
//    {
//        if (col.name == "MainCamera")
//        {
//            if (musicController != null)
//            {
//                if (musicController.master != null && musicController.stopMasterOnColliderExit && musicController.master.isPlaying)
//                {
//                    musicController.master.Stop();
//                }

//                if (musicController.gvrAudioSources != null && musicController.stopAudioOnColliderExit)
//                {
//                    foreach (GvrAudioSource gvrAudioSource in musicController.gvrAudioSources)
//                    {
//                        if (gvrAudioSource.isPlaying)
//                        {
//                            gvrAudioSource.Stop();

//                            // Change from play button to stop button if playing
//                            if (gameObject.tag == "AudioVisualizer")
//                            {
//                                gameObject.GetComponent<SwitchButtons>().Switch();
//                            }
//                        }
//                    }
//                }
//            }

//            if (statusIndicators != null)
//            {
//                foreach (StatusIndicator statusIndicator in statusIndicators)
//                {
//                    if (statusIndicator.ToggledStatus() == true)
//                    {
//                        statusIndicator.ToggleColor();
//                    }
//                }
//            }

//            //if (gameObject.tag == "LivePerformanceCollider")
//            //{
//            //    GameObject demoCanvas = GameObject.FindGameObjectWithTag("LivePerformance");

//            //    if (demoCanvas != null)
//            //    {
//            //        Button[] buttons = demoCanvas.GetComponentsInChildren<Button>();

//            //        foreach(Button button in buttons)
//            //        {
//            //            StatusIndicator statusIndicator = button.GetComponentInChildren<StatusIndicator>();
//            //            statusIndicator.ToggleColor();
//            //            Debug.Log("toggling color of status indicator on live performance booth");
//            //        }
//            //    }
//            //}

//            if (gameObject.tag == "SequencerCanvas")
//            {
//                //Stop all sequencer audio
//                if (sequencer != null)
//                {
//                    sequencer.running = false;
//                    sequencer.StopAllCoroutines();
//                }

//                buttonImageColors = FindObjectsOfType<ButtonImageColor>();

//                if (buttonImageColors != null)
//                {
//                    foreach (ButtonImageColor buttonImageColor in buttonImageColors)
//                    {
//                        if (buttonImageColor.ToggleStatus() == true)
//                        {
//                            Button[] buttons = buttonImageColor.GetComponentsInChildren<Button>();

//                            foreach (Button button in buttons)
//                            {
//                                buttonImageColor.Toggle(button, Color.white);
//                                sequencer.RemoveFromQueue(button);
//                            }
//                        }
//                    }
//                }
//            }
//        }
//    }
//}
