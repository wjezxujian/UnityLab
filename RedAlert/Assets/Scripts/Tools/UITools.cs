using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class UITools
{
    public static GameObject GetCanvas(string name ="Canvas")
    {
        return GameObject.Find(name);
    }

    public static T FindChild<T>(GameObject parent, string childName)
    {
        GameObject uiGO = UnityTools.FindChild(parent, childName);
        if (uiGO == null)
        {
            Debug.LogError("在游戏物理" + parent + "下面查找不到" + childName);
            return default(T);
        }
            
        return uiGO.GetComponent<T>();
    }

}

