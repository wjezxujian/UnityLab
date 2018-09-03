using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

//用来判断目标是否在视野内
public class MyCanSeeObject : Conditional
{
    //判断是否在视野内的目标
    public Transform[] targets;

    public float fieldViewAngle = 90;
    public float viewDistance = 7;
    public SharedFloat sharedViewDistance = 7;

    public SharedTransform target;

    public override TaskStatus OnUpdate()
    {
        if(targets == null)
        {
            return TaskStatus.Failure;
        }

        foreach(var target in targets)
        {
            float distance = (target.position - transform.position).magnitude;

            float angle = Vector3.Angle(transform.forward, target.position - transform.position);

            if(distance < viewDistance && angle < fieldViewAngle)
            {
                this.target.Value = target;
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}
