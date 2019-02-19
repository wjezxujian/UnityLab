using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Script_03_14 : MonoBehaviour
{
    public string contextName;
#if UNITY_EDITOR
    [MenuItem("CONTEXT/Script_03_14/New Context 1")]
    public static void NewContext2(MenuCommand command)
    {
        Script_03_14 script = (command.context as Script_03_14);
        script.contextName = "hello world!!";
    }


    [ContextMenu("Remove Componet1")]
    void RemoveComponent()
    {
        Debug.Log("RemoveComponent");
        //等一帧删除自己
        UnityEditor.EditorApplication.delayCall = delegate ()
        {
            DestroyImmediate(this);
        };
    }

#endif
}
