using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API08Coroutine : MonoBehaviour {
    public GameObject cube;
    private IEnumerator ie;
	// Use this for initialization
	void Start () {
        //print("haha");

        ////ChangeColor();
        //StartCoroutine(ChangeColor2());
  
        //print("hahaha");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            ie = Fade();
            StartCoroutine(ie);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            StopCoroutine(ie);
        }


	}

    IEnumerator Fade()
    {
        for(; ; )
        {
            //cube.GetComponent<MeshRenderer>().material.color = new Color(i, i, i, i);
            Color color = cube.GetComponent<MeshRenderer>().material.color;
            Color newColor = Color.Lerp(color, Color.red, 0.02f);
            cube.GetComponent<MeshRenderer>().material.color = newColor;
            yield return new WaitForSeconds(0.02f);
            if(Mathf.Abs(Color.red.g -newColor.g ) <= 0.01)
            {
                break;
            }
        }
    }

    //Coroutines
    //1,返回值是IEnumerator
    //2,返回参数的时候使用yield return null/0;
    //3,协程方法的调用StartCoroutine(method());
    IEnumerator ChangeColor2()
    {
        print("hahaColor");

        yield return new WaitForSeconds(3);

        cube.GetComponent<MeshRenderer>().material.color = Color.blue;
        print("hahaColor");
        yield return null;
    }

    void ChangeColor()
    {
        print("hahaColor");
        cube.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
