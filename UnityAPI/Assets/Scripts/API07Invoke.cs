using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API07Invoke : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print("开始执行攻击目标");
        //Invoke("Attack", 3);
        InvokeRepeating("Attack", 4, 2);
	}
	
	// Update is called once per frame
	void Update () {

        bool isInvoking = IsInvoking("Attack");
        //print("是否存在Attack调用：" + isInvoking);
        //if (isInvoking)
        //{
        //    CancelInvoke();
        //}

    }

    void Attack()
    {
        print("攻击目标");
    }
}
