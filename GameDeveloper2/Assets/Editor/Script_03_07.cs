using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Script_03_07
{
    [MenuItem("Window/Test/wjezxujian")]
    static void Test()
    {

    }

    [MenuItem("Window/Test/Mono")]
    static void Test1()
    {

    }

    [MenuItem("Window/Test/罗衫浪子/Mono")]
    static void Test2()
    {

    }

    [InitializeOnLoadMethod]
    static void StartInitializeOnLoadMethod()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
    }

    static void OnHierarchyGUI(int instanceID, Rect selectionRect)
    {
        Debug.Log("456"); 

        if (Event.current != null && selectionRect.Contains(Event.current.mousePosition) 
            && Event.current.button == 1 && Event.current.type <= EventType.MouseUp)
        {
            GameObject selectedGameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            Debug.Log("123");

            //这里可以判断selectedGameObject的条件
            if(selectedGameObject)
            {
                Vector2 mousePosition = Event.current.mousePosition; 

                EditorUtility.DisplayPopupMenu(new Rect(mousePosition.x, mousePosition.y, 0, 0), "Window/Test", null);
                Event.current.Use();
            }
        }
    }
}
