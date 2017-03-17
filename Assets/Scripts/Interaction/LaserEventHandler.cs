using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace MusicLab.InteractionSystem
{
    public class LaserEventHandler : MonoBehaviour
    {
        private void Update()
        {
            for (int i = 0; i < Player.instance.handCount; i++)
            {
                Hand hand = Player.instance.GetHand(i);

                LaserPointerInteractable laserPointer = hand.GetComponent<LaserPointerInteractable>();
                LaserEvents laserEvents = laserPointer.LaserEvents();

                if (laserPointer != null)
                {
                    if (laserPointer.ValidLaserTarget == null)
                    {
                        laserPointer.TargetInvalidColor();
                    }
                    else if (laserPointer.ValidLaserTarget != null)
                    {
                        laserPointer.TargetValidColor();
                    }
                }

                if (laserEvents != null && hand.controller.GetHairTriggerDown())
                {
                    laserEvents.onTriggerDown.Invoke();
                }
            }
        }
    }
}

