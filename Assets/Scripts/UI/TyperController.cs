using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TyperController : MonoBehaviour {

    public Typer typer;

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("colliding with " + col);
        if (col.name == "MainCamera")
        {
            typer.gameObject.SetActive(true);
            Debug.Log("colliding with " + col.name);
            typer.StartTyper();
        }
    }
}
