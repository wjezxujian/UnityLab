using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API05GetComponents : MonoBehaviour {
    public GameObject target;
	// Use this for initialization
	void Start () {
        Cube cube = target.GetComponent<Cube>();
        Transform t = target.GetComponent<Transform>();
        Debug.Log(cube);
        Debug.Log(t);
        Debug.Log("------------------------------");

        Cube[] cubes = target.GetComponents<Cube>();
        Debug.Log(cubes.Length);
        Debug.Log("------------------------------");

        cubes = target.GetComponentsInChildren<Cube>();
        foreach(Cube c in cubes)
        {
            Debug.Log(c);
        }
        Debug.Log("------------------------------");

        cubes = target.GetComponentsInParent<Cube>();
        foreach(Cube c in cubes)
        {
            Debug.Log(c);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
