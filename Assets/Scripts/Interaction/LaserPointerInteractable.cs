using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

//Place this next to the SteamVR_LaserPointer
//Let us know when a laser pointer finds an interactable object
public class LaserPointerInteractable : MonoBehaviour {

    [HideInInspector] public Transform validTarget;
    public int interactableLayerMask = 5;
    private SteamVR_LaserPointer steamVRLaserPointer;

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

    //If we find an object within the interactable layer mask, save it as the current target
    public void OnPointerIn(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.layer == interactableLayerMask)
        {
            validTarget = e.target;
        }
    }

    //If we leave the interactable object, reset the target to null
    public void OnPointerOut(object sender, PointerEventArgs e)
    {
        if (e.target.gameObject.layer == interactableLayerMask)
        {
            validTarget = null;
        }
    }

    public MeshRenderer GetLaserRenderer()
    {
        return steamVRLaserPointer.pointer.GetComponent<MeshRenderer>();
    }
}
