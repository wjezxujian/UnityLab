using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class EnemyKilledObserverStageSystem :  IGameEventObserver
{
    private EnemyKilledSubject mSubject;
    private StageSystem mStageSystem;

    public EnemyKilledObserverStageSystem(StageSystem ss)
    {
        mStageSystem = ss;
    }

    public override void Update()
    {
        mStageSystem.countOfEnemeyKilled = mSubject.killedCount;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as EnemyKilledSubject;
    }
}
