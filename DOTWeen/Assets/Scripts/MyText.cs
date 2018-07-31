using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MyText : MonoBehaviour {
    private Text text;

    // Use this for initialization
    void Start () {
        text = this.GetComponent<Text>();
        text.DOText("接下来我们进入第二篇章", 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
