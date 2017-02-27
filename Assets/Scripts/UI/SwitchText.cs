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

    public bool fadeCanvasOnFinalText;
    public bool welcomeCanvas;
    public GameObject canvas;

    private void Awake()
    {
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);

        if (welcomeCanvas)
        {
            GameObject[] teleportObjs = GameObject.FindGameObjectsWithTag("Teleport");

            foreach (GameObject teleportObj in teleportObjs)
            {
                teleportObj.layer = 9;
            }
        }
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

            if (statusIndicators != null)
            {
                foreach (StatusIndicator statusIndicator in statusIndicators)
                {
                    if (statusIndicator != null)
                    {
                        statusIndicator.ToggleColor();
                    }
                }
            }

            if (fadeCanvasOnFinalText && canvas != null)
            {
                Debug.Log("starting fade");
                canvas.GetComponent<FadeController>().ToggleFade();
            }

            if (welcomeCanvas)
            {
                GameObject[] teleportObjs = GameObject.FindGameObjectsWithTag("Teleport");

                foreach(GameObject teleportObj in teleportObjs)
                {
                    teleportObj.layer = 8;
                }
            }
        }
    }
}
