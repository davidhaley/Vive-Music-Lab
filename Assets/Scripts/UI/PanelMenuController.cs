//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Valve.VR.InteractionSystem;

////---------------------------------------------------
//// Purpose: Manage panel menu items for a controller
//// Place this script on a PanelMenu game object and
//// Add the game object to the Hand
////---------------------------------------------------

//public class PanelMenuController : MonoBehaviour {

//    public Hand hand;

//    [Tooltip("The CameraEye object the panel should rotate towards.")]
//    public GameObject cameraEye;
//    [Tooltip("The scale multiplier, which relates to the scale of parent interactable object.")]
//    public float zoomScaleMultiplier = 1f;
//    [Tooltip("The top PanelMenuItemControllerController, which is triggered by pressing up on the controller touchpad.")]
//    public PanelMenuItemController topPanelMenuItemControllerController;
//    [Tooltip("The bottom PanelMenuItemControllerController, which is triggered by pressing down on the controller touchpad.")]
//    public PanelMenuItemController bottomPanelMenuItemControllerController;
//    [Tooltip("The left PanelMenuItemControllerController, which is triggered by pressing left on the controller touchpad.")]
//    public PanelMenuItemController leftPanelMenuItemControllerController;
//    [Tooltip("The right PanelMenuItemControllerController, which is triggered by pressing right on the controller touchpad.")]
//    public PanelMenuItemController rightPanelMenuItemControllerController;

//    // Relates to scale of canvas on panel items.
//    protected const float CanvasScaleSize = 0.001f;

//    // Swipe sensitivity / detection.
//    protected const float AngleTolerance = 30f;
//    protected const float SwipeMinDist = 0.2f;
//    protected const float SwipeMinVelocity = 4.0f;

//    protected SteamVRControllerEvents controllerEvents;
//    protected PanelMenuItemController currentPanelMenuItemController;
//    protected GameObject panelMenuHolder;
//    protected readonly Vector2 xAxis = new Vector2(1, 0);
//    protected readonly Vector2 yAxis = new Vector2(0, 1);
//    protected Vector2 touchStartPosition;
//    protected Vector2 touchEndPosition;
//    protected float touchStartTime;
//    protected float currentAngle;
//    protected bool isTrackingSwipe = false;
//    protected bool isPendingSwipeCheck = false;
//    protected bool isGrabbed = false;
//    protected bool isShown = false;

//    private void Awake()
//    {
//        hand = GetComponentInParent<Hand>();
//        panelMenuHolder = gameObject.transform.parent.gameObject;
//        panelMenuHolder.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
//        panelMenuHolder.transform.eulerAngles = new Vector3(90f, 0f, -90f);

//        //Initialize();
//    }

//    private void OnEnable()
//    {
//        SteamVRControllerEvents.OnTouchpadRelease += OnTouchpadReleased;
//        SteamVRControllerEvents.OnTouchpadTouch += OnTouchpadTouch;
//    }

//    protected void Start()
//    {
//        //ShowMenu();
//    }

//    private void Update()
//    {
//        if (panelMenuHolder != null)
//        {
//            if (isPendingSwipeCheck)
//            {
//                CalculateSwipeAction();
//            }
//        }
//    }

//    //public virtual void ToggleMenu()
//    //{
//    //    if (isShown)
//    //    {
//    //        HideMenu(true);
//    //    }
//    //    else
//    //    {
//    //        ShowMenu();
//    //    }
//    //}

//    //public virtual void ShowMenu()
//    //{
//    //    if (!isShown)
//    //    {
//    //        isShown = true;
//    //        StopCoroutine("TweenMenuScale");
//    //        if (enabled)
//    //        {
//    //            StartCoroutine("TweenMenuScale", isShown);
//    //        }
//    //    }
//    //}

//    //public virtual void HideMenu(bool force)
//    //{
//    //    if (isShown && force)
//    //    {
//    //        isShown = false;
//    //        StopCoroutine("TweenMenuScale");
//    //        if (enabled)
//    //        {
//    //            StartCoroutine("TweenMenuScale", isShown);
//    //        }
//    //    }
//    //}

//    //protected virtual void HandlePanelMenuItemControllerVisibility(PanelMenuItemController targetPanelItem)
//    //{
//    //    if (isShown)
//    //    {
//    //        if (currentPanelMenuItemController == targetPanelItem)
//    //        {
//    //            targetPanelItem.Hide(panelMenuHolder);
//    //            currentPanelMenuItemController = null;
//    //            HideMenu(true);
//    //        }
//    //        else
//    //        {
//    //            currentPanelMenuItemController.Hide(panelMenuHolder);
//    //            currentPanelMenuItemController = targetPanelItem;
//    //        }
//    //    }
//    //    else
//    //    {
//    //        currentPanelMenuItemController = targetPanelItem;
//    //    }

//    //    if (currentPanelMenuItemController != null)
//    //    {
//    //        currentPanelMenuItemController.Show(panelMenuHolder);
//    //        ShowMenu();
//    //    }
//    //}

//    protected void CalculateSwipeAction()
//    {
//        isPendingSwipeCheck = false;

//        float deltaTime = Time.time - touchStartTime;
//        Vector2 swipeVector = touchEndPosition - touchStartPosition;
//        float velocity = swipeVector.magnitude / deltaTime;

//        if ((velocity > SwipeMinVelocity) && (swipeVector.magnitude > SwipeMinDist))
//        {
//            swipeVector.Normalize();
//            float angleOfSwipe = Vector2.Dot(swipeVector, xAxis);
//            angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;

//            // Left / right
//            if (angleOfSwipe < AngleTolerance)
//            {
//                OnSwipeRight();
//            }
//            else if ((180.0f - angleOfSwipe) < AngleTolerance)
//            {
//                OnSwipeLeft();
//            }
//        }
//    }

//    protected virtual void OnSwipeLeft()
//    {
//        StartCoroutine(RotateAround(panelMenuHolder.gameObject.transform.localPosition, 90.0f, 0.1f));
//    }

//    protected virtual void OnSwipeRight()
//    {
//        StartCoroutine(RotateAround(panelMenuHolder.gameObject.transform.localPosition, 90.0f, 0.1f));
//    }

//    protected void OnTouchpadReleased(SteamVRControllerEvents.ControllerEventArgs e)
//    {
//        isTrackingSwipe = false;
//        isPendingSwipeCheck = true;
//    }

//    protected void OnTouchpadTouch(SteamVRControllerEvents.ControllerEventArgs e)
//    {
//        touchStartPosition = new Vector2(e.touchpadAxis.x, e.touchpadAxis.y);
//        touchStartTime = Time.time;
//        isTrackingSwipe = true;
//    }

//    IEnumerator RotateAround(Vector3 axis, float angle, float duration)
//    {
//        float elapsed = 0.0f;
//        float rotated = 0.0f;
//        while (elapsed < duration)
//        {
//            float step = angle / duration * Time.deltaTime;
//            panelMenuHolder.transform.RotateAround(hand.gameObject.transform.position, axis, step);
//            elapsed += Time.deltaTime;
//            rotated += step;
//            yield return null;
//        }
//        panelMenuHolder.transform.RotateAround(hand.gameObject.transform.position, axis, angle - rotated);
//    }

//    //protected virtual IEnumerator TweenMenuScale(bool show)
//    //{
//    //    float targetScale = 0;
//    //    Vector3 direction = -1 * Vector3.one;
//    //    if (show)
//    //    {
//    //        canvasObject.transform.localScale = new Vector3(CanvasScaleSize, CanvasScaleSize, CanvasScaleSize);
//    //        targetScale = zoomScaleMultiplier;
//    //        direction = Vector3.one;
//    //    }
//    //    int i = 0;
//    //    while (i < 250 && ((show && transform.localScale.x < targetScale) || (!show && transform.localScale.x > targetScale)))
//    //    {
//    //        transform.localScale += direction * Time.deltaTime * 4f * zoomScaleMultiplier;
//    //        yield return true;
//    //        i++;
//    //    }
//    //    transform.localScale = direction * targetScale;
//    //    StopCoroutine("TweenMenuScale");

//    //    if (!show)
//    //    {
//    //        canvasObject.transform.localScale = Vector3.zero;
//    //    }
//    //}
//}
