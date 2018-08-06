using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyToggle : MonoBehaviour {
    public GameObject isOnGameObject;
    public GameObject isOffGameObjeect;

    private Toggle myTottle;

	// Use this for initialization
	void Start () {
        myTottle = GetComponent<Toggle>();
        OnValueChange(myTottle.isOn);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnValueChange(bool isOn)
    {
        isOnGameObject.SetActive(isOn);
        isOffGameObjeect.SetActive(!isOn);
    }
}
