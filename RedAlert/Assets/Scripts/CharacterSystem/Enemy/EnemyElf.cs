﻿using System;
using System.Collections.Generic;
using System.Text;

class EnemyElf : IEnemy
{
    protected override void PlayEffect()
    {
        DoPlayEffect("ElfHitEffect");
    }
}
