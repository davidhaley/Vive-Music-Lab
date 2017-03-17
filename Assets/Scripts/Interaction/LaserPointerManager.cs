using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace MusicLab.InteractionSystem
{
    public class LaserPointerManager : MonoBehaviour
    {
        private void Update()
        {
            for (int i = 0; i < Player.instance.handCount; i++)
            {
                Hand hand = Player.instance.GetHand(i);

                LaserPointerInteractable laserPointer = hand.GetComponent<LaserPointerInteractable>();

                //Disable laser if Player is teleporting or resting their hand beside their leg
                if ((hand.controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) || laserPointer != null && hand.gameObject.transform.up.y < 0.80f)
                {
                    laserPointer.DisableLaser();
                    return;
                }
                else if (laserPointer != null && hand.gameObject.transform.up.y >= 0.80f)
                {
                    laserPointer.EnableLaser();
                }
            }
        }
    }
}

