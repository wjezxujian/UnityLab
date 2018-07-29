using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API12Vector2 : MonoBehaviour {

    // Use this for initialization
    void Start() {
        //print(Vector2.down);
        //print(Vector2.up);
        //print(Vector3.left);
        //print(Vector3.right);
        //print(Vector3.zero);

        //Vector2 a = new Vector2(2, 2);
        //Vector2 b = new Vector2(3, 4);
        //print(a.magnitude);
        //print(a.sqrMagnitude);
        //print(b.magnitude);
        //print(b.sqrMagnitude);

        //print(a.normalized);
        //print(b.normalized);

        //print(a.x + "," + a.y);
        //print(b[0] + "," + b[1]);

        //a.Normalize();
        //b.Normalize();

        //print(a.x + "," + a.y);
        //print(b[0] + "," + b[1]);

        Vector2 a = new Vector2(2, 2);
        Vector2 b = new Vector2(3, 4);
        Vector2 c = new Vector2(3, 0);

        //print(Vector2.Angle(a, b));
        //print(Vector2.Angle(a, c));
        //print(Vector2.ClampMagnitude(c, 2));
        //print(Vector2.Distance(b, c));

        //print(Vector2.Lerp(a, b, 0.5f));
        //print(Vector2.LerpUnclamped(a, b, 0.5f));

        //print(Vector2.Lerp(a, b, 2f));
        //print(Vector2.LerpUnclamped(a, b, 2f));

        //print(Vector2.Max(a, b));
        //print(Vector2.Min(a, b));

        //print(Vector2.Scale(a, b));

        
    }


    public Vector2 a = new Vector2(2, 2);
    public Vector2 target = new Vector2(10, 3);
	// Update is called once per frame
	void Update () {
        a = Vector2.MoveTowards(a, target, Time.deltaTime);
	}
}
