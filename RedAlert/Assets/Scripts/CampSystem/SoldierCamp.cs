using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierCamp : ICamp
{
    const int MAX_LV = 4;
    private int mLv = 1;
    private WeaponType mWeaponType = WeaponType.Gun;

    public SoldierCamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 position, float trainTime, WeaponType weaponType = WeaponType.Gun, int lv = 1)
        :base(gameObject, name, icon, soldierType, position, trainTime)
    {
        mWeaponType = weaponType;
        mLv = lv;
        mEnergyCostStrategy = new SoldierEnergyCostStrategy();
        UpdateEnergyCost();
    }

    public int level { get { return mLv; } }

    public override int lv { get { return mLv; } }
    public override WeaponType weaponType { get { return mWeaponType; } }

    public override int energyCountCampUpgrade
    {
        get
        {
            if (mLv == MAX_LV)
                return -1;
            else
                return mEnergyCostCampUpgrade;
        }
    }

    public override int energyCountWeaponUpgrade
    {
        get
        {
            if (mWeaponType == WeaponType.MAX)
                return -1;
            else
                return mEnergyCostWeaponUpgrade;
        }
    }

    public override int energyCostTrain
    {
        get { return mEnergyCostTrain; }
    }

    public override void Train()
    {
        //添加训练命令
        TrainSoldierCommand cmd = new TrainSoldierCommand(mSoldierType, mWeaponType, mPosition, mLv);
        mCommands.Add(cmd);
    }

    public override void UpdateWeapon()
    {
        mWeaponType = mWeaponType + 1;
        UpdateEnergyCost();
    }

    public override void UpgradeCamp()
    {
        mLv++;
        UpdateEnergyCost();

    }

    protected override void UpdateEnergyCost()
    {
        mEnergyCostCampUpgrade = mEnergyCostStrategy.GetCampUpgradeCount(mSoldierType, mLv);
        mEnergyCostWeaponUpgrade = mEnergyCostStrategy.GetWeaponUpgradeCost(mWeaponType);
        mEnergyCostTrain = mEnergyCostStrategy.GetSoldierTrainCost(mSoldierType, mLv);
    }
}
