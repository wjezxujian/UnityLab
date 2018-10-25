using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum EnemyTransition
{
    NullTransitionID = 0,
    CanAttack,
    LostSoldier,
}

public enum EnemyStateID
{
    NullState = 0,
    Chase,
    Attack
}

public abstract class IEnemyState
{
    protected Dictionary<EnemyTransition, EnemyStateID> mMap = new Dictionary<EnemyTransition, EnemyStateID>();
    protected EnemyStateID mStateID;
    protected ICharacter mCharacter;
    protected EnemyFSMSystem mFSM;
    protected Vector3 mTargetPosition;

    public EnemyStateID stateID { get { return mStateID; } }
    public ICharacter Character { set { mCharacter = value; } get { return mCharacter; } }

    public IEnemyState(EnemyFSMSystem fsm, ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
        mTargetPosition = GameFacade.Instance.GetEnemyTargetPosition();
    }

    public void AddTransition(EnemyTransition trans, EnemyStateID id)
    {
        if (trans == EnemyTransition.NullTransitionID)
        {
            Debug.LogError("EnemyState Error: trans不能为空");
            return;
        }
        if (id == EnemyStateID.NullState)
        {
            Debug.LogError("EnemyState Error: id状态不能为空");
            return;
        }
        if (mMap.ContainsKey(trans))
        {
            Debug.LogError("EnemyState Error:" + trans + " 已经添加上了");
            return;
        }
        mMap.Add(trans, id);
    }

    public void DeleteTransition(EnemyTransition trans)
    {
        if (mMap.ContainsKey(trans) == false)
        {
            Debug.LogError("删除转换条件的时候，转换条件：[" + trans + "]不存在！");
            return;
        }

        mMap.Remove(trans);
    }

    public EnemyStateID GetOutPutState(EnemyTransition trans)
    {
        if (!mMap.ContainsKey(trans))
        {
            Debug.LogError("：[" + trans + "]不存在！");
            return EnemyStateID.NullState;
        }


        return mMap[trans];

    }

    public virtual void DoBeforeEntering() { }
    public virtual void DoBeforeLeaving() { }
    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);
}
