using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void BoardcastMessage()
    {
        Debug.Log(this.gameObject + "BoardcastMessage");
    }

    void SendMessage()
    {
        Debug.Log(this.gameObject + "SendMessage");
    }

    void SendMessageUpdards()
    {
        Debug.Log(this.gameObject + "SendMessageUpdards");
    }
}
