using System;
using System.Collections.Generic;
using System.Text;

class SoldierSergeant : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffect("SergeantDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("SergeantDeath");
    }
}