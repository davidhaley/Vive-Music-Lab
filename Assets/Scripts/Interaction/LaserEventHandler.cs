﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace MusicLab.InteractionSystem
{
    //--------------------------------------------------------------------
    // Purpose: Enable/Disable laser pointer and invoke laser events
    //--------------------------------------------------------------------
    public class LaserEventHandler : MonoBehaviour
    {
        private void Update()
        {
            for (int i = 0; i < Player.instance.handCount; i++)
            {
                Hand hand = Player.instance.GetHand(i);

                LaserPointerInteractable laserPointer = hand.GetComponent<LaserPointerInteractable>();

                if (laserPointer != null)
                {
                    LaserEvents laserEvents = laserPointer.LaserEvents();

                    if (laserPointer.ValidLaserTarget == null)
                    {
                        laserPointer.DisableLaser();
                    }
                    else if (laserPointer.ValidLaserTarget != null)
                    {
                        laserPointer.EnableLaser();
                    }

                    if (laserEvents != null && hand.controller.GetHairTriggerDown())
                    {
                        laserEvents.onTriggerDown.Invoke();
                    }
                }
            }
        }
    }
}

