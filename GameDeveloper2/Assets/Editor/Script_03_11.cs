using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(Transform))]
public class Script_03_11 : Editor
{
    private Editor m_Eidtor;
    private void OnEnable()
    {
        m_Eidtor = Editor.CreateEditor(target, Assembly.GetAssembly(typeof(Editor)).GetType("UnityEditor.TransformInspector", true));
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("扩展按钮上"))
        {

        }

        //开始禁止
        GUI.enabled = false;
        m_Eidtor.OnInspectorGUI();
        //结束禁止
        GUI.enabled = true;

        if (GUILayout.Button("扩展按钮下"))
        {

        }
    }
}
