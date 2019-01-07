using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class SoldierEnergyCostStrategy : IEnergyCostStrategy
{
    public override int GetCampUpgradeCount(SoldierType st, int lv)
    {
        int energy = 0;
        switch (st)
        {
            case SoldierType.Rookie:
                energy = 60;
                break;
            case SoldierType.Sergeant:
                energy = 65;
                break;
            case SoldierType.Captian:
                energy = 70;
                break;
            default:
                Debug.LogError("无法获取" + st + "类型兵营升级所消耗的能量值");
                break;
        }

        energy += (lv - 1) * 2;
        energy = Mathf.Min(energy, 100);
        return energy;
    }

    public override int GetSoldierTrainCost(SoldierType st, int lv)
    {
        int energy = 0;
    
        switch (st)
        {
            case SoldierType.Rookie:
                energy = 10;
                break;
            case SoldierType.Sergeant:
                energy = 15;
                break;
            case SoldierType.Captian:
                energy = 20;
                break;
            case SoldierType.Captive:
                return 10;
            default:
                Debug.Log("无法获取士兵类型为：" + st + " 训练所消耗的能量值");
                break;
        }

        energy += (lv - 1) * 2;
        energy = Mathf.Min(energy, 100);
        return energy;
    }

    public override int GetWeaponUpgradeCost(WeaponType wt)
    {
        int energy = 0;
        switch (wt)
        {
            case WeaponType.Gun:
                energy = 30;
                break;
            case WeaponType.Rifle:
                energy = 40;
                break;
        }

        return energy;
    }
}