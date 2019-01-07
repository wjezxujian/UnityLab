using System;
using System.Collections.Generic;
using System.Text;

class EnemyElf : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffect("ElfHitEffect");
    }
}
