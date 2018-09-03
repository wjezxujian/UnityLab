using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager
{
    private static LocalizationManager _instance;
    public static LocalizationManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new LocalizationManager();
            }
            return _instance;
        }
    }

    private const string Chinese = "Localization/Chinese";
    private const string English = "Localization/English";

    //默认语言
    public string Language = Chinese;

    private Dictionary<string, string> dict = new Dictionary<string, string>();

    public LocalizationManager()
    {
        dict.Clear();

        TextAsset ta = Resources.Load<TextAsset>(Language);
        string[] lines = ta.text.Split('\n');
        foreach(string line in lines)
        {
            if(!string.IsNullOrEmpty(line))
            {
                string[] keyValue = line.Split('=');
                dict.Add(keyValue[0], keyValue[1]);
            }
        }
    }

    public void Init()
    {
        //Do Nothing
    }

    public string GetValue(string key)
    {
        string value;
        dict.TryGetValue(key, out value);
        return value;
    }
}
