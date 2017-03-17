using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

//Purpose: Manage SteamVR Controller button events
public class SteamVRControllerEvents : MonoBehaviour
{
    public struct ControllerInteractionEventArgs
    {
        public uint controllerIndex;
        public float buttonPressure;
        public Vector2 touchpadAxis;
        public float touchpadAngle;
    }

    public delegate void ControllerEvent();

    //Left controller events
    public static event ControllerEvent OnLeftTriggerDown;
    public static event ControllerEvent OnLeftTriggerUp;
    public static event ControllerEvent OnLeftGripDown;
    public static event ControllerEvent OnLeftGripUp;
    public static event ControllerEvent OnLeftTouchpadDown;
    public static event ControllerEvent OnLeftTouchpadUp;
    public static event ControllerEvent OnLeftTouchpadTouch;
    public static event ControllerEvent OnLeftTouchpadRelease;
    
    //Right controller events
    public static event ControllerEvent OnRightTriggerDown;
    public static event ControllerEvent OnRightTriggerUp;
    public static event ControllerEvent OnRightGripDown;
    public static event ControllerEvent OnRightGripUp;
    public static event ControllerEvent OnRightTouchpadDown;
    public static event ControllerEvent OnRightTouchpadUp;
    public static event ControllerEvent OnRightTouchpadTouch;
    public static event ControllerEvent OnRightTouchpadRelease;

    //Any controller events
    public static event ControllerEvent OnAnyTriggerDown;

    //Buttons
    private ulong grip;
    private ulong trigger;
    private ulong touchpad;
    private ulong appMenu;
    private ulong systemMenu;

    private void Start()
    {
        grip = SteamVR_Controller.ButtonMask.Grip;
        trigger = SteamVR_Controller.ButtonMask.Trigger;
        touchpad = SteamVR_Controller.ButtonMask.Touchpad;
        appMenu = SteamVR_Controller.ButtonMask.ApplicationMenu;
        systemMenu = SteamVR_Controller.ButtonMask.System;
    }

    private void Update()
    {
        SteamVR_Controller.Device leftController = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost));
        SteamVR_Controller.Device rightController = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost));

        if (leftController != null)
        {
            if (leftController.GetHairTriggerDown())
            {
                if (OnLeftTriggerDown != null)
                {
                    OnLeftTriggerDown();
                }

                if (OnAnyTriggerDown != null)
                {
                    OnAnyTriggerDown();
                }
            }

            if (leftController.GetHairTriggerUp())
            {
                if (OnLeftTriggerUp != null)
                {
                    OnLeftTriggerUp();
                }
            }

            if (leftController.GetPressDown(grip))
            {
                if (OnLeftGripDown != null)
                {
                    OnLeftGripDown();
                }
            }

            if (leftController.GetPressUp(grip))
            {
                if (OnLeftGripUp != null)
                {
                    OnLeftGripUp();
                }
            }

            if (leftController.GetPressDown(touchpad))
            {
                if (OnLeftTouchpadDown != null)
                {
                    OnLeftTouchpadDown();
                }
            }

            if (leftController.GetPressUp(touchpad))
            {
                if (OnLeftTouchpadUp != null)
                {
                    OnLeftTouchpadUp();
                }
            }

            if (leftController.GetTouch(touchpad))
            {
                if (OnLeftTouchpadTouch != null)
                {
                    OnLeftTouchpadTouch();
                }
            }

            if (leftController.GetTouchUp(touchpad))
            {
                if (OnLeftTouchpadRelease != null)
                {
                    OnLeftTouchpadRelease();
                }
            }
        }

        if (rightController != null)
        {
            if (rightController.GetHairTriggerDown())
            {
                if (OnRightTriggerDown != null)
                {
                    OnRightTriggerDown();
                }

                if (OnAnyTriggerDown != null)
                {
                    OnAnyTriggerDown();
                }
            }

            if (rightController.GetHairTriggerUp())
            {
                if (OnRightTriggerUp != null)
                {
                    OnRightTriggerUp();
                }
            }

            if (rightController.GetPressDown(grip))
            {
                if (OnRightGripDown != null)
                {
                    OnRightGripDown();
                }
            }

            if (rightController.GetPressUp(grip))
            {
                if (OnRightGripUp != null)
                {
                    OnRightGripUp();
                }
            }

            if (rightController.GetPressDown(touchpad))
            {
                if (OnRightTouchpadDown != null)
                {
                    OnRightTouchpadDown();
                }
            }

            if (rightController.GetPressUp(touchpad))
            {
                if (OnRightTouchpadUp != null)
                {
                    OnRightTouchpadUp();
                }
            }

            if (rightController.GetTouch(touchpad))
            {
                if (OnRightTouchpadTouch != null)
                {
                    OnRightTouchpadTouch();
                }
            }

            if (rightController.GetTouchUp(touchpad))
            {
                if (OnRightTouchpadRelease != null)
                {
                    OnRightTouchpadRelease();
                }
            }
        }
    }
}
