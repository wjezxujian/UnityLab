using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SoldierAttr : ICharacterAttr
{
    public SoldierAttr(IAttrStrategy strategy, string name, int maxHP, float moveSpeed, string iconSprite, string prefabName) 
        : base(strategy, name, maxHP, moveSpeed, iconSprite, prefabName)
    {

    }
}
