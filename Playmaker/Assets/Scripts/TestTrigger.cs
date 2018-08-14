using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print("Start");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger Enter!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Collision Enter!");
    }
}
