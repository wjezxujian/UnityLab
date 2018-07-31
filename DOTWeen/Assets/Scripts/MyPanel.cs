using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MyPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Tweener tweener = transform.DOLocalMoveX(0, 5);
        tweener.SetEase(Ease.OutBack);
        tweener.SetLoops(2);
        tweener.OnComplete(OnTweenCompolete);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTweenCompolete()
    {
        Debug.Log("动画播放完成了");
    }
}
