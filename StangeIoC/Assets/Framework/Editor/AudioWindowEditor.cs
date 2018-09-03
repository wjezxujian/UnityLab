using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class AudioWindowEditor : EditorWindow
{
    [MenuItem("Manager/AudioManager")]
    static void CreateWindow()
    {
        //Rect _rect = new Rect(100, 100, 400, 200);
        //AudioWindowEditor window = EditorWindow.GetWindowWithRect(typeof(AudioWindowEditor), rect) as AudioWindowEditor;
        AudioWindowEditor window = EditorWindow.GetWindow<AudioWindowEditor>("音效管理");
        window.Show();
    }

    private string savePath = "";
    private void Awake()
    {
        //Debug.Log(Application.dataPath);

        //创建时填充
        savePath = AudioManager.AudioTextPath;

        LoadAudioList();
    }

    //private string text = "输入文字1";
    //private string text2 = "输入文字2";
    private string audioName;
    private string audioPath;
    private Dictionary<string, string> audioDict = new Dictionary<string, string>();
    private void OnGUI()
    {

        //text = EditorGUILayout.TextField(text);
        //text2 =GUILayout.TextField(text2);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("音效名称");
        EditorGUILayout.LabelField("音效路径");
        EditorGUILayout.LabelField("操作");
        EditorGUILayout.EndHorizontal();

        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(key);
            EditorGUILayout.LabelField(value);
            if(GUILayout.Button("删除"))
            {
                audioDict.Remove(key);
                SaveAudioList();
                return;
            }
            EditorGUILayout.EndHorizontal();
        }


        audioName = EditorGUILayout.TextField("音效名字", audioName);
        audioPath = EditorGUILayout.TextField("音效路径", audioPath);
        if(GUILayout.Button("添加音效"))
        {
            object o = Resources.Load(audioPath);
            if(o == null)
            {
                Debug.LogWarning("音效不存在与" + audioPath + ",添加不成功");
                audioPath = "";
            }
            else
            {
                //TODO 添加音效
                if(audioDict.ContainsKey(audioName))
                {
                    Debug.LogWarning("名字已经存在，请修改");
                    return;
                }
                audioDict.Add(audioName, audioPath);
                SaveAudioList();
            }
        }

       
    }

    private void OnInspectorUpdate()
    {
        //Debug.Log("Update");
        LoadAudioList();
    }


    private void SaveAudioList()
    {
        StringBuilder sb = new StringBuilder();

        foreach (string key in audioDict.Keys)
        {
            string value;
            audioDict.TryGetValue(key, out value);
            sb.Append(key + "," + value + "\n");
        }

        File.WriteAllText(savePath, sb.ToString());

    }

    private void LoadAudioList()
    {
        if (File.Exists(savePath) == false)
            return;

        audioDict = new Dictionary<string, string>();

        string[] lines = File.ReadAllLines(savePath);
        foreach(string line in lines)
        {
            if(string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] keyvalue = line.Split(',');
            audioDict.Add(keyvalue[0], keyvalue[1]);
        }
    }
}

