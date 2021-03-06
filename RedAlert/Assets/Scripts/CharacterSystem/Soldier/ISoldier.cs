﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum SoldierType
{
    Rookie,
    Sergeant,
    Captian,
    Captive
}

public abstract class ISoldier : ICharacter
{
    protected SoldierFsmSystem mFsmSystem;

    public ISoldier() : base()
    {
        MakeFSM();
    }

    public override void UpdateFSMAI(List<ICharacter> targets)
    {
        if (mIsKilled)
        {
            return;
        }

        mFsmSystem.CurrentState.Reason(targets);
        mFsmSystem.CurrentState.Act(targets);
    }

    public override void UnderAttack(int damage)
    {
        if (mIsKilled) return;

        base.UnderAttack(damage);
        
        if (mAttr.currentHP <= 0)
        {
            PlaySound();
            PlayEffect();
            Killed();
        }
    }

    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.NotifySubject(GameEventType.SoldierKilled);
    }

    protected abstract void PlaySound();
    protected abstract void PlayEffect();
    

    private void MakeFSM()
    {
        mFsmSystem = new SoldierFsmSystem();

        SoldierIdleState idleState = new SoldierIdleState(mFsmSystem, this);
        idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChaseState chaseState = new SoldierChaseState(mFsmSystem, this);
        chaseState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        SoldierAttackState attackState = new SoldierAttackState(mFsmSystem, this);
        attackState.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        mFsmSystem.AddState(idleState, chaseState, attackState);
    }

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.VisitSoldier(this);
    }

}
