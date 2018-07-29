using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API13Vector3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //测试Vector3.Slerp作用
        print("=============");
        print(Vector3.Slerp(new Vector3(1, 1, 0), new Vector3(-1, 1, 0), 0.5f));
    }

    private Vector3 mStart = new Vector3(-1, 1, 0);
    private Vector3 mEnd = new Vector3(1, 1, 0);
    // Update is called once per frame
    void Update () {
        //绘制坐标轴
        Debug.DrawLine(new Vector3(-100, 0, 0), new Vector3(100, 0, 0), Color.green);
        Debug.DrawLine(new Vector3(0, -100, 0), new Vector3(0, 100, 0), Color.green);
        Debug.DrawLine(new Vector3(0, 0, -100), new Vector3(0, 0, 100), Color.green);

        Debug.DrawLine(Vector3.zero, mStart, Color.red);
        Debug.DrawLine(Vector3.zero, mEnd, Color.red);
        Debug.DrawLine(mStart, mEnd, Color.red);
        for (int i = 1; i < 10; ++i)
        {
            Vector3 drawVec = Vector3.Slerp(mStart, mEnd, 0.1f * i);
            Debug.DrawLine(Vector3.zero, drawVec, Color.yellow);

        }
    }
}
