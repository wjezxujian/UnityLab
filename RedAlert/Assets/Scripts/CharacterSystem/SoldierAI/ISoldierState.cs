using System;
using System.Collections.Generic;
using System.Text;

public enum SoldierTransition
{
    NullTransitionID = 0,
    SeeEnemy,
    NoEnemy,
    CanAttack
}

public enum SoldierStateID
{
    Idle,
    Chase,
    Attack
}

public abstract class ISoldierState
{

}
