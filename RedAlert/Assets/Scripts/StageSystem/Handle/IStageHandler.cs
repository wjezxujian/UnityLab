using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IStageHandler
{
    protected int mLv;                      //关卡ID
    protected int mCountToFinshed;

    protected IStageHandler mNextHandler;   //下一关卡
    protected StageSystem mStageSystem;

    public IStageHandler(StageSystem stageSystem, int lv, int countToFinshed)
    {
        mStageSystem = stageSystem;
        mLv = lv;
        mCountToFinshed = countToFinshed;
    }

    public IStageHandler SetNextHandler(IStageHandler handler)
    {
        mNextHandler = handler;
        return mNextHandler;
    }

    public void Handler(int level)
    {
        if (level == mLv)
        {
            UpdateStage();
            CheckIsFinshed();
        }
        else if(mNextHandler != null)
        {
            mNextHandler.Handler(level);
        }
    }

    protected virtual void UpdateStage()
    {

    }

    protected virtual void CheckIsFinshed()
    {
        if(mStageSystem.GetCountOfEnemyKilled() >= mCountToFinshed)
        {
            mStageSystem.EneterNextStage();
        }
    }
}
