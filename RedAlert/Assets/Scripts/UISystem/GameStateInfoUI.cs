using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class GameStateInfoUI : IBaseUI
{
    private List<GameObject> mHearts;
    private Text mSoliderCount;
    private Text mEnemyCount;
    private Text mCurrentStage;
    private Button mPauseBtn;
    private GameObject mGameOverUI;
    private Button mBackMenuBtn;
    private Text mMessage;
    private Slider mEnergySlider;

    public override void Init()
    {
        base.Init();

        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTools.FindChild(canvas, "GameStateUI");

        GameObject heart1 = UnityTools.FindChild(mRootUI, "Heart1");
        GameObject heart2 = UnityTools.FindChild(mRootUI, "Heart1");
        GameObject heart3 = UnityTools.FindChild(mRootUI, "Heart2");
        mHearts = new List<GameObject>();
        mHearts.Add(heart1);
        mHearts.Add(heart2);
        mHearts.Add(heart3);
        mSoliderCount = UITools.FindChild<Text>(mRootUI, "SoldierCount");

        mEnemyCount = UITools.FindChild<Text>(mRootUI, "EnemyCount");
        mCurrentStage = UITools.FindChild<Text>(mRootUI, "StageCounter");
        mPauseBtn = UITools.FindChild<Button>(mRootUI, "PauseBtn");
        mGameOverUI = UnityTools.FindChild(mRootUI, "GameOver");
        mBackMenuBtn = UITools.FindChild<Button>(mRootUI, "BackMenuBtn");
        mMessage = UITools.FindChild<Text>(mRootUI, "Message");
        mEnergySlider = UITools.FindChild<Slider>(mRootUI, "EnergySlider");

        mGameOverUI.SetActive(false);
    }
}
