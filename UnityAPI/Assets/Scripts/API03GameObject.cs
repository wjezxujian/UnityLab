using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API03GameObject : MonoBehaviour {
    public GameObject gameObj;
    public GameObject prefab;

	// Use this for initialization
	void Start ()
    {
        //1.第一种方法
        //gameObj = new GameObject("Sphere");

        //2.第二种方法
        //根据Prefab实例化
        //也可以根据另外一个游戏物体
        //GameObject.Instantiate(prefab);

        //3.第三种创建方法
        //gameObj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        ////gameObj.AddComponent<Rigidbody>();
        ////gameObj.AddComponent<API01EvenetFunction>();
        //gameObj.transform.Translate(new Vector3(0, 1, 2));

        ////activeInHierarchy是否处理激活状态（受父对象影响）
        ////active自身是否处于激活状态
        //Debug.Log(gameObj.activeInHierarchy);
        //gameObj.SetActive(false);
        //Debug.Log(gameObj.activeInHierarchy);

        //Debug.Log(gameObj.name);
        //Debug.Log(gameObj.transform.name);

        //Light light = GameObject.FindObjectOfType<Light>();
        //light.enabled = false;

        Transform[] transform = FindObjectsOfType<Transform>(); //不查找未激活的Object
        foreach(var tran in transform)
        {
            Debug.Log(tran.name);
        }



    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
