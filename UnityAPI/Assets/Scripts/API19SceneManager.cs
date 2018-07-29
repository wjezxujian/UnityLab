using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class API19SceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print(SceneManager.sceneCount);
        print(SceneManager.sceneCountInBuildSettings);
        print(SceneManager.GetActiveScene().name);
        print(SceneManager.GetSceneByBuildIndex(1).name);

        SceneManager.activeSceneChanged += OnActiveSceneChanged;
        SceneManager.sceneLoaded += OnSceneLoaded;
	}

    void OnActiveSceneChanged(Scene a, Scene b)
    {
        print(a.name);
        print(b.name);
    }

    void OnSceneLoaded(Scene a, LoadSceneMode mode)
    {
        print(a.name + ", " + mode);

    }

    bool isPress = false;
    AsyncOperation _operation;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor
                || Application.platform == RuntimePlatform.LinuxEditor)
            {
                //UnityEditor.EditorApplication.isPlaying = false;
                //SceneManager.LoadScene(1);

                //_operation = SceneManager.LoadSceneAsync("02-MenuScene");
                //isPress = true;

                SceneManager.LoadScene(1);
            }
        }

        if(isPress && !_operation.isDone)
        {
            print(_operation.progress);
        }
        
    }
}
