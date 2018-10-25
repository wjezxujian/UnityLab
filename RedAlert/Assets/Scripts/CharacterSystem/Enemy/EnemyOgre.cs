using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class EnemyOgre : IEnemy
{
    protected override void PlayEffect()
    {
        DoPlayEffect("OgreHitEffect");
    }
}