using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonClick : MonoBehaviour {
    public RectTransform planeTransform;

    private bool isHide = true;
    private Vector3 startPos;

	// Use this for initialization
	void Start () {
        startPos = planeTransform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        if(isHide)
        {
            print("Click");
            //让paneltransform从当前位置动画到(0, 0, 0)的位置 时间为1s(修改的世界坐标)
            Tweener tweener = planeTransform.DOLocalMove(new Vector3(0, 0, 0), 0.3f); //默认动画播放完成销毁
            //Tweener对象保存这个动画的信息 每次调用do类型的方法都会创建一个tweener对象，这个对象是dotweenr来管理
            tweener.SetAutoKill(false);
            isHide = false;
        }
        else
        {
            //planeTransform.DOLocalMove(startPos, 0.3f);
            planeTransform.DOPlayBackwards(); //倒放
            isHide = true;
        }
    }
}
