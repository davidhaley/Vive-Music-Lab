using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchText : MonoBehaviour {

    public FadeButton fadeButton;
    public StatusIndicator[] statusIndicators;
    public Text text1;
    public Text text2;
    public Text text3;

    private void Awake()
    {
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
    }

    public void Switch()
    {
        if (text1.gameObject.activeSelf == true)
        {
            text2.gameObject.SetActive(true);
            text1.gameObject.SetActive(false);
        }
        else if (text2.gameObject.activeSelf == true)
        {
            text3.gameObject.SetActive(true);
            text2.gameObject.SetActive(false);
        }
        else if (text3.gameObject.activeSelf == true)
        {
            text3.gameObject.SetActive(false);
            fadeButton.Fade();

            foreach(StatusIndicator statusIndicator in statusIndicators)
            {
                statusIndicator.ToggleColor();
            }
        }
    }
}
