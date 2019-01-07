using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TrianCaptiveCommand : ITrainCommand
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private Vector3 mPosition;
    private int mLv;

    public TrianCaptiveCommand(EnemyType et, WeaponType wt, Vector3 pos, int lv = 1)
    {
        mEnemyType = et;
        mWeaponType = wt;
        mPosition = pos;
        mLv = lv;
    }

    public override void Execute()
    {
        IEnemy enemy = null;

        switch (mEnemyType)
        {
            case EnemyType.Elf:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyElf>(mWeaponType, mPosition) as IEnemy;
                break;
            case EnemyType.Ogre:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mPosition) as IEnemy;
                break;
            case EnemyType.Troll:
                enemy = FactoryManager.enemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mPosition) as IEnemy;
                break;
            default:
                Debug.LogError("无法创建俘兵:" + mEnemyType);
                return;
        }

        GameFacade.Instance.RemoveEnemy(enemy);
        SoldierCaptive captive = new SoldierCaptive(enemy);
        GameFacade.Instance.AddSoldier(captive);

    }
}