using System;
using System.Collections.Generic;
using System.Text;

public class EnemyTroll : IEnemy
{
    protected override void PlayEffect()
    {
        DoPlayEffect("TrollHitEffect");
    }
}