using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API14Quaternion : MonoBehaviour {
    public Transform cube;

    public Transform player;
    public Transform enemy;

	// Use this for initialization
	void Start () {
        //print(cube.eulerAngles);
        //print(cube.rotation);

        //cube.eulerAngles = new Vector3(45, 45, 45);
        //cube.rotation = Quaternion.Euler(new Vector3(45, 45, 45));
        //print(cube.rotation.eulerAngles);
	}

    private bool isRotation = false;
    private Quaternion rotation;
    // Update is called once per frame
    void Update () {

		if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 dir = enemy.position - player.position;
            //player.rotation = Quaternion.LookRotation(dir);
            //player.rotation = Quaternion.LookRotation(dir, player.up);

            rotation = Quaternion.LookRotation(dir);
            isRotation = true;
        }

        if(isRotation)
        {
            //向量都使用Slerp，求面Lerp

            //player.rotation = Quaternion.Lerp(player.rotation, rotation, Time.deltaTime);
            player.rotation = Quaternion.Slerp(player.rotation, rotation, Time.deltaTime);
        }
        
    }
}
