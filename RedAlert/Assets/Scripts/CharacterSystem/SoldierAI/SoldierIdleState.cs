using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class SoldierIdleState : ISoldierState
{
    public SoldierIdleState(SoldierFsmSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = SoldierStateID.Idle;
    }

    public override void Act(List<ICharacter> targets)
    {
        
    }

    public override void Reason(List<ICharacter> targets)
    {
        if(targets != null && targets.Count > 0)
        {
            mFSM.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
}