using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{
    private int targetWaypoint;
    private Transform[] wayPoints;
    private GameObject npc;
    private Rigidbody npcRdg;

    private GameObject player;

    public PatrolState(Transform[] wayPoints, GameObject npc, GameObject player)
    {
        stateID = StateID.Patrol;
        targetWaypoint = 0;

        this.wayPoints = wayPoints;
        this.npc = npc;
        npcRdg = npc.GetComponent<Rigidbody>();

        this.player = player;
    }

    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();

        Debug.Log("Entering state " + ID);
    }

    public override void DoUpdate()
    {
        CheckTransition();
        PatrolMove();
    }

    //检查转换条件
    private void CheckTransition()
    {
        if(Vector3.Distance(player.transform.position, npc.transform.position) < 3)
        {
            fsm.PerformTransition(Transition.SawPlayer);
        }
    }

    //
    private void PatrolMove()
    {
        npcRdg.velocity = npc.transform.forward * 3;
        Transform targetTrans = wayPoints[targetWaypoint];
        Vector3 targetPosition = targetTrans.position;
        targetPosition.y = npc.transform.position.y;
        npc.transform.LookAt(targetPosition);
        if (Vector3.Distance(npc.transform.position, targetPosition) < 0.1f)
        {
            targetWaypoint++;
            targetWaypoint %= wayPoints.Length;
        }
    }
}
