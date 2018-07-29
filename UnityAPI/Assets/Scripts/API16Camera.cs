using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API16Camera : MonoBehaviour {
    private Camera mainCamera;
	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
        print(mainCamera);
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isColider = Physics.Raycast(ray, out hit);
        if(isColider)
        {
            print(hit.collider);
        }

        ray = mainCamera.ScreenPointToRay(new Vector3(200, 200, 0));
        Debug.DrawRay(ray.direction, ray.origin, Color.red);
	}
}
