using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EnemyAttr : ICharacterAttr
{
    public EnemyAttr(IAttrStrategy strategy, string name, int maxHP, float moveSpeed, string iconSprite, string prefabName)
        : base(strategy, name, maxHP, moveSpeed, iconSprite, prefabName)
    {

    }
}
