using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {
    public float viewDistance = 5;
    public float viewAngle = 120;

    private Transform playerTransform;
	// Use this for initialization
	void Start () {
        playerTransform = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(playerTransform.position, transform.position) <= viewDistance)
        {
            Vector3 playerDir = playerTransform.position - transform.position;
            float angle = Vector3.Angle(playerDir, transform.forward);
            if(angle <= viewAngle / 2)
            {
                Debug.Log("In Filed!");
            }
        }
	}
}
