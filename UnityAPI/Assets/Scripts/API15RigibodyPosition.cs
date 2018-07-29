using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API15RigibodyPosition : MonoBehaviour {
    public Rigidbody playerRgd;
    public Transform enemy;

    public int force = 8;

	// Use this for initialization
	void Start () {
		
	}

    private Quaternion rotation;
    private bool isRotation = false;
	// Update is called once per frame
	void Update () {
        //playerRgd.position = playerRgd.transform.position + Vector3.forward * Time.deltaTime;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Vector3 dir = enemy.position - playerRgd.position;
        //    //player.rotation = Quaternion.LookRotation(dir);
        //    //player.rotation = Quaternion.LookRotation(dir, player.up);

        //    rotation = Quaternion.LookRotation(dir);
        //    isRotation = true;
        //}

        //if (isRotation)
        //{
        //    //向量都使用Slerp，求面Lerp

        //    //player.rotation = Quaternion.Lerp(player.rotation, rotation, Time.deltaTime);
        //    playerRgd.MoveRotation(Quaternion.Lerp(playerRgd.rotation, rotation, Time.deltaTime));
        //}

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRgd.AddForce(Vector3.forward * force);
        }
        
    }
}
