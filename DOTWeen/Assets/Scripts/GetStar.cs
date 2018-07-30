using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GetStar : MonoBehaviour {
    public Transform targetCube;

    public RectTransform taskPanelTransform;

    public Vector3 myValue = new Vector3(0, 0, 0);

    public float myValue2 = 0;
	// Use this for initialization
	void Start () {
        //对变量做一个动画（通过插值的方式去修改一个值的变化）
        //DOTween.To(() => myValue, x => myValue = x, new Vector3(10, 10, 10), 2);
        DOTween.To(() => myValue, x => myValue = x, new Vector3(0, 0, 0), 2);

        DOTween.To(() => myValue2, X => myValue2 = X, 10, 2);
    }
	
	// Update is called once per frame
	void Update () {
        targetCube.position = myValue;
        //taskPanelTransform.position = myValue;
        taskPanelTransform.localPosition = myValue;

    }
}
