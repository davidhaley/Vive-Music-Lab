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
    private MeshRenderer meshRend;

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
        }
        else if (validTarget == null)
        {
            laserEvents = null;
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

    //Set it free
    public void OnPointerOut(object sender, PointerEventArgs e)
    {
        validTarget = null;
    }

    //If the target is valid but does not have laser events, color the laser red, otherwise green
    private void ColorLaser()
    {
        meshRend = steamVRLaserPointer.pointer.GetComponent<MeshRenderer>();

        if (laserEvents == null)
        {
            meshRend.material.color = Color.red;
        }
        else if (laserEvents != null)
        {
            meshRend.material.color = Color.green;
        }
    }
}
