using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierCaptive : ISoldier
{
    private IEnemy mEnemy;

    public SoldierCaptive(IEnemy enemy)
    {
        mEnemy = enemy;

        //添加属性
        ICharacterAttr attr = new SoldierAttr(enemy.attr.strategy, 1, enemy.attr.baseAttr);
        this.attr = attr;

        //游戏物体
        this.gameObject = mEnemy.gameObject;

        //添加武器
        this.weapon = mEnemy.weapon;
    }

    protected override void PlayEffect()
    {
        //Do Nothing
    }

    protected override void PlaySound()
    {
        mEnemy.PlayEffect();
    }
}
