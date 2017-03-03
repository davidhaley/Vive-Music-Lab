//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(AudioVisualizer))]
//public class InstantiateParametricCubes : MonoBehaviour {

//    public GameObject parametricCubePrefab;
//    public AudioVisualizer audioVisualizer;

//    public float degrees = 360;
//    public float spread = 100;
//    public float scale = 10f;
//    public float sensitivity = 1000f;
//    public float startSize = 2f;

//    private GameObject[] parametricCubes = new GameObject[512];

//    private void Start()
//    {
//        for (int i = 0; i < parametricCubes.Length; i++)
//        {
//            GameObject instanceParametricCube = GameObject.Instantiate(parametricCubePrefab);
//            instanceParametricCube.transform.position = transform.position;
//            instanceParametricCube.transform.parent = transform;
//            instanceParametricCube.name = "ParametricCube" + i;
//            transform.eulerAngles = new Vector3(0, (((degrees / parametricCubes.Length) * i) * -1), 0);
//            instanceParametricCube.transform.position = Vector3.forward * spread;
//            parametricCubes[i] = instanceParametricCube;
//        }
//    }

//    private void Update()
//    {
//        for (int i = 0; i < 512; i++)
//        {
//            if (parametricCubes != null)
//            {
//                parametricCubes[i].transform.localScale = new Vector3(scale, ((audioVisualizer.samplesLeft[i] * sensitivity) + startSize), scale);
//            }
//        }
//    }
//}
