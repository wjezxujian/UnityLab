using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Camera))]
public class Script_03_09 : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("扩展按钮"))
        {
            Debug.LogFormat("点击扩展按钮！");
        }

        base.OnInspectorGUI();
    }
}
