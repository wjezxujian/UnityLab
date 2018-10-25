using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class EnemyFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();

        string name = "";
        int maxHP = 0;
        float moveSpeed = 0;
        string iconSprite = "";
        string prefabName = "";

        System.Type t = character.GetType();
        if(t == typeof(EnemyElf))
        {
            name = "小精灵";
            maxHP = 100;
            moveSpeed = 3;
            iconSprite = "ElfIcon";
            prefabName = "Enemy1";
        }
        else if(t == typeof(EnemyOgre))
        {
            name = "怪物";
            maxHP = 120;
            moveSpeed = 4;
            iconSprite = "OgreIcon";
            prefabName = "Enemy2";
        }
        else if(t == typeof(EnemyTroll))
        {
            name = "巨魔";
            maxHP = 200;
            moveSpeed = 1;
            iconSprite = "TrollIcon";
            prefabName = "Enemy3";
        }
        else
        {
            Debug.LogError("类型" + t + "不属于IEnemy，无法创建敌人");
            return null;
        }

        ICharacterAttr attr = new EnemyAttr(new EnemyAttrStrategy(), lv, name, maxHP, moveSpeed, iconSprite, prefabName);
        character.attr = attr;

        GameObject characterGO = FactoryManager.assetFactory.LoadEnemy(prefabName);
        characterGO.transform.position = spawnPosition;
        character.gameObject = characterGO;

        IWeapon weapon = FactoryManager.weaponFactory.CreateWeapon(weaponType);
        character.weapon = weapon;

        return character;
    }
}
