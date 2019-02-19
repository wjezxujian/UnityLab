using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Script_03_13
{
    [MenuItem("CONTEXT/Transform/New Context 1")]
    public static void NewContext1(MenuCommand command)
    {
        //獲取對象名
        Debug.Log(command.context.name);
    }

    [MenuItem("CONTEXT/Component/New Context 2")]
    public static void NewContext2(MenuCommand command)
    {
        Debug.Log(command.context.name);
    }
}
