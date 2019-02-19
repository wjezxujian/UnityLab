using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Script_03_12
{
    [MenuItem("GameObject/3D Object/Lock/Lock", false, 0)]
    static void Lock()
    {
        if(Selection.gameObjects != null)
        {
            foreach(var gameObject in Selection.gameObjects)
            {
                gameObject.hideFlags = HideFlags.NotEditable;
            }
        }
    }

    [MenuItem("GameObject/3D Object/Lock/UnLock", false, 1)]
    static void UnLock()
    {
        if(Selection.gameObjects != null)
        {
            foreach(var gameObject in Selection.gameObjects)
            {
                gameObject.hideFlags = HideFlags.None;
            }
        }
    }
}
