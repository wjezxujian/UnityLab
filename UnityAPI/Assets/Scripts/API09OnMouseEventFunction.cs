using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API09OnMouseEventFunction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        print("Down" + gameObject);
    }

    private void OnMouseUp()
    {
        print("Up" + gameObject);
    }

    private void OnMouseDrag()
    {
        print("Drag" + gameObject);
    }

    private void OnMouseEnter()
    {
        print("Enter" + gameObject);
    }

    private void OnMouseExit()
    {
        print("Exit" + gameObject);
    }

    private void OnMouseOver()
    {
        print("Over" + gameObject);
    }

    private void OnMouseUpAsButton()
    {
        print("Button" + gameObject);
    }
}
