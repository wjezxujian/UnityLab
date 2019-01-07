using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierKilledObserverArchievement : IGameEventObserver
{
    private ArchieventmentSystem mArchSystem;
    public  SoldierKilledObserverArchievement(ArchieventmentSystem archSystem)
    {
        mArchSystem = archSystem;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        return;
    }

    public override void Update()
    {
        mArchSystem.AddSoldierKilledCount();
    }
}
