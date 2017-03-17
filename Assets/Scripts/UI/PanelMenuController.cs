using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

//---------------------------------------------------
// Purpose: Manage panel menu items for a controller
// Place this script on a PanelMenu game object and
// Add the game object to the Hand
//---------------------------------------------------

public class PanelMenuController : MonoBehaviour {

    public Hand hand;

    public enum TouchpadPressPosition
    {
        None,
        Top,
        Bottom,
        Left,
        Right
    }

    [Tooltip("The CameraEye object the panel should rotate towards.")]
    public GameObject cameraEye;
    [Tooltip("The scale multiplier, which relates to the scale of parent interactable object.")]
    public float zoomScaleMultiplier = 1f;
    [Tooltip("The top PanelMenuItemController, which is triggered by pressing up on the controller touchpad.")]
    public PanelMenuItem topPanelMenuItemController;
    [Tooltip("The bottom PanelMenuItemController, which is triggered by pressing down on the controller touchpad.")]
    public PanelMenuItem bottomPanelMenuItemController;
    [Tooltip("The left PanelMenuItemController, which is triggered by pressing left on the controller touchpad.")]
    public PanelMenuItem leftPanelMenuItemController;
    [Tooltip("The right PanelMenuItemController, which is triggered by pressing right on the controller touchpad.")]
    public PanelMenuItem rightPanelMenuItemController;

    // Relates to scale of canvas on panel items.
    protected const float CanvasScaleSize = 0.001f;

    // Swipe sensitivity / detection.
    protected const float AngleTolerance = 30f;
    protected const float SwipeMinDist = 0.2f;
    protected const float SwipeMinVelocity = 4.0f;

    protected SteamVRControllerEvents controllerEvents;
    protected PanelMenuItem currentPanelMenuItem;
    protected GameObject canvasObject;
    protected GameObject interactableObject;
    protected readonly Vector2 xAxis = new Vector2(1, 0);
    protected readonly Vector2 yAxis = new Vector2(0, 1);
    protected Vector2 touchStartPosition;
    protected Vector2 touchEndPosition;
    protected float touchStartTime;
    protected float currentAngle;
    protected bool isTrackingSwipe = false;
    protected bool isPendingSwipeCheck = false;
    protected bool isGrabbed = false;
    protected bool isShown = false;

    private void Awake()
    {
        canvasObject = gameObject.transform.GetChild(0).gameObject;
    }

    protected virtual void Start()
    {
        ShowMenu();
        interactableObject = gameObject.transform.parent.gameObject;

        //interactableObject += new InteractableObjectEventHandler(DoInteractableObjectIsGrabbed);
        //interactableObject.GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += new InteractableObjectEventHandler(DoInteractableObjectIsUngrabbed);

        canvasObject = gameObject.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (isShown)
        {
            if (cameraEye != null)
            {
                transform.rotation = Quaternion.LookRotation((cameraEye.transform.position - transform.position) * -1, Vector3.up);
            }
        }

        //if (isPendingSwipeCheck)
        //{
        //    CalculateSwipeAction();
        //}
    }

    public virtual void ShowMenu()
    {
        if (!isShown)
        {
            isShown = true;
            StopCoroutine("TweenMenuScale");
            if (enabled)
            {
                StartCoroutine("TweenMenuScale", isShown);
            }
        }
    }

    public virtual void HideMenu(bool force)
    {
        if (isShown && force)
        {
            isShown = false;
            StopCoroutine("TweenMenuScale");
            if (enabled)
            {
                StartCoroutine("TweenMenuScale", isShown);
            }
        }
    }

    protected virtual IEnumerator TweenMenuScale(bool show)
    {
        float targetScale = 0;
        Vector3 direction = -1 * Vector3.one;
        if (show)
        {
            canvasObject.transform.localScale = new Vector3(CanvasScaleSize, CanvasScaleSize, CanvasScaleSize);
            targetScale = zoomScaleMultiplier;
            direction = Vector3.one;
        }
        int i = 0;
        while (i < 250 && ((show && transform.localScale.x < targetScale) || (!show && transform.localScale.x > targetScale)))
        {
            transform.localScale += direction * Time.deltaTime * 4f * zoomScaleMultiplier;
            yield return true;
            i++;
        }
        transform.localScale = direction * targetScale;
        StopCoroutine("TweenMenuScale");

        if (!show)
        {
            canvasObject.transform.localScale = Vector3.zero;
        }
    }

    //protected virtual void HandlePanelMenuItemControllerVisibility(PanelMenuItem targetPanelItem)
    //{
    //    if (isShown)
    //    {
    //        if (currentPanelMenuItem == targetPanelItem)
    //        {
    //            targetPanelItem.Hide(interactableObject);
    //            currentPanelMenuItem = null;
    //            HideMenu(true);
    //        }
    //        else
    //        {
    //            currentPanelMenuItem.Hide(interactableObject);
    //            currentPanelMenuItem = targetPanelItem;
    //        }
    //    }
    //    else
    //    {
    //        currentPanelMenuItem = targetPanelItem;
    //    }

    //    if (currentPanelMenuItem != null)
    //    {
    //        currentPanelMenuItem.Show(interactableObject);
    //        ShowMenu();
    //    }
    //}

    //protected virtual void CalculateSwipeAction()
    //{
    //    isPendingSwipeCheck = false;

    //    float deltaTime = Time.time - touchStartTime;
    //    Vector2 swipeVector = touchEndPosition - touchStartPosition;
    //    float velocity = swipeVector.magnitude / deltaTime;

    //    if ((velocity > SwipeMinVelocity) && (swipeVector.magnitude > SwipeMinDist))
    //    {
    //        swipeVector.Normalize();
    //        float angleOfSwipe = Vector2.Dot(swipeVector, xAxis);
    //        angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;

    //        // Left / right
    //        if (angleOfSwipe < AngleTolerance)
    //        {
    //            OnSwipeRight();
    //        }
    //        else if ((180.0f - angleOfSwipe) < AngleTolerance)
    //        {
    //            OnSwipeLeft();
    //        }
    //        else
    //        {
    //            // Top / bottom
    //            angleOfSwipe = Vector2.Dot(swipeVector, yAxis);
    //            angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;
    //            if (angleOfSwipe < AngleTolerance)
    //            {
    //                OnSwipeTop();
    //            }
    //            else if ((180.0f - angleOfSwipe) < AngleTolerance)
    //            {
    //                OnSwipeBottom();
    //            }
    //        }
    //    }
    //}

    //protected virtual void OnSwipeLeft()
    //{
    //    if (currentPanelMenuItemController != null)
    //    {
    //        currentPanelMenuItemController.SwipeLeft(interactableObject);
    //    }
    //}

    //protected virtual void OnSwipeRight()
    //{
    //    if (currentPanelMenuItemController != null)
    //    {
    //        currentPanelMenuItemController.SwipeRight(interactableObject);
    //    }
    //}

    //protected virtual void OnSwipeTop()
    //{
    //    if (currentPanelMenuItemController != null)
    //    {
    //        currentPanelMenuItemController.SwipeTop(interactableObject);
    //    }
    //}

    //protected virtual void OnSwipeBottom()
    //{
    //    if (currentPanelMenuItemController != null)
    //    {
    //        currentPanelMenuItemController.SwipeBottom(interactableObject);
    //    }
    //}


    //protected virtual void DoInteractableObjectIsGrabbed(object sender, InteractableObjectEventArgs e)
    //{
    //    controllerEvents = e.interactingObject.GetComponentInParent<VRTK_ControllerEvents>();
    //    if (controllerEvents != null)
    //    {
    //        BindControllerEvents();
    //    }
    //    isGrabbed = true;
    //}

    //protected virtual void DoInteractableObjectIsUngrabbed(object sender, InteractableObjectEventArgs e)
    //{
    //    isGrabbed = false;
    //    if (isShown)
    //    {
    //        HideMenuImmediate();
    //    }

    //    if (controllerEvents != null)
    //    {
    //        UnbindControllerEvents();
    //        controllerEvents = null;
    //    }
    //}

    //protected virtual void DoTouchpadPress(object sender, ControllerInteractionEventArgs e)
    //{
    //    if (isGrabbed)
    //    {
    //        var pressPosition = CalculateTouchpadPressPosition();
    //        switch (pressPosition)
    //        {
    //            case TouchpadPressPosition.Top:
    //                if (topPanelMenuItemController != null)
    //                {
    //                    HandlePanelMenuItemControllerVisibility(topPanelMenuItemController);
    //                }
    //                break;

    //            case TouchpadPressPosition.Bottom:
    //                if (bottomPanelMenuItemController != null)
    //                {
    //                    HandlePanelMenuItemControllerVisibility(bottomPanelMenuItemController);
    //                }
    //                break;

    //            case TouchpadPressPosition.Left:
    //                if (leftPanelMenuItemController != null)
    //                {
    //                    HandlePanelMenuItemControllerVisibility(leftPanelMenuItemController);
    //                }
    //                break;

    //            case TouchpadPressPosition.Right:
    //                if (rightPanelMenuItemController != null)
    //                {
    //                    HandlePanelMenuItemControllerVisibility(rightPanelMenuItemController);
    //                }
    //                break;
    //        }
    //    }
    //}

    //protected virtual void DoTouchpadTouched()
    //{
    //    touchStartPosition = new Vector2(SteamVR_Controller.touchpadAxis.x, e.touchpadAxis.y);
    //    touchStartTime = Time.time;
    //    isTrackingSwipe = true;
    //}

    //protected virtual void DoTouchpadUntouched()
    //{
    //    isTrackingSwipe = false;
    //    isPendingSwipeCheck = true;
    //}

    //protected virtual void DoTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
    //{
    //    ChangeAngle(CalculateAngle(e));

    //    if (isTrackingSwipe)
    //    {
    //        touchEndPosition = new Vector2(e.touchpadAxis.x, e.touchpadAxis.y);
    //    }
    //}

    //protected virtual void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
    //{
    //    if (isGrabbed)
    //    {
    //        OnTriggerPressed();
    //    }
    //}

    //protected virtual void ChangeAngle(float angle, object sender = null)
    //{
    //    currentAngle = angle;
    //}

    //protected virtual TouchpadPressPosition CalculateTouchpadPressPosition()
    //{
    //    if (CheckAnglePosition(currentAngle, AngleTolerance, 0))
    //    {
    //        return TouchpadPressPosition.Top;
    //    }
    //    else if (CheckAnglePosition(currentAngle, AngleTolerance, 180))
    //    {
    //        return TouchpadPressPosition.Bottom;
    //    }
    //    else if (CheckAnglePosition(currentAngle, AngleTolerance, 270))
    //    {
    //        return TouchpadPressPosition.Left;
    //    }
    //    else if (CheckAnglePosition(currentAngle, AngleTolerance, 90))
    //    {
    //        return TouchpadPressPosition.Right;
    //    }

    //    return TouchpadPressPosition.None;
    //}

    //protected virtual void OnTriggerPressed()
    //{
    //    if (currentPanelMenuItemController != null)
    //    {
    //        currentPanelMenuItemController.TriggerPressed(interactableObject);
    //    }
    //}

    //protected virtual float CalculateAngle(ControllerInteractionEventArgs e)
    //{
    //    return e.touchpadAngle;
    //}

    //protected virtual float NormAngle(float currentDegree, float maxAngle = 360)
    //{
    //    if (currentDegree < 0) currentDegree = currentDegree + maxAngle;
    //    return currentDegree % maxAngle;
    //}

    //protected virtual bool CheckAnglePosition(float currentDegree, float tolerance, float targetDegree)
    //{
    //    float lowerBound = NormAngle(currentDegree - tolerance);
    //    float upperBound = NormAngle(currentDegree + tolerance);

    //    if (lowerBound > upperBound)
    //    {
    //        return targetDegree >= lowerBound || targetDegree <= upperBound;
    //    }
    //    return targetDegree >= lowerBound && targetDegree <= upperBound;
    //}
}
