using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

//Place this next to the SteamVR_LaserPointer
//Let us know when a laser pointer finds an interactable object
[RequireComponent(typeof(SteamVR_LaserPointer))]
public class LaserPointerInteractable : MonoBehaviour {

    [HideInInspector] public Transform validTarget;
    public int interactableLayerMask = 5;

    [HideInInspector] private LaserEvents laserEvents;
    private SteamVR_LaserPointer steamVRLaserPointer;
    private MeshRenderer meshRend;

    private void Awake()
    {
        steamVRLaserPointer = GetComponent<SteamVR_LaserPointer>();
    }

    private void Start()
    {
        meshRend = steamVRLaserPointer.pointer.GetComponent<MeshRenderer>();
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
        }
            ColorLaser();
    }

    //If we find an object within the interactable layer mask, save it as the valid target
    public void OnPointerIn(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.layer == interactableLayerMask)
        {
            validTarget = e.target;
        }
    }

    //If we leave the interactable object, target is non-valid
    public void OnPointerOut(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.layer == interactableLayerMask)
        {
            validTarget = null;
        }
    }

    public LaserEvents GetLaserEvents()
    {
        return laserEvents;
    }

    //If the target is valid but does not have laser events, color the laser red, otherwise green
    private void ColorLaser()
    {
        if (steamVRLaserPointer.pointer.GetComponent<MeshRenderer>() != null)
        {
            meshRend = steamVRLaserPointer.pointer.GetComponent<MeshRenderer>();
        }

        if (laserEvents == null)
        {
            meshRend.material.color = Color.red;
            return;
        }
        else if (laserEvents != null)
        {
            meshRend.material.color = Color.green;
        }
    }
}
