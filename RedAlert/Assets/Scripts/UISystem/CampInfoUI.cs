using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class CampInfoUI : IBaseUI
{
    private Image mCampIcon;
    private Text mCampName;
    private Text mCampLevel;
    private Text mWeaponLevel;
    private Button mUpgradeCampBtn;
    private Button mUpgradeWeaponBtn;
    private Button mTrainBtn;
    private Button mCancelTrainBtn;
    private Text mAliveCount;
    private Text mTrainningCount;
    private Text mTrainTime;

    private ICamp mCamp;

    public override void Init()
    {
        base.Init();

        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTools.FindChild(canvas, "CampInfoUI");

        mCampIcon = UITools.FindChild<Image>(mRootUI, "CampIcon");
        mCampName = UITools.FindChild<Text>(mRootUI, "CampName");
        mCampLevel = UITools.FindChild<Text>(mRootUI, "CampLv");
        mWeaponLevel = UITools.FindChild<Text>(mRootUI, "WeaponLv");
        mUpgradeCampBtn = UITools.FindChild<Button>(mRootUI, "CampUpgradeBtn");
        mUpgradeWeaponBtn = UITools.FindChild<Button>(mRootUI, "WeaponUpgradeBtn");
        mTrainBtn = UITools.FindChild<Button>(mRootUI, "TrainBtn");
        mCancelTrainBtn = UITools.FindChild<Button>(mRootUI, "CancelTrainBtn");
        mAliveCount = UITools.FindChild<Text>(mRootUI, "AliveCount");
        mTrainningCount = UITools.FindChild<Text>(mRootUI, "TrainningCount");
        mTrainTime = UITools.FindChild<Text>(mRootUI, "TrainTime");

        mTrainBtn.onClick.AddListener(OnTrainClick);
        mCancelTrainBtn.onClick.AddListener(OnCancelTrainClick);

        Hide();
    }

    public override void Update()
    {
        base.Update();

        ShowTrainInfo();

    }

    public void ShowCampInfo(ICamp camp)
    {
        Show();

        mCamp = camp;
        mCampIcon.sprite = FactoryManager.assetFactory.LoadSprite(camp.iconSprite);
        mCampName.text = camp.name;
        mCampLevel.text = camp.lv.ToString();
        ShowWeaponLevel(camp.weaponType);

        ShowTrainInfo();
    }

    private void ShowTrainInfo()
    {
        if (mCamp == null)
            return;

        mTrainTime.text = mCamp.trainRemainingTime.ToString();
        mTrainningCount.text = mCamp.trainCount.ToString("0.00");
        mCancelTrainBtn.interactable = mCamp.trainCount != 0;
    }

    void ShowWeaponLevel(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Gun:
                mWeaponLevel.text = "短枪";
                break;
            case WeaponType.Rifle:
                mWeaponLevel.text = "长枪";
                break;
            case WeaponType.Rocket:
                mWeaponLevel.text = "火箭";
                break;
            case WeaponType.MAX:
                break;
            default:
                break;
        }
    }

    public void OnTrainClick()
    {
        //能量是否足够 TODO
        mCamp.Train();
    }

    public void OnCancelTrainClick()
    {
        //回收能量 TODO
        mCamp.CancelTrainCommand();
    }
}