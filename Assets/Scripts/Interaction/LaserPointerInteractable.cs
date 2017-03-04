using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace MusicLab.InteractionSystem
{
    //Place this next to the SteamVR_LaserPointer
    //Responsible for finding interactable objects
    [RequireComponent(typeof(SteamVR_LaserPointer))]
    public class LaserPointerInteractable : MonoBehaviour
    {
        public float hintDelay = 2.5f;

        private SteamVR_LaserPointer steamVRLaserPointer;
        private ControllerHints controllerHints;
        private MeshRenderer laserRenderer;
        private LaserEvents laserEvents;
        private Transform validLaserTarget;
        private Transform validHandTarget;

        private int uiHandMask = 10;
        private int uiLaserMask = 11;
        private int uiHandLaserMask = 12;

        private void Awake()
        {
            steamVRLaserPointer = GetComponent<SteamVR_LaserPointer>();
            controllerHints = FindObjectOfType<ControllerHints>();
        }

        private void OnEnable()
        {
            steamVRLaserPointer.PointerIn += OnPointerIn;
            steamVRLaserPointer.PointerOut += OnPointerOut;
        }

        private void Update()
        {
            LaserEvents();
        }

        public void OnPointerIn(object sender, PointerEventArgs e)
        {
            Transform targetTransform = e.target;
            int targetLayer = e.target.gameObject.layer;

            if (targetLayer == uiHandLaserMask)
            {
                validLaserTarget = validHandTarget = e.target;
            }
            else if (targetLayer == uiLaserMask)
            {
                validLaserTarget = e.target;
                validHandTarget = null;
            }
            else if (targetLayer == uiHandMask)
            {
                validHandTarget = e.target;
                validLaserTarget = null;
            }
            else
            {
                validLaserTarget = null;
                validHandTarget = null;
            }
        }

        public void OnPointerOut(object sender, PointerEventArgs e)
        {
            validLaserTarget = null;
            validHandTarget = null;
            laserEvents = null;
        }

        public LaserEvents LaserEvents()
        {
            if (validLaserTarget != null)
            {
                laserEvents = validLaserTarget.GetComponent<LaserEvents>();
            }
            else if (validLaserTarget == null)
            {
                laserEvents = null;
            }

            return laserEvents;
        }

        public Transform ValidLaserTarget()
        {
            return validLaserTarget;
        }
        public Transform ValidHandTarget()
        {
            return validHandTarget;
        }

        public void EnableLaser()
        {
            steamVRLaserPointer.pointer.GetComponent<MeshRenderer>().enabled = true;
        }

        public void DisableLaser()
        {
            steamVRLaserPointer.pointer.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}

