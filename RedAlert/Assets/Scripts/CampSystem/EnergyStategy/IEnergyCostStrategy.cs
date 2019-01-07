using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IEnergyCostStrategy
{
    public abstract int GetCampUpgradeCount(SoldierType st, int lv);

    public abstract int GetWeaponUpgradeCost(WeaponType wt);

    public abstract int GetSoldierTrainCost(SoldierType st,int lv);

}
