using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//状态转换条偶见
public enum Transition
{
    NullTransition = 0,
    SawPlayer,              //看到主角
    LostPlayer,             //跟丢主角
}

//状态ID，是每一个状态的唯一标识，一个状态有一个stateid，而且其他的状态不可重复
public enum StateID
{
    NullStateID = 0,
    Patrol, //巡逻转台
    Chase,  //追主角状态
}

public abstract class FSMState
{
    protected StateID stateID;
    public StateID ID
    {
        get
        {
            return stateID;
        }
    }

    protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();

    public FSMSystem fsm;

    public void AddTransition(Transition trans, StateID id)
    {
        if (trans == Transition.NullTransition || id == StateID.NullStateID)
        {
            Debug.LogError("Transition or stateid is null");
            return;
        }

        if (map.ContainsKey(trans))
        {
            Debug.Log("State " + stateID + " is already transition " + trans);
        }


        map.Add(trans, id);
    }

    public void DeleteTransition(Transition trans)
    {
        if (!map.ContainsKey(trans))
        {
            Debug.LogWarning("The transition " + trans + "you want to delete is not exit in map!");
        }

        map.Remove(trans);
    }

    //根据传递过来的转换条件，判断一下是否可以发生转换
    public StateID GetOutputState(Transition trans)
    {
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }

        return StateID.NullStateID;
    }

    public virtual void DoBeforeEntering() {}

    public virtual void DoBefoteLeaving() {}

    //当状态机处于当前状态中，会一直被条用
    public abstract void DoUpdate();
}
 