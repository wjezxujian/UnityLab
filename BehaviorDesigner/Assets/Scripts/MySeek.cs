using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

//这个任务脚本的作用就是控制游戏物体到达目标位置
public class MySeek : Action
{
    //这个是我们要到达的目标位置
    public SharedTransform target;
    public float speed = 6;
    public SharedFloat sharedSpeed;
    public float arriveDistance = 0.1f;

    private float sqrArriveDistance;

    public override void OnStart()
    {
        sqrArriveDistance = arriveDistance* arriveDistance;
    }

    //当进入这个任务的时候，会一直调用这个方法，一直到任务结束
    //返回成功或者失败，任务结束。返回Running状态，任务继续
    //条用频率为每帧调用
    public override TaskStatus OnUpdate()
    {
        if(target == null || target.Value == null)
        {
            return TaskStatus.Failure;
        }

        //直接朝向目标位置
        transform.LookAt(target.Value.position);

        transform.position = Vector3.MoveTowards(transform.position, target.Value.position, sharedSpeed.Value * Time.deltaTime);
        if((target.Value.position - transform.position).sqrMagnitude < sqrArriveDistance)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Running;
        }
    }
}
