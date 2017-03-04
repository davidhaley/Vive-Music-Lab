using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LaserEventHandler : MonoBehaviour {

    private LaserPointerInteractable laserPointerInteractable;
    private bool leftTriggerDown;
    private bool rightTriggerDown;

    private void OnEnable()
    {
        SteamVRControllerEvents.OnLeftTriggerDown += OnLeftTriggerDown;
        SteamVRControllerEvents.OnRightTriggerDown += OnRightTriggerDown;
    }
    private void OnDisable()
    {
        SteamVRControllerEvents.OnLeftTriggerDown -= OnLeftTriggerDown;
        SteamVRControllerEvents.OnRightTriggerDown -= OnRightTriggerDown;
    }

    private void Update()
    {
        Hand leftHand = Player.instance.leftHand;
        Hand rightHand = Player.instance.rightHand;

        LaserPointerInteractable leftLaserPointer = leftHand.GetComponent<LaserPointerInteractable>();
        LaserPointerInteractable rightLaserPointer = rightHand.GetComponent<LaserPointerInteractable>();

        if (leftLaserPointer.laserEvents != null && leftTriggerDown)
        {
            leftLaserPointer.laserEvents.onTriggerDown.Invoke();
            leftTriggerDown = false;
        }

        if (rightLaserPointer.laserEvents != null && rightTriggerDown)
        {
            rightLaserPointer.laserEvents.onTriggerDown.Invoke();
            rightTriggerDown = false;
        }
    }

    private void OnLeftTriggerDown()
    {
        leftTriggerDown = true;
    }
    private void OnRightTriggerDown()
    {
        rightTriggerDown = true;
    }
}
