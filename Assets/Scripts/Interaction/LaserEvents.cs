using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class LaserEvents : MonoBehaviour
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