using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWithMouse : MonoBehaviour
{
    public float length = 3;

    private bool isClick = false;
    private Vector3 nowPos;
    private Vector3 oldPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        nowPos = Input.mousePosition;
        if (isClick)
        {
            
            Vector3 offset = nowPos - oldPos;
            if(Mathf.Abs(offset.x) > Mathf.Abs(offset.y) && Mathf.Abs(offset.x) > length)
            {
                transform.Rotate(Vector3.up, -offset.x);
            } 
        }
        oldPos = nowPos;
    }

    //鼠标抬起
    private void OnMouseUp()
    {
        isClick = false;
    }

    //鼠标按下
    private void OnMouseDown()
    {
        isClick = true;
    }

}
