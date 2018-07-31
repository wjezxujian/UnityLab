using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MyShakeCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.DOShakePosition(1, new Vector3(1, 1, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
