using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;

public class EasyTouch4_xDemo : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        EasyTouch.On_TouchStart += OnTouchStart;
        EasyTouch.On_TouchUp += OnTouchEnd;
        EasyTouch.On_Swipe += OnSwipe;
    }

    private void OnDestroy()
    {
        EasyTouch.On_TouchStart -= OnTouchStart;
        EasyTouch.On_TouchUp -= OnTouchEnd;
        EasyTouch.On_Swipe -= OnSwipe;
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
