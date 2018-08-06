using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelButtonScrollRect : MonoBehaviour, IBeginDragHandler, IEndDragHandler {
    public float scrollSpeed = 3.0f;
    public Toggle[] toggleArray;

    private ScrollRect scrollRect;
    private float[] pageArray = new float[] { 0f, 0.25f, 0.5f, 0.75f, 1.0f };
    private float targetHorizatioonPosition = 0;
    private bool isDrag = false;
    // Use this for initialization
    void Start () {
        scrollRect = GetComponent<ScrollRect>();
    }
	
	// Update is called once per frame
	void Update () {
        if(!isDrag)
        {

            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, targetHorizatioonPosition, Time.deltaTime * scrollSpeed);
        }        
	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        //Vector2 temp = scollRect.normalizedPosition;
        float posX = scrollRect.horizontalNormalizedPosition;

        int index = 0;
        float deltaPosX = 1;
        for(int i = 0; i < pageArray.Length; ++i)
        {
            float offset = Mathf.Abs(pageArray[index] - posX);
            if(offset <= deltaPosX)
            {
                deltaPosX = offset;
                index = i;
            }
        }

        //scrollRect.horizontalNormalizedPosition = pageArray[index];
        //实现缓动运动,在Update是先插值运算
        targetHorizatioonPosition = pageArray[index];
        toggleArray[index].isOn = true;

        print(index);


    }

    public void OnToggleValueChange1(bool isOn)
    {
        if(isOn)
        {
            targetHorizatioonPosition = pageArray[0];
        }
        
    }

    public void OnToggleValueChange2(bool isOn)
    {
        if (isOn)
        {
            targetHorizatioonPosition = pageArray[1];
        }
    }

    public void OnToggleValueChange3(bool isOn)
    {
        if (isOn)
        {
            targetHorizatioonPosition = pageArray[2];
        }
    }
    public void OnToggleValueChange4(bool isOn)
    {
        if (isOn)
        {
            targetHorizatioonPosition = pageArray[3];
        }
    }

    public void OnToggleValueChange5(bool isOn)
    {
        if (isOn)
        {
            targetHorizatioonPosition = pageArray[4];
        }
    }
}
