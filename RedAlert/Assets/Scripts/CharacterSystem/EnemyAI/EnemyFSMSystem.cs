using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyFSMSystem
{
    private List<IEnemyState> mStates = new List<IEnemyState>();

    private IEnemyState mCurrentState;

    public IEnemyState CurrentState { get { return mCurrentState; } }

    public void AddState(params IEnemyState[] states)
    {
        foreach (IEnemyState s in states)
        {
            AddState(s);
        }
    }

    public void AddState(IEnemyState state)
    {
        if (state == null)
        {
            Debug.LogError("要添加的状态为空");
            return;
        }

        if (mStates.Count == 0)
        {
            mStates.Add(state);
            mCurrentState = state;
            mCurrentState.DoBeforeEntering();
            return;
        }
        foreach (IEnemyState s in mStates)
        {
            if (s.stateID == state.stateID)
            {
                Debug.LogError("要添加的状态ID[" + s.stateID + "]已经添加"); return;
            }
        }

        mStates.Add(state);
    }

    public void DeleteState(IEnemyState state)
    {
        if (state == null)
        {
            Debug.LogError("要删除的状态为空");
            return;
        }

        if (mStates.Count == 0 || !mStates.Contains(state))
        {
            Debug.LogError("要删除的状态ID[" + state + "]不存在");
        }

        mStates.Remove(state);
    }

    public void PerformTransition(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTransitionID)
        {
            Debug.LogError("要执行的转换条件为空：" + trans);
            return;
        }

        EnemyStateID nextStateID = mCurrentState.GetOutPutState(trans);
        if (nextStateID == EnemyStateID.NullState)
        {
            Debug.LogError("在转换条件 [" + trans + "] 下， 没有对应的转换状态");
            return;
        }

        foreach (IEnemyState s in mStates)
        {
            if (s.stateID == nextStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = s;
                mCurrentState.DoBeforeEntering();
                return;
            }
        }
    }
}
