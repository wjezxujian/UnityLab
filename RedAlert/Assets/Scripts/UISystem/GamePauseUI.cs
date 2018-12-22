using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class GamePauseUI : IBaseUI
{
    private Text mCurrentStageLv;
    private Button mContinueBtn;
    private Button mBackMenuBtn;


    public override void Init()
    {
        base.Init();

        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTools.FindChild(canvas, "GamePauseUI");

        mCurrentStageLv = UITools.FindChild<Text>(mRootUI, "CurrentStageLv");
        mContinueBtn = UITools.FindChild<Button>(mRootUI, "ContinueBtn");
        mBackMenuBtn = UITools.FindChild<Button>(mRootUI, "BackMenuBtn");

        Hide();
    }
}
