using UnityEngine;
using UnityEditor;

public class Script_03_03
{
    [InitializeOnLoadMethod]
    static void InitializeOnLoadMethod()
    {
        EditorApplication.projectWindowItemOnGUI = delegate (string guid, Rect selectionRect)
        {
            //在Project视图中选择一个资源
            if (Selection.activeObject && guid == AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(Selection.activeObject)))
            {
                //设置扩展按钮区域
                float width = 50f;
                selectionRect.x += (selectionRect.width - width);
                selectionRect.y += 0;
                selectionRect.width = width;
                GUI.color = Color.yellow;
                //点击事件
                if (GUI.Button(selectionRect, "Click"))
                {
                    Debug.LogFormat("click {0}", Selection.activeObject.name);
                }

                GUI.color = Color.white;
            }
        };
    }
}
