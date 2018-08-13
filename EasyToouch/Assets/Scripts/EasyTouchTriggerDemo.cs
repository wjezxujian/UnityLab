using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyTouchTriggerDemo : MonoBehaviour
{
    public void PrintMsg(GameObject go)
    {
        if(go == null)
        {
            Debug.Log("Null");
        }
        else
        {
            Debug.Log(go.name);
        }
    }

    public void PrintOK()
    {
        Debug.Log("OK");
    }

    public void Print2()
    {
        Debug.Log("Cube2");
    }

    public void Print1()
    {
        Debug.Log("Cube1");
    }

    public void PrintInfo()
    {
        Debug.Log(gameObject.name + "!");
    }
}
