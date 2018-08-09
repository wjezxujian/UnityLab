using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;

public class EasyTouch5_xDemo : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Gesture currentGetsture = EasyTouch.current;

        if(currentGetsture != null && EasyTouch.EvtType.On_TouchStart == currentGetsture.type)
        {
            OnTouchStart(currentGetsture);
        }
        else if (currentGetsture != null && EasyTouch.EvtType.On_TouchUp == currentGetsture.type)
        {
            OnTouchEnd(currentGetsture);
        }
        else if (currentGetsture != null && EasyTouch.EvtType.On_Swipe == currentGetsture.type)
        {
            OnSwipe(currentGetsture);
        }




    }

    void OnTouchStart(Gesture gesture)
    {
        Debug.Log("OnTouchStart");
        Debug.Log("StartPosition" + gesture.startPosition);
    }

    void OnTouchEnd(Gesture gesture)
    {
        Debug.Log("OnTouchEnd");
        Debug.Log("StartPosition" + gesture.actionTime);
    }

    void OnSwipe(Gesture getsture)
    {
        Debug.Log("OnSwipe");
        Debug.Log("Type" + getsture.type);
    }
}
