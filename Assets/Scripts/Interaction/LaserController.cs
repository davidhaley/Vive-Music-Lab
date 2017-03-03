using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

//Purpose: Use the controller laser to find objects with laser events and send those events controller button presses
public class LaserController : MonoBehaviour {

    private LaserEvents laserEvents;
    [HideInInspector]
    public Hand hand;

    private void Update()
    {
        for (int i = 0; i < Player.instance.handCount; i++)
        {
            hand = Player.instance.GetHand(i);

            LaserPointerInteractable laserInteractable = hand.gameObject.GetComponent<LaserPointerInteractable>();
            MeshRenderer laserRenderer = laserInteractable.GetLaserRenderer();

            //Disable the controller laser if target is not valid
            if (laserInteractable.validTarget == null)
            {
                laserRenderer.enabled = false;
                return;
            }
            else if (laserInteractable.validTarget != null)
            {
                if (laserRenderer.enabled == false)
                {
                    laserRenderer.enabled = true;
                }

                laserEvents = laserInteractable.validTarget.GetComponent<LaserEvents>();

                //If the target is valid but does not have laser events, color the laser red
                if (laserEvents == null)
                {
                    laserRenderer.material.color = Color.red;
                    return;
                }
                else if (laserEvents != null)
                {
                    laserRenderer.material.color = Color.green;
                }

                if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
                {
                    OnTriggerDown(i);
                }

                if (hand.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
                {
                    OnTriggerUp(i);
                }

                if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
                {
                    OnGripDown(i);
                }

                if (hand.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_Grip))
                {
                    OnGripUp(i);
                }

                if (hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
                {
                    OnTouchpadDown(i);
                }

                if (hand.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
                {
                    OnTouchpadUp(i);
                }

                if (hand.controller.GetTouchDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
                {
                    OnTouchpadTouch(i);
                }

                if (hand.controller.GetTouchUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
                {
                    OnTouchpadRelease(i);
                }
            }
        }
    }

    private void OnTriggerDown(int index)
    {
        laserEvents.onTriggerDown.Invoke();
    }

    private void OnTriggerUp(int index)
    {
        laserEvents.onTriggerUp.Invoke();
    }

    private void OnGripDown(int index)
    {
        laserEvents.onGripDown.Invoke();
    }

    private void OnGripUp(int index)
    {
        laserEvents.onGripUp.Invoke();
    }

    private void OnTouchpadDown(int index)
    {
        laserEvents.onTouchpadDown.Invoke();
    }

    private void OnTouchpadUp(int index)
    {
        laserEvents.onTouchpadUp.Invoke();
    }

    private void OnTouchpadTouch(int index)
    {
        laserEvents.onTouchpadTouch.Invoke();
    }

    private void OnTouchpadRelease(int index)
    {
        laserEvents.onTouchpadRelease.Invoke();
    }
}
