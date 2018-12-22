using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class SoldierInfoUI : IBaseUI
{
    private Image mSoldierIcon;
    private Text mSoldierName;
    private Text mHPText;
    private Slider mHPSlider;
    private Text mLv;
    private Text mAtk;
    private Text mAtkRange;
    private Text mMoveSpeed;

    public override void Init()
    {
        base.Init();

        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTools.FindChild(canvas, "SoldierInfoUI");

        mSoldierIcon = UITools.FindChild<Image>(mRootUI, "SoldierIcon");
        mSoldierName = UITools.FindChild<Text>(mRootUI, "SoldierName");
        mHPText = UITools.FindChild<Text>(mRootUI, "HPNumber");
        mHPSlider = UITools.FindChild<Slider>(mRootUI, "HPSlider");
        mLv = UITools.FindChild<Text>(mRootUI, "Level");
        mAtk = UITools.FindChild<Text>(mRootUI, "Atk");
        mAtkRange = UITools.FindChild<Text>(mRootUI, "AtkRange");
        mMoveSpeed = UITools.FindChild<Text>(mRootUI, "MoveSpeed");

        Hide();
    }
}
