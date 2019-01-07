using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CaptiveCamp : ICamp
{
    private WeaponType mWeaponType = WeaponType.Gun;
    private EnemyType mEnemyType;

    public CaptiveCamp(GameObject gameObject, string name, string icon, EnemyType enemyType, Vector3 position, float trainTime)
        : base(gameObject, name, icon, SoldierType.Captive, position, trainTime)
    {
        mEnemyType = enemyType;
        mEnergyCostStrategy = new SoldierEnergyCostStrategy();
        UpdateEnergyCost();
    }

    public override int lv
    {
        get
        {
            return 1;
        }
    }

    public override WeaponType weaponType
    {
        get
        {
            return mWeaponType;
        }
    }

    public override int energyCountCampUpgrade
    {
        get
        {
            return 0;
        }
    }

    public override int energyCountWeaponUpgrade
    {
        get
        {
            return 0;
        }
    }

    public override int energyCostTrain
    {
        get
        {
            return mEnergyCostTrain;
        }
    }

    public override void Train()
    {
        //添加训练命令
        TrianCaptiveCommand cmd = new TrianCaptiveCommand(mEnemyType, mWeaponType, mPosition);
        mCommands.Add(cmd);
    }

    public override void UpdateWeapon()
    {
        return;
    }

    public override void UpgradeCamp()
    {
        return;
    }

    protected override void UpdateEnergyCost()
    {
        mEnergyCostTrain = mEnergyCostStrategy.GetSoldierTrainCost(mSoldierType, 1);
    }

}
