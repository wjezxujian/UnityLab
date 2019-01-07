using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class TrainSoldierCommand : ITrainCommand
{
    SoldierType mSoldierType;
    WeaponType mWeaponType;
    Vector3 mPosition;
    int mLevel;

    public TrainSoldierCommand(SoldierType st, WeaponType wt, Vector3 pos, int lv)
    {
        mSoldierType = st;
        mWeaponType = wt;
        mPosition = pos;
        mLevel = lv;
    }

    public override void Execute()
    {
        switch (mSoldierType)
        {
            case SoldierType.Rookie:
                FactoryManager.soldierFactory.CreateCharacter<SoldierRookie>(mWeaponType, mPosition, mLevel);
                break;
            case SoldierType.Sergeant:
                FactoryManager.soldierFactory.CreateCharacter<SoldierSergeant>(mWeaponType, mPosition, mLevel);
                break;
            case SoldierType.Captian:
                FactoryManager.soldierFactory.CreateCharacter<SoldierCaptain>(mWeaponType, mPosition, mLevel);
                break;
            default:
                Debug.LogError("无法执行命令，无法更具SoldierType:" + mSoldierType + "创建角色");
                break;
        }
    }
}
