using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private SceneStateController mContorller;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        mContorller = new SceneStateController();
        mContorller.SetState(new StartState(mContorller), false);
    }

    // Update is called once per frame
    void Update()
    {
        if(mContorller != null)
            mContorller.StateUpdate();
    }
}
