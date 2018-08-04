using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyWindow : EditorWindow
{
    private string inputContent = "";

    [MenuItem("Window/Show MyWindow")]
    static void ShowMyWindow()
    {
        MyWindow widdow = EditorWindow.GetWindow<MyWindow>();
        widdow.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("这是我的窗口");
        inputContent = GUILayout.TextField(inputContent);
        if(GUILayout.Button("创建按钮"))
        {
            GameObject go = new GameObject(inputContent);
            Undo.RegisterCreatedObjectUndo(go, "create gameobject");
        }
    }
}
