using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API04Message : MonoBehaviour {
    public GameObject target;

	// Use this for initialization
	void Start () {
        ////1.BroadcastMessage 广播消息
        target.BroadcastMessage("BoardcastMessage", null, SendMessageOptions.DontRequireReceiver);

        //2.SendMessage
        target.SendMessage("SendMessage", null, SendMessageOptions.DontRequireReceiver);

        //3.Send
        target.SendMessageUpwards("SendMessageUpdards", null, SendMessageOptions.DontRequireReceiver);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
