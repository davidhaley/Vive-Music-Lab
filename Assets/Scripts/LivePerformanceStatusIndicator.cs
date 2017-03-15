using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivePerformanceStatusIndicator : MonoBehaviour
{

    public MusicController musicController;
    private StatusIndicator statusIndicator;

    private bool toggled = false;

    private void Awake()
    {
        musicController = GetComponentInParent<MusicController>();
        statusIndicator = GetComponent<StatusIndicator>();
    }

    void Update()
    {
        if (musicController.IsAnyPlaying() && !toggled)
        {
            statusIndicator.ToggleColor();
            toggled = true;
        }
    }
}