using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Script_03_05
{
    [MenuItem("GameObject/My Create/Cube", false, 0)]
    static void CreateCube()
    {
        //创建立方体
        GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
}
