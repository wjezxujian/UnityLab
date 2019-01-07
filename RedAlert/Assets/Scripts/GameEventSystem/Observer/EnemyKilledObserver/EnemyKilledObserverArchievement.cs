using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class EnemyKilledObserverArchievement : IGameEventObserver
{
    //private EnemyKilledSubject mSubject;
    private ArchieventmentSystem mArchSystem;

    public EnemyKilledObserverArchievement(ArchieventmentSystem archSystem)
    {
        mArchSystem = archSystem;
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        return;
    }

    public override void Update()
    {
        mArchSystem.AddEnemyKilledCount();
    }
}
