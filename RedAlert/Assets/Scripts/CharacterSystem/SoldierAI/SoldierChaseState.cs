using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class SoldierChaseState : ISoldierState
{
    public SoldierChaseState(SoldierFsmSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateID = SoldierStateID.Chase;
    }

    public override void Act(List<ICharacter> targets)
    {
        if(targets != null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].position);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if(targets == null && targets.Count == 0)
        {
            mFSM.PerformTransition(SoldierTransition.NoEnemy);
            return;
        }
        float distance = Vector3.Distance(targets[0].position, mCharacter.position);

        if(distance < mCharacter.atkRange)
        {
            mFSM.PerformTransition(SoldierTransition.CanAttack);
            return;
        }
    }
}
