using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API11Input : MonoBehaviour {
    public Transform cube;
	// Use this for initialization
	void Start () {
        print(Input.touchSupported);
        print(Input.touchPressureSupported);
        print(Input.simulateMouseWithTouches);

	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    print("GetKeyDown");
        //}

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    print("GetKey");
        //}

        //if(Input.GetKeyUp(KeyCode.Space))
        //{
        //    print("GetKeyUp");
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    print("Pressed left Click");
        //}

        //if (Input.GetMouseButtonDown(1))
        //{
        //    print("Pressed right Click");
        //}

        //if (Input.GetMouseButtonDown(2))
        //{
        //    print("Pressed middle click");
        //}

        //if (Input.GetMouseButton(0))
        //{
        //    print("Pressed left Click");
        //}

        //if(Input.GetMouseButton(1))
        //{
        //    print("Pressed right Click");
        //}

        //if(Input.GetMouseButton(2))
        //{
        //    print("Pressed middle click");
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    print("Pressed left Click");
        //}

        //if (Input.GetMouseButtonUp(1))
        //{
        //    print("Pressed right Click");
        //}

        //if (Input.GetMouseButtonUp(2))
        //{
        //    print("Pressed middle click");
        //}


        //if(Input.GetButtonDown("Fire1"))
        //{
        //    print("Fire1 Down");
        //}

        //if(Input.GetButton("Fire1"))
        //{
        //    print("Fire1");
        //}

        //if(Input.GetButtonUp("Fire1"))
        //{
        //    print("Fire1 Up");
        //}

        //if(Input.GetButton("Horizontal"))
        //{
        //    print(Input.GetAxis("Horizontal"));
        //}

        //if(Input.GetButton("Vertical"))
        //{
        //    print(Input.GetAxis("Vertical"));
        //}

        //cube.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal"));
        //cube.Translate(Vector3.forward * Time.deltaTime * Input.GetAxisRaw("Vertical"));

        //if(Input.anyKeyDown)
        //{
        //    print("Any Key Down");
        //}

        //print(Input.mousePosition);


        //GetTouch


        if(Input.touchCount > 0)
        {
            Touch[] touchs = Input.touches;
            foreach(Touch touch in touchs)
            {
                print(touch.position);
            }
        }

    }
}
