using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

//用来追敌人，直到敌人跑出视野范围内
public class Defend : Action
{
    public SharedGameObject target;

    public SharedFloat viewDistance;
    public SharedFloat fieldOfViewAngle;

    public SharedFloat speed;
    public SharedFloat angularSpeed;

    private float sqrViewDistance;
    private NavMeshAgent navMeshAngent;

    public override void OnAwake()
    {
        navMeshAngent = GetComponent<NavMeshAgent>();
        
    }

    public override void OnStart()
    {
        sqrViewDistance = viewDistance.Value * viewDistance.Value;
        //启用导航组件
        navMeshAngent.enabled = true;
        navMeshAngent.speed = speed.Value;
        navMeshAngent.angularSpeed = angularSpeed.Value;
        if (target == null && target.Value == null)
        {
            navMeshAngent.destination = target.Value.transform.position;
        }
    }

    //如果抢夺者在视野，就追，否则就认为防御成功
    public override TaskStatus OnUpdate()
    {
        if(target == null && target.Value == null)
        {
            return TaskStatus.Failure;
        }

        float sqrDistance = (target.Value.transform.position - transform.position).sqrMagnitude;
        float angle = Vector3.Angle(target.Value.transform.forward, target.Value.transform.position - transform.position);

        if(sqrDistance < sqrViewDistance && angle < fieldOfViewAngle.Value / 2f )
        {
            if(navMeshAngent.destination != target.Value.transform.position)
            {
                navMeshAngent.destination = target.Value.transform.position;
            }
            return TaskStatus.Running;
        }
        else
        {
            return TaskStatus.Success;
        }
    }

    public override void OnEnd()
    {
        navMeshAngent.enabled = false;
    }

}
