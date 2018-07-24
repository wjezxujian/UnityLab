using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API01EvenetFunction : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }


    // Use this for initialization
    void Start()
    {
        Debug.Log("Start");
    }

    void Reset()
    {
        Debug.Log("Reset");
    }

    //private void FixedUpdate()
    //{
    //    Debug.Log("FixedUpdate");
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Debug.Log("Update");
    //}

    //private void LateUpdate()
    //{
    //    Debug.Log("LateUpdate");
    //}

    private void OnApplicationPause(bool pause)
    {
        Debug.Log("OnApplicationPause Status:" + pause.ToString());
    }

    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestory");
    }

    


    

}
