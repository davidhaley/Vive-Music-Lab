using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Valve.VR.InteractionSystem;

//Purpose: Manage SteamVR Controller button events
namespace MusicLab.InteractionSystem
{
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
        private ulong grip = SteamVR_Controller.ButtonMask.Grip;
        private ulong trigger = SteamVR_Controller.ButtonMask.Trigger;
        private ulong touchpad = SteamVR_Controller.ButtonMask.Touchpad;
        private ulong appMenu = SteamVR_Controller.ButtonMask.ApplicationMenu;
        private ulong systemMenu = SteamVR_Controller.ButtonMask.System;

        private void Update()
        {
            for (int i = 0; i < Player.instance.handCount; i++)
            {
                if (Player.instance.hands[i].controller == null)
                {
                    return;
                }

                CheckTrigger(i);
                CheckTouchpad(i);
                CheckGrip(i);
            }
        }

        private void CheckTrigger(int handIndex)
        {
            if (Player.instance.hands[handIndex].controller.GetHairTriggerDown())
            {
                if (OnTriggerDown != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e = ApplyEventArgs(e, handIndex);
                    OnTriggerDown(e);
                }
            }

            if (Player.instance.hands[handIndex].controller.GetHairTriggerUp())
            {
                if (OnTriggerUp != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e = ApplyEventArgs(e, handIndex);
                    OnTriggerUp(e);
                }
            }
        }

        private void CheckTouchpad(int handIndex)
        {
            if (Player.instance.hands[handIndex].controller.GetPressDown(touchpad))
            {
                if (OnTouchpadDown != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e = ApplyEventArgs(e, handIndex, touchpad);
                    OnTouchpadDown(e);
                }
            }

            if (Player.instance.hands[handIndex].controller.GetPressUp(touchpad))
            {
                if (OnTouchpadUp != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e = ApplyEventArgs(e, handIndex, touchpad);
                    OnTouchpadUp(e);
                }
            }

            if (Player.instance.hands[handIndex].controller.GetTouch(touchpad))
            {
                if (OnTouchpadTouch != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e = ApplyEventArgs(e, handIndex, touchpad);
                    OnTouchpadTouch(e);
                }
            }

            if (Player.instance.hands[handIndex].controller.GetTouchUp(touchpad))
            {
                if (OnTouchpadRelease != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e = ApplyEventArgs(e, handIndex, touchpad);
                    OnTouchpadRelease(e);
                }
            }
        }

        private void CheckGrip(int handIndex)
        {
            if (Player.instance.hands[handIndex].controller.GetPressDown(grip))
            {
                if (OnGripDown != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e = ApplyEventArgs(e, handIndex);
                    OnGripDown(e);
                }
            }

            if (Player.instance.hands[handIndex].controller.GetPressUp(grip))
            {
                if (OnGripUp != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e = ApplyEventArgs(e, handIndex);
                    OnGripUp(e);
                }
            }

            if (Player.instance.hands[handIndex].controller.GetPressUp(grip))
            {
                if (OnGripUp != null)
                {
                    ControllerEventArgs e = new ControllerEventArgs();
                    e = ApplyEventArgs(e, handIndex);
                    OnGripUp(e);
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

        private SteamVRControllerEvents.ControllerEventArgs ApplyEventArgs(ControllerEventArgs e, int i, ulong? button = null)
        {
            e.deviceIndex = i;
            e.handOrientation = GetHandOrientation(Player.instance.hands[i].controller.index);

            if (button == touchpad)
            {
                e.touchpadAxis = Player.instance.hands[i].controller.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
                e.touchpadAngle = CalculateTouchpadAxisAngle(e.touchpadAxis);
            }

            return e;
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
}
