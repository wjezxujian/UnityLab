using UnityEditor;
using UnityEngine;

public class PlayEditor {

    //CONTEXT 组件名 按钮名
    [MenuItem("CONTEXT/PlayerHealth/InitHealthAndSpeed")]
    static void InitHealthAndSpeed(MenuCommand cmd) //menuCommand是当前正在操作的组件
    {
        Debug.Log(cmd.context.GetType().FullName);
        Debug.Log(cmd.context.name);
        Debug.Log("Init");

        CompleteProject.PlayerHealth health = cmd.context as CompleteProject.PlayerHealth;
        health.startingHealth = 200;
        health.flashSpeed = 10;
    }

    [MenuItem("CONTEXT/Rigidbody/Clear")]
    static void ClearMassAndGravity(MenuCommand cmd)
    {
        Rigidbody rgd = cmd.context as Rigidbody;
        rgd.mass = 0;
        rgd.useGravity = false;
    }


}
