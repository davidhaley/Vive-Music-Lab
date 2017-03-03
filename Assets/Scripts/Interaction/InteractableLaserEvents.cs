using UnityEngine;
using UnityEngine.Events;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    [RequireComponent(typeof(BoxCollider))]
    public class InteractableLaserEvents : MonoBehaviour
    {
        public UnityEvent onTriggerDown;
        public UnityEvent onTriggerUp;
        public UnityEvent onGripDown;
        public UnityEvent onGripUp;
        public UnityEvent onTouchpadDown;
        public UnityEvent onTouchpadUp;
        public UnityEvent onTouchpadTouch;
        public UnityEvent onTouchpadRelease;

        //Add collider for laser raycast
        private void Awake()
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            boxCollider.size = new Vector3(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
    }
}

