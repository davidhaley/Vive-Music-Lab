using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Valve.VR.InteractionSystem;

//Purpose: Manage SteamVR Controller button events
public class SteamVRControllerEvents : MonoBehaviour
{
    public struct ControllerEventArgs
    {
        public int deviceIndex;
        public String handOrientation;
        public Vector2 touchpadAxis;
        public float touchpadAngle;
    }

    public delegate void ControllerEvent(ControllerEventArgs e);

    //Controller events
    public static event ControllerEvent OnTriggerDown;
    public static event ControllerEvent OnTriggerUp;
    public static event ControllerEvent OnGripDown;
    public static event ControllerEvent OnGripUp;
    public static event ControllerEvent OnTouchpadDown;
    public static event ControllerEvent OnTouchpadUp;
    public static event ControllerEvent OnTouchpadTouch;
    public static event ControllerEvent OnTouchpadRelease;

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
        for (int i = 0; i < Player.instance.handCount; i++)
        {
            if (Player.instance.hands[i].controller == null)
            {
                return;
            }

            //----------
            // Trigger
            //----------
            if (Player.instance.hands[i].controller.GetHairTriggerDown())
            {
                if (OnTriggerDown != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e.deviceIndex = i;
                    OnTriggerDown(e);
                }
            }

            if (Player.instance.hands[i].controller.GetHairTriggerUp())
            {
                if (OnTriggerUp != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e.deviceIndex = i;
                    OnTriggerUp(e);
                }
            }

            //----------
            // Grip
            //----------

            if (Player.instance.hands[i].controller.GetPressDown(grip))
            {
                if (OnGripDown != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e.deviceIndex = i;
                    OnGripDown(e);
                }
            }

            if (Player.instance.hands[i].controller.GetPressUp(grip))
            {
                if (OnGripUp != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e.deviceIndex = i;
                    OnGripUp(e);
                }
            }

            if (Player.instance.hands[i].controller.GetPressUp(grip))
            {
                if (OnGripUp != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e.deviceIndex = i;
                    OnGripUp(e);
                }
            }

            //----------
            // Touchpad
            //----------

            if (Player.instance.hands[i].controller.GetPressDown(touchpad))
            {
                if (OnTouchpadDown != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e.deviceIndex = i;
                    e.touchpadAxis = Player.instance.hands[i].controller.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
                    e.touchpadAngle = CalculateTouchpadAxisAngle(e.touchpadAxis);
                    e.handOrientation = GetHandOrientation(Player.instance.hands[i].controller.index);
                    OnTouchpadDown(e);
                }
            }

            if (Player.instance.hands[i].controller.GetPressUp(touchpad))
            {
                if (OnTouchpadUp != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e.deviceIndex = i;
                    e.touchpadAxis = Player.instance.hands[i].controller.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
                    e.touchpadAngle = CalculateTouchpadAxisAngle(e.touchpadAxis);
                    OnTouchpadUp(e);
                }
            }

            if (Player.instance.hands[i].controller.GetTouch(touchpad))
            {
                if (OnTouchpadTouch != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e.deviceIndex = i;
                    e.touchpadAxis = Player.instance.hands[i].controller.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
                    e.touchpadAngle = CalculateTouchpadAxisAngle(e.touchpadAxis);
                    OnTouchpadTouch(e);
                }
            }

            if (Player.instance.hands[i].controller.GetTouchUp(touchpad))
            {
                if (OnTouchpadRelease != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e.deviceIndex = i;
                    e.touchpadAxis = Player.instance.hands[i].controller.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
                    e.touchpadAngle = CalculateTouchpadAxisAngle(e.touchpadAxis);
                    OnTouchpadRelease(e);
                }
            }
        }
    }

    private String GetHandOrientation(uint handControllerIndex)
    {
        if (handControllerIndex == SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.FarthestLeft))
        {
            return "LeftHand";
        }
        else if (handControllerIndex == SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.FarthestRight))
        {
            return "RightHand";
        }
        else
        {
            return "Warning: Cannot find a LEFT or RIGHT hand";
        }
    }

    protected float CalculateTouchpadAxisAngle(Vector2 axis)
    {
        float angle = Mathf.Atan2(axis.y, axis.x) * Mathf.Rad2Deg;
        angle = 90.0f - angle;
        if (angle < 0)
        {
            angle += 360.0f;
        }
        return angle;
    }
}