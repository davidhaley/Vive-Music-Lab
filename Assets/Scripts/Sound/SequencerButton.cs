using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequencerButton : MonoBehaviour {

    private bool ready = true;

    public bool Ready
    {
        get { return ready; }
        set
        {
            ready = value;
            var eventHandler = ReadyChanged;
            if (eventHandler != null)
                eventHandler(this, EventArgs.Empty);
        }
    }

    public event EventHandler ReadyChanged;

    public bool Queued()
    {
        return !ready;
    }
}
