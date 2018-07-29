using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVector2
{
    public float x;
    public float y;

    public NewVector2(Vector2 point)
    {
        x = point.x;
        y = point.y;
    }
}

public class NewVector3
{
    public float x;
    public float y;
    public float z;

    public NewVector3(Vector3 point)
    {
        x = point.x;
        y = point.y;
        z = point.z;
    }
}

public class API13Random : MonoBehaviour {
    public Transform cube;
    public List<Vector2> circlePoints;
    public List<Vector3> spherePoints;

	// Use this for initialization
	void Start () {
        //Random.InitState((int)System.DateTime.Now.Ticks);
	}
	
	// Update is called once per frame
	void Update () {
        //print(Random.Range(4, 10));
        //print(Random.Range(4.0f, 10.0f));

        Debug.DrawLine(new Vector3(-100, 0, 0), new Vector3(100, 0, 0), Color.green);
        Debug.DrawLine(new Vector3(0, -100, 0), new Vector3(0, 100, 0), Color.green);
        Debug.DrawLine(new Vector3(0, 0, -100), new Vector3(0, 0, 100), Color.green);

        Debug.DrawLine(new Vector3(2, 0, 0), new Vector3(2.01f, 0, 0), Color.red);
        //Debug.DrawLine(new Vector3(2, 0, 0), new Vector3(3, 0, 0), Color.red);
        //Debug.DrawLine(new Vector3(2, 0, 0), new Vector3(3, 0, 0), Color.red);


        if (Input.GetKey(KeyCode.Space))
        {
            //print(Random.Range(4, 100));
            Vector2 point2 = Random.insideUnitCircle;
            circlePoints.Add(point2);

            Vector3 point3 = Random.insideUnitSphere;
            spherePoints.Add(point3);
        }

        foreach (Vector2 point in circlePoints)
        {
            Debug.DrawLine(new Vector3(point.x, point.y, 0), new Vector3(point.x + 0.01f, point.y + 0.01f, 0), Color.red);
        }

        foreach (Vector3 point in spherePoints)
        {
            Debug.DrawLine(new Vector3(point.x, point.y, point.z), new Vector3(point.x + 0.01f, point.y + 0.01f, point.z + 0.01f), Color.red);
        }
    }
}
