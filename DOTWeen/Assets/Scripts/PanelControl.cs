using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelControl : MonoBehaviour {
    private DOTweenAnimation tweenAnimation;
    private bool isShow = false;
	// Use this for initialization
	void Start () {
        tweenAnimation = GetComponent<DOTweenAnimation>();
        //tweenAnimation.DOPlay();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCLick()
    {
        if (isShow == true)
        {
            tweenAnimation.DOPlayBackwards();
            isShow = false;
        }
        else
        {
            tweenAnimation.DOPlayForward();
            isShow = true;
        }

    }
}
