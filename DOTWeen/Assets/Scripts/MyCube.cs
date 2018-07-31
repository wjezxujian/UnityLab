using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MyCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.DOMoveX(5, 1).From(true);
        //默认是从当前位置移动到目标位置 加上From()方法以后表示从目标位置移动到当前位置


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
