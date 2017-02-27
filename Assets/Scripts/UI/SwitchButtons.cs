using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtons : MonoBehaviour {

    public Button button1;
    public Button button2;

    public void Switch()
    {
        if (button1.gameObject.activeSelf == true)
        {
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(true);
        }
        else if (button2.gameObject.activeSelf == true)
        {
            button2.gameObject.SetActive(false);
            button1.gameObject.SetActive(true);
        }
    }
}
