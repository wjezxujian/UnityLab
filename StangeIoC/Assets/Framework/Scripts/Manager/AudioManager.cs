using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    private static string audioTextPrefix = Application.dataPath + "/Framework/Resources/";
    private const string audioTextPathMiddle = "audiolist";
    private const string audioTextPathPostfix = ".txt";
    private Dictionary<string, AudioClip> audioClipDict = new Dictionary<string, AudioClip>();

    public bool isMute = false;

    public static string AudioTextPathMiddle
    {
        get
        {
            return audioTextPrefix + audioTextPathMiddle;
        }
    }

    public static string AudioTextPath
    {
        get
        {
            return audioTextPrefix + audioTextPathMiddle + audioTextPathPostfix;
        }
    }
    
    //public AudioManager()
    //{
    //    LoadAudioClip();
    //}

    public void Init()
    {
        LoadAudioClip();
    }

    private void LoadAudioClip()
    {
        TextAsset ta = Resources.Load<TextAsset>(audioTextPathMiddle);
        string[] lines = ta.text.Split('\n');

        audioClipDict = new Dictionary<string, AudioClip>();
        foreach(string line in lines)
        {
            if (string.IsNullOrEmpty(line))
                continue;
            string[] keyValue = line.Split(',');
            string key = keyValue[0];
            AudioClip value = Resources.Load<AudioClip>(keyValue[1]);
            audioClipDict.Add(key, value);
        }

    }

    public void Play(string name)
    {
        if (isMute)
            return;
        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if(ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, Vector3.zero);
        }
    }

    public void Play(string name, Vector3 position)
    {
        if (isMute)
            return;
        AudioClip ac;
        audioClipDict.TryGetValue(name, out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, position);
        }
    }
}
