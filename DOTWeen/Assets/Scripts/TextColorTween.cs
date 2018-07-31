using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextColorTween : MonoBehaviour {
    private Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();

        //text.DOColor(Color.red, 2);
        text.DOFade(1, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
