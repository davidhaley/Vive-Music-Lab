using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------------------
// To show/hide a UI panel, you must first pick up the VRTK_InteractableObject.
// Then, by pressing the touchpad top/bottom/left/right you can open/close the child UI panel that has been assigned via the Unity Editor panel.
// Button type UI actions are handled by a trigger press when the panel is open.
//-----------------------------------------------------------------------------------------------------------------------------------------------
public class PanelMenuItemController : MonoBehaviour {

    public struct PanelMenuItemControllerEventArgs
    {
        public GameObject interactableObject;
    }

    public delegate void PanelMenuItemControllerEventHandler(object sender, PanelMenuItemControllerEventArgs e);

    public event PanelMenuItemControllerEventHandler PanelMenuItemShowing;
    public event PanelMenuItemControllerEventHandler PanelMenuItemHiding;

    // Emitted when the panel menu item is open and the user swipes direction on touchpad.
    public event PanelMenuItemControllerEventHandler PanelMenuItemSwipeLeft;
    public event PanelMenuItemControllerEventHandler PanelMenuItemSwipeRight;
    public event PanelMenuItemControllerEventHandler PanelMenuItemSwipeTop;
    public event PanelMenuItemControllerEventHandler PanelMenuItemSwipeBottom;

    // Emitted when the panel menu item is open and the user presses the trigger of the controller holding the interactable object.
    public event PanelMenuItemControllerEventHandler PanelMenuItemTriggerPressed;

    public virtual void OnPanelMenuItemShowing(PanelMenuItemControllerEventArgs e)
    {
        if (PanelMenuItemShowing != null)
        {
            PanelMenuItemShowing(this, e);
        }
    }

    public virtual void OnPanelMenuItemHiding(PanelMenuItemControllerEventArgs e)
    {
        if (PanelMenuItemHiding != null)
        {
            PanelMenuItemHiding(this, e);
        }
    }

    public virtual void OnPanelMenuItemSwipeLeft(PanelMenuItemControllerEventArgs e)
    {
        if (PanelMenuItemSwipeLeft != null)
        {
            PanelMenuItemSwipeLeft(this, e);
        }
    }

    public virtual void OnPanelMenuItemSwipeRight(PanelMenuItemControllerEventArgs e)
    {
        if (PanelMenuItemSwipeRight != null)
        {
            PanelMenuItemSwipeRight(this, e);
        }
    }

    public virtual void OnPanelMenuItemSwipeTop(PanelMenuItemControllerEventArgs e)
    {
        if (PanelMenuItemSwipeTop != null)
        {
            PanelMenuItemSwipeTop(this, e);
        }
    }

    public virtual void OnPanelMenuItemSwipeBottom(PanelMenuItemControllerEventArgs e)
    {
        if (PanelMenuItemSwipeBottom != null)
        {
            PanelMenuItemSwipeBottom(this, e);
        }
    }

    /// The SetPanelMenuItemEvent is used to build up the event payload.
    public virtual PanelMenuItemControllerEventArgs SetPanelMenuItemEvent(GameObject interactableObject)
    {
        PanelMenuItemControllerEventArgs e;
        e.interactableObject = interactableObject;
        return e;
    }

    /// The Show method is used to show the menu.
    public virtual void Show(GameObject interactableObject)
    {
        gameObject.SetActive(true);
        OnPanelMenuItemShowing(SetPanelMenuItemEvent(interactableObject));
    }

    /// The Hide method is used to hide the menu.
    public virtual void Hide(GameObject interactableObject)
    {
        gameObject.SetActive(false);
        OnPanelMenuItemHiding(SetPanelMenuItemEvent(interactableObject));
    }

    /// The SwipeLeft method is used when the control is swiped left.
    public virtual void SwipeLeft(GameObject interactableObject)
    {
        OnPanelMenuItemSwipeLeft(SetPanelMenuItemEvent(interactableObject));
    }

    /// The SwipeRight method is used when the control is swiped right.
    public virtual void SwipeRight(GameObject interactableObject)
    {
        OnPanelMenuItemSwipeRight(SetPanelMenuItemEvent(interactableObject));
    }

    /// The SwipeTop method is used when the control is swiped up.
    public virtual void SwipeTop(GameObject interactableObject)
    {
        OnPanelMenuItemSwipeTop(SetPanelMenuItemEvent(interactableObject));
    }

    /// The SwipeBottom method is used when the control is swiped down.
    public virtual void SwipeBottom(GameObject interactableObject)
    {
        OnPanelMenuItemSwipeBottom(SetPanelMenuItemEvent(interactableObject));
    }

    /// The TriggerPressed method is used when the control action button is pressed.
    public virtual void TriggerPressed(GameObject interactableObject)
    {
        OnPanelMenuItemTriggerPressed(SetPanelMenuItemEvent(interactableObject));
    }

    protected virtual void OnPanelMenuItemTriggerPressed(PanelMenuItemControllerEventArgs e)
    {
        if (PanelMenuItemTriggerPressed != null)
        {
            PanelMenuItemTriggerPressed(this, e);
        }
    }
}
