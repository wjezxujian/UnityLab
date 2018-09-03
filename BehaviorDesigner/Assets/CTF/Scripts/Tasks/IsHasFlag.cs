using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class IsHasFlag : Conditional
{
    private Offense offense;

    public override void OnAwake()
    {
        offense = GetComponent<Offense>();
    }

    public override TaskStatus OnUpdate()
    {
        if(offense.hasFlag)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }

}
