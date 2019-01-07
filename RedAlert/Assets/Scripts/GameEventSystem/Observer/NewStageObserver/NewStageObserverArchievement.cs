using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class NewStageObserverArchievement : IGameEventObserver
{
    private NewStageSubject mSubject;
    private ArchieventmentSystem mArchSystem;

    public NewStageObserverArchievement(ArchieventmentSystem archSystem)
    {
        mArchSystem = archSystem;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        mSubject = sub as NewStageSubject;
    }

    public override void Update()
    {
        mArchSystem.SetMaxStageLv(mSubject.stageCount);
    }
}
