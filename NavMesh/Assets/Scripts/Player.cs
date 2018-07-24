using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour 
{
    private NavMeshAgent agent;
    public Transform target;
    public float rotateSmoothing = 7.0f;
    public float speed = 4f;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        //agent.destination = target.position; 
        //agent.updatePosition = false;
        //agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }

        }

        //agent.nextPosition = transform.position;
        //Move();
    }


    private void Move()
    {
        if(agent.remainingDistance > 0.0001f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(agent.desiredVelocity), rotateSmoothing);
            transform.Translate(Vector3.forward * agent.speed * Time.deltaTime);
        }
        
    }
}
