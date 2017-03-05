using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerStatusIndicator : MonoBehaviour {

    private Sequencer sequencer;
    private StatusIndicator statusIndicator;

    private bool toggled = false;


    private void Awake()
    {
        sequencer = GameObject.FindGameObjectWithTag("SequencerCanvas").GetComponentInParent<Sequencer>();
        statusIndicator = GetComponent<StatusIndicator>();
    }

    void Update () {
		if (sequencer.running)
        {
            statusIndicator.ToggleColor();
            toggled = true;
        }
	}
}
