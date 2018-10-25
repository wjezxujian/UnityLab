using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class FactoryManager
{
    private static IAssetFactory mAssetFactory = null;
    private static ICharacterFactory mSoldierFactory = null;
    private static ICharacterFactory mEnemyFactory = null;
    private static IWeaponFactory mWeaponFactory = null;

    public static IAssetFactory assetFactory
    {
        get
        {
            if (mAssetFactory == null)
            {
                mAssetFactory = new ResourcesAssetFactory();
            }
            return mAssetFactory;
        }
    }

    public static ICharacterFactory soldierFactory
    {
        get
        {
            if(mSoldierFactory == null)
            {
                mSoldierFactory = new SoldierFactory();
            }
            return mSoldierFactory;
        }
    }

    public static ICharacterFactory enemyFactory
    {
        get
        {
            if (mEnemyFactory == null)
            {
                mEnemyFactory = new EnemyFactory();
            }
            return mEnemyFactory;
        }
    }

    public static IWeaponFactory weaponFactory
    {
        get
        {
            if (mWeaponFactory == null)
            {
                mWeaponFactory = new WeaponFactory();
            }
            return mWeaponFactory;
        }
    }
}
