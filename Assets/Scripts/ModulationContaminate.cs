using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulationContaminate : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Contaminable")
        {
            if (collision.gameObject.GetComponent<ParamCubeScale>() == null)
            {
                ParamCube paramCube = collision.gameObject.AddComponent<ParamCubeScale>();
                collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
                collision.gameObject.tag = "Contaminated";
            }
        }
    }
}
