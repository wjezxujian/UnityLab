using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API10Mathf : MonoBehaviour {
    public Transform cube;

    public int a = 8;
    public int b = 20;
    public float t = 0;



	// Use this for initialization
	void Start () {
        //print(Mathf.Deg2Rad);
        //print(Mathf.Rad2Deg);
        //print(Mathf.Epsilon);
        //print(Mathf.Infinity);
        //print(Mathf.NegativeInfinity);
        //print(Mathf.PI);


        //print("======Approximately======");
        //print(Mathf.Approximately(1.0f, 1.0000000000000000000001f));

        //print("=======DeltaAngle========");
        //print(Mathf.DeltaAngle(1081, 90));


        //print("===========EXP===========");
        //print(Mathf.Exp(1));
        //print(Mathf.Exp(2));
        //print(Mathf.Exp(6));

        //print("Floor====================");
        //print(Mathf.Floor(10.0f));
        //print(Mathf.Floor(10.2f));
        //print(Mathf.Floor(10.6f));
        //print(Mathf.Floor(-10.0f));
        //print(Mathf.Floor(-10.2f));
        //print(Mathf.Floor(-10.6f));

        //print("Clamp=====================");
        //print(Mathf.Clamp(Time.time, 0, 3));

        //print("Clamp01===================");
        //print(Mathf.Clamp01(Time.time));

        //print(Mathf.ClosestPowerOfTwo(2));
        //print(Mathf.ClosestPowerOfTwo(3));
        //print(Mathf.ClosestPowerOfTwo(5));
        //print(Mathf.ClosestPowerOfTwo(6));
        //print(Mathf.Max(1, 2));
        //print(Mathf.Max(1, 2, 5, 3, 10));
        //print(Mathf.Min(1, 2));
        //print(Mathf.Min(1, 2, 5, 3, 10));
        //print(Mathf.Pow(4, 3));
        //print(Mathf.Sqrt(3));

        cube.position = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //print("Clamp=====================");
        //print(Mathf.Clamp(Time.time, 0, 3));

        //float t = Mathf.Clamp01(Time.time % 1.0f);
        //print(t);
        //float value = (Mathf.Lerp(a, b, t));
        //print(value);


        //float x = cube.position.x;
        //float newX = Mathf.Lerp(x, 10, Time.deltaTime);
        //cube.position = new Vector3(newX, 0, 0);

        //float x = cube.position.x;
        //float newX = Mathf.MoveTowards(x, 10, 0.02f);
        //cube.position = new Vector3(newX, 0, 0);

        //print(newX);

        //print(Mathf.PingPong(Time.time, 5));
        cube.position = new Vector3(Mathf.PingPong(Time.time * 3, 10), 0, 0);

    }
}
