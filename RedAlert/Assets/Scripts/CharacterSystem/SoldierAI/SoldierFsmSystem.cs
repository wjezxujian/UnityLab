using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierFsmSystem
{
    private List<ISoldierState> mStates = new List<ISoldierState>();

    private ISoldierState mCurrentState;

    public ISoldierState CurrentState { get { return mCurrentState; } }

    public void AddState(params ISoldierState[] states)
    {
        foreach(ISoldierState s in states)
        {
           AddState(s);
        }
    }

    public void AddState(ISoldierState state)
    {
        if(state == null)
        {
            Debug.LogError("要添加的状态为空");
            return;
        }

        if(mStates.Count != 0 && mStates.Contains(state))
        {
            Debug.LogError("要添加的状态ID[" + state + "]已经存在");
        }

        mStates.Add(state);
    }

    public void DeleteState(ISoldierState state)
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

    public void PerformTransition(SoldierTransition trans)
    {
        if(trans == SoldierTransition.NullTransitionID)
        {
            Debug.LogError("要执行的转换条件为空：" + trans);
            return;
        }

        SoldierStateID nextStateID = mCurrentState.GetOutPutState(trans);
        if(nextStateID == SoldierStateID.NullState)
        {
            Debug.LogError("在转换条件 [" + trans + "] 下， 没有对应的转换状态");
            return;
        }

        foreach(ISoldierState s in mStates)
        {
            if(s.stateID == nextStateID)
            {
                mCurrentState.DoBeforeLeaving();
                mCurrentState = s;
                mCurrentState.DoBeforeEntering();
                return;
            }            
        }
    }


}
