using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum SoldierTransition
{
    NullTransitionID = 0,
    SeeEnemy,
    NoEnemy,
    CanAttack
}

public enum SoldierStateID
{
    NullState = 0,
    Idle,
    Chase,
    Attack
}

public abstract class ISoldierState
{
    protected Dictionary<SoldierTransition, SoldierStateID> mMap = new Dictionary<SoldierTransition, SoldierStateID>();
    protected SoldierStateID mStateID;
    protected ICharacter mCharacter;
    protected SoldierFsmSystem mFSM;

    public SoldierStateID stateID { get { return mStateID; } }
    public ICharacter Character { set { mCharacter = value; } get { return mCharacter; } }

    public ISoldierState(SoldierFsmSystem fsm, ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }

    public void AddTransition(SoldierTransition trans, SoldierStateID id)
    {
        if(trans == SoldierTransition.NullTransitionID)
        {
            Debug.LogError("SoldierState Error: trans不能为空");
            return;
        }
        if(id == SoldierStateID.NullState)
        {
            Debug.LogError("SoldierState Error: id状态不能为空");
            return;
        }
        if(mMap.ContainsKey(trans))
        {
            Debug.LogError("SoldierState Error:" + trans + " 已经添加上了");
            return;
        }
        mMap.Add(trans, id);
    }

    public void DeleteTransition(SoldierTransition trans)
    {
        if(mMap.ContainsKey(trans) == false)
        {
            Debug.LogError("删除转换条件的时候，转换条件：[" + trans + "]不存在！");
            return;
        }

        mMap.Remove(trans);
    }

    public SoldierStateID GetOutPutState(SoldierTransition trans)
    {
        if (!mMap.ContainsKey(trans))
        {
            Debug.LogError("：[" + trans + "]不存在！");
            return SoldierStateID.NullState;
        }


        return mMap[trans];

    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }
    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);


}
