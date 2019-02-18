using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Script_03_02
{
    [MenuItem("Assets/Create/My Create/Cube", false, 2)]
    static void CreateCube()
    {
        GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    [MenuItem("Assets/Create/My Create/Sphere", false, 2)]
    static void CreateSphere()
    {
        GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }
}
