using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class EnemyOgre : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("OgreHitEffect");
    }
}