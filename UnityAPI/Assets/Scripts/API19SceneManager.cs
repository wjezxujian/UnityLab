using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class API19SceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    bool isPress = false;
	// Update is called once per frame
	void Update () {
        AsyncOperation _operation = new AsyncOperation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor
                || Application.platform == RuntimePlatform.LinuxEditor)
            {
                //UnityEditor.EditorApplication.isPlaying = false;
                //SceneManager.LoadScene(1);

                _operation = SceneManager.LoadSceneAsync("02-MenuScene");
                isPress = true;
            }
        }

        if(isPress && !_operation.isDone)
        {
            print(_operation.progress);
        }
        
    }
}
