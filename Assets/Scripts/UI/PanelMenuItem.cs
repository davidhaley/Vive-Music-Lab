using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// intercepts controller events sent from panelmenucontroller, and passes them onto additional custom event subscriber scripts, which then carry out the required custom ui actions]. To show / hide a UI panel, you must first pick up the VRTK_InteractableObject and then by pressing the touchpad top/bottom/left/right you can open/close the child UI panel that has been assigned via the Unity Editor panel. Button type UI actions are handled by a trigger press when the panel is open.
public class PanelMenuItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
