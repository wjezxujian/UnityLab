using UnityEditor;
using UnityEngine;


public class Tools {
    //[MenuItem("Tools/test/test1")]
    //static void Test()
    //{
    //    Debug.Log("Test");
    //}

    //[MenuItem("Tools/test/test2")]
    //static void Test2()
    //{
    //    Debug.Log("Test2");
    //}

    [MenuItem("GameObject/mytool", false, 11)]
    static void MyTool()
    {
        Debug.Log("GameObjectMyTool");
    }

    [MenuItem("GameObject/delete", false, 11)]
    static void MyDelete()
    {
        foreach(Object o in Selection.objects)
        {
            GameObject.DestroyImmediate(o);
        }
    }

    [MenuItem("Assets/mytool", false, 1000)]
    static void AssetsMyTool()
    {
        Debug.Log("AssetsMyTool");
    }

    //每一个菜单栏的proority优先级默认为1000
    //Proprity相差11就添加横线分组
    [MenuItem("Tools/Show Info", false, 1)]
    static void Test()
    {
        //默认显示的我们第一个游戏物体通过
        //Debug.Log(Selection.activeGameObject.name);

        Debug.Log(Selection.objects.Length);
        Debug.Log(Selection.gameObjects.Length);

        
    }

    [MenuItem("Tools/test2", false , 12)]
    static void Test2()
    {
        Debug.Log("Test2");
    }

    [MenuItem("Tools/test3", false, 0)]
    static void Test3()
    {
        Debug.Log("Test3");
    }



}
