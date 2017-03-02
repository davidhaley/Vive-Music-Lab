using UnityEngine;
using UnityEngine.Events;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
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
    }
}

