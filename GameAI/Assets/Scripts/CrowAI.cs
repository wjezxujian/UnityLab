using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowAI : MonoBehaviour
{
    public float speed = 3;
    public Vector3 velocity = Vector3.forward;
    private Vector3 startVelocity;
    private Transform target;

    public float m = 1;
    public Vector3 sumForce = Vector3.zero;

    public float separationDistance = 3;
    public float separationWeight = 1;

    public float alignmentDistance = 6;
    public float alignmentWeight = 1;

    public float cohesionWeight = 1;

    public Vector3 separationForce = Vector3.zero; //分离的力
    public Vector3 alignmentForce = Vector3.zero;   //队列的力
    public Vector3 cohesionForce = Vector3.zero;    //聚集的力

    public List<GameObject> separationNeighbors = new List<GameObject>();
    public List<GameObject> alignmentNeighbors = new List<GameObject>();

    public float checkInterval = 0.2f;

    public float animRandomTime = 2f;
    private Animation anim;

    // Use this for initialization
    private void Start()
    {
        startVelocity = velocity;
        target = GameObject.Find("Target").transform;

        InvokeRepeating("CalcForce", 0, checkInterval);
    
        anim = GetComponentInChildren<Animation>();
        Invoke("PlayAnim", Random.Range(0, animRandomTime));
    }

    void PlayAnim()
    {
        anim.Play();
    }
     
    void CalcForce()
    {
        sumForce = Vector3.zero;
        separationForce = Vector3.zero;
        alignmentForce = Vector3.zero;
        cohesionForce = Vector3.zero;

        separationNeighbors.Clear();
        Collider[] colliders = Physics.OverlapSphere(transform.position, separationDistance);
        foreach(Collider c in colliders)
        {
            if(c != null && c.gameObject != this.gameObject)
            {
                separationNeighbors.Add(c.gameObject);
            }
        }

        //计算分离的力
        foreach(GameObject neighbor in separationNeighbors)
        {
            Vector3 dir = transform.position - neighbor.transform.position;
            separationForce += dir.normalized / dir.magnitude;
        }

        if(separationNeighbors.Count > 0)
        {
            separationForce *= separationWeight;
            sumForce += separationForce;
        }

        //计算队列的力
        alignmentNeighbors.Clear();
        colliders = Physics.OverlapSphere(transform.position, alignmentDistance);
        foreach(Collider c in colliders)
        {
            if(c != null && c.gameObject != this.gameObject)
            {
                alignmentNeighbors.Add(c.gameObject);
            }
        }

        Vector3 avgDir = Vector3.zero;
        foreach(GameObject neighbor in alignmentNeighbors)
        {
            avgDir += neighbor.transform.forward;
        }

        if(alignmentNeighbors.Count > 0)
        {
            avgDir /= alignmentNeighbors.Count;
            alignmentForce = avgDir - transform.forward;

            alignmentForce *= alignmentWeight;
            sumForce += alignmentForce;
        }

        //聚集的力
        if (alignmentNeighbors.Count > 0)
        {
            Vector3 center = Vector3.zero;
            foreach (GameObject n in alignmentNeighbors)
            {
                center += n.transform.position;
            }


            center /= alignmentNeighbors.Count;
            Vector3 centeDir = center - transform.position;
            centeDir *= cohesionWeight;
            cohesionForce += centeDir;
            sumForce += cohesionForce;
        }

        //保持恒定飞行速度的力
        //Vector3 engineForce = startVelocity - velocity;
        //sumForce += engineForce * 0.1f;
        Vector3 targetDir = target.position - transform.position;
        sumForce += (targetDir.normalized - transform.forward);


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = sumForce / m;
        velocity += a * Time.deltaTime;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), Time.deltaTime);

        transform.Translate(velocity * Time.deltaTime, Space.World);
    }
}
