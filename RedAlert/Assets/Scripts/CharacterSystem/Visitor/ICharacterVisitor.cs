using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class ICharacterVisitor
{
    public abstract void VisitorEnemy(IEnemy enemy);

    public abstract void VisitSoldier(ISoldier soldier);
        
}