using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API02Time : MonoBehaviour {
    public Transform Cube;
    public int runCount = 10000000;

	// Use this for initialization
	void Start () {
        //Debug.Log("Time.DeltaTime:" + Time.deltaTime);
        //Debug.Log("Time.fiexedDeltaTime:" + Time.fixedDeltaTime);
        //Debug.Log("Time.fixedTime:" + Time.fixedTime);
        //Debug.Log("Time.frameCount:" + Time.frameCount);
        //Debug.Log("Time.realtimeSinceStarup:" + Time.realtimeSinceStartup);
        //Debug.Log("Time.smoothDeltaTime:" + Time.smoothDeltaTime);
        //Debug.Log("Time.time:" + Time.time);
        //Debug.Log("Time.timeScale:" + Time.timeScale);
        //Debug.Log("Time.timeSinceLevelLoad:" + Time.timeSinceLevelLoad);
        //Debug.Log("Time.unscaledTime:" + Time.unscaledTime);

        PerformanceTest();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Time.DeltaTime:" + Time.deltaTime);
        //Debug.Log("Time.fiexedDeltaTime:" + Time.fixedDeltaTime);
        //Debug.Log("Time.fixedTime:" + Time.fixedTime);
        //Debug.Log("Time.frameCount:" + Time.frameCount);
        //Debug.Log("Time.realtimeSinceStarup:" + Time.realtimeSinceStartup);
        //Debug.Log("Time.smoothDeltaTime:" + Time.smoothDeltaTime);
        //Debug.Log("Time.time:" + Time.time);
        //Debug.Log("Time.timeScale:" + Time.timeScale);
        //Debug.Log("Time.timeSinceLevelLoad:" + Time.timeSinceLevelLoad);
        //Debug.Log("Time.unscaledTime:" + Time.unscaledTime);

        Cube.Translate(Vector3.forward * Time.deltaTime * 3);
        //Time.timeScale = 1/3f;    //慢动作
        Time.timeScale = 0;         //暂停       

	}

    void PerformanceTest()
    {
        float time1 = Time.realtimeSinceStartup;
        for (int i = 0; i < runCount; ++i)
        {
            Method0();
        }

        Debug.Log("Method0 Used Time:" + (Time.realtimeSinceStartup - time1));
        time1 = Time.realtimeSinceStartup;

        time1 = Time.realtimeSinceStartup;
        for (int i = 0; i < runCount; ++i)
        {
            Method1();
        }

        Debug.Log("Method1 Used Time:" + (Time.realtimeSinceStartup - time1));
        time1 = Time.realtimeSinceStartup;

        for (int i = 0; i < runCount; ++i)
        {
            Method2();
        }

        Debug.Log("Method2 Used Time:" + (Time.realtimeSinceStartup - time1));
    }

    void Method0()
    {

    }

    void Method1()
    {
        int i = 2;
        int j = 2;
        i = i * j;

    }

    void Method2()
    {
        int i = 2;
        int j = 2;
        i = i * j;
    }
}
