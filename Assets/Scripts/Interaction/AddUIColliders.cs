using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Purpose: Add box colliders to buttons and size them accordingly (required for input events)
public class AddUIColliders : MonoBehaviour {

    private Button[] buttons;
    private float zDepth = 120f;

    private void Awake()
    {
        buttons = FindObjectsOfType<Button>();
    }
    private void Start()
    {
        AddColliders(buttons);
    }

    public void AddColliders(Button[] buttons)
    {
        foreach(Button button in buttons)
        {
            if (button.gameObject.GetComponent<BoxCollider>() == null)
            {
                button.gameObject.AddComponent<BoxCollider>();
            }

            BoxCollider boxCollider = button.gameObject.GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            boxCollider.size = new Vector3(button.gameObject.GetComponent<RectTransform>().sizeDelta.x, button.gameObject.GetComponent<RectTransform>().sizeDelta.y, zDepth);
        }
    }
}
