using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Script_03_06
{
    [InitializeOnLoadMethod]
    static void InitializeMethod()
    {
        EditorApplication.hierarchyWindowItemOnGUI = delegate (int instanceID, Rect selectionRect)
        {
            //在Hierarchy视图中选择一个资源
            if (Selection.activeObject && instanceID == Selection.activeObject.GetInstanceID())
            {
                //设置拓展区域按钮
                float width = 50f;
                float height = 20f;
                selectionRect.x += (selectionRect.width - width);
                selectionRect.y += (selectionRect.height - height) / 2;
                selectionRect.width = width;
                selectionRect.height = height;

                //点击事件
                if(GUI.Button(selectionRect, AssetDatabase.LoadAssetAtPath<Texture>("Assets/unity.png")))
                {
                    Debug.LogFormat("click: {0}", Selection.activeObject.name);
                }

            }
        };
    }
}
