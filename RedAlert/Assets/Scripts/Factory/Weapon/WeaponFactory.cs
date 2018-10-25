using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(WeaponType weaponType)
    {
        IWeapon weapon = null;
        string assetName = "";

        switch (weaponType)
        {
            case WeaponType.Gun:
                assetName = "WeaponGun";
                break;
            case WeaponType.Rifle:
                assetName = "WeaponRifle";
                break;
            case WeaponType.Rocket:
                assetName = "WeaponRocket";
                break;
            default:
                break;
        }

        GameObject weaponGO = FactoryManager.assetFactory.LoadWeapon(assetName);

        switch (weaponType)
        {
            case WeaponType.Gun:
                weapon = new WeaponGun(20, 5, weaponGO);
                break;
            case WeaponType.Rifle:
                weapon = new WeaponRifle(30, 7, weaponGO);
                break;
            case WeaponType.Rocket:
                weapon = new WeaponRocket(40, 8, weaponGO);
                break;
            default:
                break;
        }

        return weapon;
    }
}
