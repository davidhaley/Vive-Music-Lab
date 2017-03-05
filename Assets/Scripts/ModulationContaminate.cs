using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulationContaminate : MonoBehaviour {

    private AudioSource audioSource;
    private AudioClip contaminationClip;
    private AudioClip pipeEjectClip;
    private AudioClip errorClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        contaminationClip = Resources.Load<AudioClip>("Sounds/ModulationContaminate/Contamination");
        pipeEjectClip = Resources.Load<AudioClip>("Sounds/ModulationContaminate/PipeEject");
        errorClip = Resources.Load<AudioClip>("Sounds/ModulationContaminate/Error");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Contaminable")
        {
            GameObject contaminable = collision.gameObject;

            if (collision.gameObject.GetComponent<ParamCubeScale>() == null)
            {
                ParamCube paramCube = contaminable.AddComponent<ParamCubeScale>();
                contaminable.GetComponent<Renderer>().material.color = Color.green;
                contaminable.tag = "Contaminated";
            }

            StartCoroutine(Contamination());
            StartCoroutine(TeleportContaminate(contaminable));
        }
        else
        {
            audioSource.clip = errorClip;
            audioSource.Play();
        }
    }

    private IEnumerator TeleportContaminate(GameObject contaminable)
    {
        yield return new WaitForSeconds(4f);
        audioSource.clip = pipeEjectClip;
        audioSource.Play();
        contaminable.transform.localScale = new Vector3(0.235858f, 0.235858f, 0.235858f);
        contaminable.transform.position = new Vector3(-2.336f, 4.074f, -12.711f);
    }

    private IEnumerator Contamination()
    {
        yield return new WaitForSeconds(1f);
        audioSource.clip = contaminationClip;
        audioSource.Play();
    }
}
