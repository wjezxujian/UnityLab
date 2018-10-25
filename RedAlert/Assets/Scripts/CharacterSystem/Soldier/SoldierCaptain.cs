using System;
using System.Collections.Generic;
using System.Text;

class SoldierCaptain : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffect("CaptainDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySound("CaptainDeath");
    }
}
