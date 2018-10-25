using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ICharacterAttr
{
    protected string mName;
    protected int mMaxHP;
    protected float mMoveSpeed;
    protected string mIconSprite;
    protected string mPrefabName;

    protected int mCurrentHP;
    protected int mLv;
    protected float mCritRate; //0-1暴击率
    protected int mDmgDescValue;

    //增加的最大血量，抵御的伤害值，暴击增加的伤害
    protected IAttrStrategy mStrategy;

    public int critValue { get { return mStrategy.GetCritDmgValue(mCritRate); } }
    public int dmgDescValue { get { return mDmgDescValue; } }
    public int currentHP { get { return mCurrentHP; } }

    public ICharacterAttr(IAttrStrategy strategy, int lv, string name, int maxHP, float moveSpeed, string iconSprite, string prefabName)
    {
        mLv = lv;
        mName = name;
        mMaxHP = maxHP;
        mMoveSpeed = moveSpeed;
        mIconSprite = iconSprite;
        mPrefabName = prefabName;

        mStrategy = strategy;
        mDmgDescValue = mStrategy.GetDmgDescValue(mLv);
        mCurrentHP = mMaxHP + mStrategy.GetExtraHPValue(mLv);
    }

    public void TakeDamage(int damage)
    {
        damage -= mDmgDescValue;
        if (damage < 5)
            damage = 5;
        mCurrentHP -= damage;
    }
}
