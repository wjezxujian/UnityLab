using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour {
    public Transform target;
    public float speed = 1;
    public Vector3 velocity = Vector3.forward;
    public float animRandom = 2f;
    private Animation anim;

	// Use this for initialization
	private IEnumerator Start () {
        target = GameObject.Find("Target").transform;

        anim = GetComponentInChildren<Animation>();
        yield return new WaitForSeconds(Random.Range(0, animRandom));
        anim.Play();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(velocity * Time.deltaTime, Space.World);
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
	}
}
