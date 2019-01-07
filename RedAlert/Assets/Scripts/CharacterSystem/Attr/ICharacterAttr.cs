using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ICharacterAttr
{
    protected CharacterBaseAttr mBaseAttr;  
    protected int mCurrentHP;
    protected int mLv;
    protected int mDmgDescValue;

    //增加的最大血量，抵御的伤害值，暴击增加的伤害
    protected IAttrStrategy mStrategy;

    public int critValue { get { return mStrategy.GetCritDmgValue(mBaseAttr.critRate); } }
    public int dmgDescValue { get { return mDmgDescValue; } }
    public int currentHP { get { return mCurrentHP; } }
    public IAttrStrategy strategy { get { return mStrategy; } }
    public CharacterBaseAttr baseAttr { get { return mBaseAttr; } }

    public ICharacterAttr(IAttrStrategy strategy, int lv, CharacterBaseAttr baseAttr)
    {
        mLv = lv;
        mBaseAttr = baseAttr;

        mStrategy = strategy;
        mDmgDescValue = mStrategy.GetDmgDescValue(mLv);
        mCurrentHP = mBaseAttr.maxHp + mStrategy.GetExtraHPValue(mLv);
    }

    public void TakeDamage(int damage)
    {
        damage -= mDmgDescValue;
        if (damage < 5)
            damage = 5;
        mCurrentHP -= damage;
    }
}
