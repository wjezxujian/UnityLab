using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ICharacterAttr
{
    protected string mName;
    protected int mMaxHP;
    protected float mMoveSpeed;
    protected int mCurrentHP;
    protected string mIconSprite;
    protected int mLv;
    protected float mCritRate; //0-1暴击率

    //增加的最大血量，抵御的伤害值，暴击增加的伤害
    protected IAttrStrategy mStrategy;
}
