using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ArchieventmentSystem : IGameSystem
{
    private int mEnemyKilledCount = 0;
    private int mSoldierKilledCount = 0;
    private int mMaxStageLv = 1;

    public override void Init()
    {
        //throw new NotImplementedException();
        GameFacade.Instance.RegisterObserver(GameEventType.EmemyKilled, new EnemyKilledObserverArchievement(this));
        GameFacade.Instance.RegisterObserver(GameEventType.SoldierKilled, new SoldierKilledObserverArchievement(this));
        GameFacade.Instance.RegisterObserver(GameEventType.NewStage, new NewStageObserverArchievement(this));
    }

    public override void Release()
    {
        //throw new NotImplementedException();
    }

    public override void Update()
    {
        //throw new NotImplementedException();
    }

    public void AddEnemyKilledCount(int number = 1)
    {
        mEnemyKilledCount += number;
        Debug.Log("EnemyKilledCount: " + mEnemyKilledCount);
    }

    public void AddSoldierKilledCount(int number = 1)
    {
        mSoldierKilledCount += number;
        Debug.Log("SoldierKilledCount: " + mSoldierKilledCount);
    }

    public void SetMaxStageLv(int stageLv)
    {
        if(stageLv > mMaxStageLv)
        {
            mMaxStageLv = stageLv;
        }

        Debug.Log("MaxStageLv: " + mMaxStageLv);
    }

    public AchievementMemento CreateMemento()
    {
        //PlayerPrefs.SetInt("EnemyKilledCount", mEnemyKilledCount);
        //PlayerPrefs.SetInt("SoldierKilledCount", mSoldierKilledCount);
        //PlayerPrefs.SetInt("MaxStageLv", mMaxStageLv);

        AchievementMemento memento = new AchievementMemento();
        memento.enemyKilledCount = mEnemyKilledCount;
        memento.soldierKilledCount = mSoldierKilledCount;
        memento.maxStageLv = mMaxStageLv;

        return memento;
    }

    public void SetMemento(AchievementMemento memento)
    {
        mEnemyKilledCount = memento.enemyKilledCount;
        mSoldierKilledCount = memento.soldierKilledCount;
        mMaxStageLv= memento.maxStageLv;
    }
}
