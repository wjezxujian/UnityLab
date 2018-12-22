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
    }

    public int level { get { return mLv; } }

    public override int lv { get { return mLv; } }
    public override WeaponType weaponType { get { return mWeaponType; } }

    public override void Train()
    {
        //添加训练命令
        TrainSoldierCommand cmd = new TrainSoldierCommand(mSoldierType, mWeaponType, mPosition, mLv);
        mCommands.Add(cmd);
    }
}
