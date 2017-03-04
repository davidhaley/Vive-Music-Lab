using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Place this next to the SteamVR_LaserPointer
//Let us know when a laser pointer finds an interactable object
[RequireComponent(typeof(SteamVR_LaserPointer))]
public class LaserPointerInteractable : MonoBehaviour {

    public int interactableLayerMask = 5;

    public LaserEvents laserEvents;
    public Transform validTarget;
    private SteamVR_LaserPointer steamVRLaserPointer;
    //private Material reference;

    private void Awake()
    {
        steamVRLaserPointer = GetComponent<SteamVR_LaserPointer>();
    }

    private void OnEnable()
    {
        steamVRLaserPointer.PointerIn += OnPointerIn;
        steamVRLaserPointer.PointerOut += OnPointerOut;
    }

    private void OnDisable()
    {
        steamVRLaserPointer.PointerIn -= OnPointerIn;
        steamVRLaserPointer.PointerOut -= OnPointerOut;
    }

    private void Update()
    {
        //Once we find a valid target, look for laser events
        if (validTarget != null)
        {
            laserEvents = validTarget.GetComponent<LaserEvents>();
            steamVRLaserPointer.pointer.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (validTarget == null)
        {
            laserEvents = null;
            steamVRLaserPointer.pointer.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    //If we find an object within the interactable layer mask, save it as the valid target
    public void OnPointerIn(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.layer == interactableLayerMask)
        {
            validTarget = e.target;

            //Enable laser if there are laser events
            steamVRLaserPointer.pointer.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            steamVRLaserPointer.pointer.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    //Set it free
    public void OnPointerOut(object sender, PointerEventArgs e)
    {
        validTarget = null;
        steamVRLaserPointer.pointer.GetComponent<MeshRenderer>().enabled = false;
    }
}
