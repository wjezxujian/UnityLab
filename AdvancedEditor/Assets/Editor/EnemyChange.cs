using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyChange : ScriptableWizard
{
    [MenuItem("Tools/CreateWizard", false, 0)]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<EnemyChange>("统一修改敌人", "Change And Close", "Change");
    }

    public int changeStartHealthValue = 10;
    public int sinkSpeedValue = 1;

    private string changeHealthValueKey = "EnemyChange.changeStartHealthValue";
    private string changeSpeedValueKeey = "EnemyChange.sinkSpeedValue";

    private void OnEnable()
    {
        changeStartHealthValue = EditorPrefs.GetInt(changeHealthValueKey, changeStartHealthValue);
        sinkSpeedValue = EditorPrefs.GetInt(changeSpeedValueKeey, sinkSpeedValue);
    }

    private void OnWizardCreate()
    {
        GameObject[] emenyPrefabs = Selection.gameObjects;


        int count = 0;
        EditorUtility.DisplayProgressBar("进度", count + "/" + emenyPrefabs.Length + "正在修改中！", 0);

        foreach(GameObject go in emenyPrefabs)
        {
            count++;
            CompleteProject.EnemyHealth hp = go.GetComponent<CompleteProject.EnemyHealth>();
            Undo.RecordObject(hp, "changHealthAndSpped");
            hp.startingHealth += changeStartHealthValue;
            hp.sinkSpeed += sinkSpeedValue;

            EditorUtility.DisplayProgressBar("进度", count + "/" + emenyPrefabs.Length + "正在修改中！", (float)count / (float)emenyPrefabs.Length);
        }
        //可做延时处理
        EditorUtility.ClearProgressBar();

        ShowNotification(new GUIContent(Selection.gameObjects.Length + "个游戏物体的值被修改了"));

        Debug.Log("Click");
    }

    private void OnWizardOtherButton()
    {
        OnWizardCreate();

        Debug.Log("Ohter Button");
    }

    private void OnWizardUpdate()
    {
        //对象属性改变时，自动被掉用
        Debug.Log("Update");

        if(Selection.gameObjects.Length > 0)
        {
            helpString = "您当前选择了" + Selection.gameObjects.Length + "个敌人";
            errorString = "";
        }
        else
        {
            helpString = "";
            errorString = "请选择至少一个敌人";
        }

        EditorPrefs.SetInt(changeHealthValueKey, changeStartHealthValue);
        EditorPrefs.SetInt(changeSpeedValueKeey, sinkSpeedValue);
    }

    private void OnSelectionChange()
    {
        OnWizardUpdate();
    }


}
