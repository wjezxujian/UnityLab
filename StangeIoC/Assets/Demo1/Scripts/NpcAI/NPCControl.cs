using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : MonoBehaviour
{
    public Transform[] wayPoints;


    private FSMSystem fsm;
    private GameObject player;
    private GameObject npc;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InitFSM();
    }

    // Update is called once per frame
    void Update()
    {
        fsm.CurrentState.DoUpdate();
    }

    /// <summary>
    /// 初始化状态机
    /// </summary>
    void InitFSM()
    {
        fsm = new FSMSystem();

        PatrolState patrolState = new PatrolState(wayPoints, this.gameObject, player);
        patrolState.AddTransition(Transition.SawPlayer, StateID.Chase);

        ChaseState chaseState = new ChaseState(this.gameObject, player);
        chaseState.AddTransition(Transition.LostPlayer, StateID.Patrol);

        fsm.AddState(patrolState);
        fsm.AddState(chaseState);

        fsm.Start(patrolState.ID);
    }

}
