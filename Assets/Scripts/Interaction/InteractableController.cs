using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class InteractableController : MonoBehaviour {

    private LaserPointerInteractable laserInteractable;
    private InteractableLaserEvents laserEvents;
    private Hand hand;

    private void Update()
    {
        for (int i = 0; i < Player.instance.handCount; i++)
        {
            hand = Player.instance.GetHand(i);
            laserInteractable = hand.gameObject.GetComponent<LaserPointerInteractable>();
            SteamVR_LaserPointer steamVRLaserPointer = laserInteractable.GetSteamVRLaserPointer();
            MeshRenderer laserMeshRenderer = steamVRLaserPointer.pointer.GetComponent<MeshRenderer>();

            if (laserInteractable.target != null)
            {
                if (laserMeshRenderer.enabled == false)
                {
                    laserMeshRenderer.enabled = true;
                }

                laserEvents = laserInteractable.target.GetComponent<InteractableLaserEvents>();

                if (laserEvents == null)
                {
                    laserMeshRenderer.material.color = Color.red;
                    return;
                }
                else if (laserEvents != null)
                {
                    laserMeshRenderer.material.color = Color.green;
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

                if (laserInteractable.target.name != null)
                {
                    Debug.Log(laserInteractable.target.gameObject.name);
                }
            }
            else
            {
                Debug.Log("target is null");
                laserMeshRenderer.enabled = false;
            }
        }
    }

    private void OnTriggerDown(int index)
    {
        if (laserEvents != null)
        {
            laserEvents.onTriggerDown.Invoke();
        }
    }

    private void OnTriggerUp(int index)
    {
    }

    private void OnGripDown(int index)
    {
    }

    private void OnGripUp(int index)
    {
    }

    private void OnTouchpadDown(int index)
    {
    }

    private void OnTouchpadUp(int index)
    {
    }

    private void OnTouchpadTouch(int index)
    {
    }

    private void OnTouchpadRelease(int index)
    {
    }
}
