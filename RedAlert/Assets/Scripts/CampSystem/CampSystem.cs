using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CampSystem : IGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> mSoliderCamps = new Dictionary<SoldierType, SoldierCamp>();
    private Dictionary<EnemyType, CaptiveCamp> mCaptiveCamps = new Dictionary<EnemyType, CaptiveCamp>();

    public override void Init()
    {
        base.Init();

        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captian);

        InitCamp(EnemyType.Elf);

    }

    public override void Release()
    {
        throw new NotImplementedException();
    }

    public override void Update()
    {
        base.Update();

        foreach (SoldierCamp camp in mSoliderCamps.Values)
        {
            camp.Update();
        }

        foreach (CaptiveCamp camp in mCaptiveCamps.Values)
        {
            camp.Update();
        }
    }

    public void InitCamp(SoldierType soldierType)
    {
        GameObject gameObject = null;
        string gameObjectName = null;
        string name = null;
        string icon = null;
        Vector3 position = Vector3.zero;
        float trainTime = 0;

        switch (soldierType)
        {
            case SoldierType.Rookie:
                gameObjectName = "SoldierCamp_Rookie";
                name = "新手兵营";
                icon = "RookieCamp";
                trainTime = 3;
                break;
            case SoldierType.Sergeant:
                gameObjectName = "SoldierCamp_Sergeant";
                name = "中士兵营";
                icon = "SergeantCamp";
                trainTime = 4;
                break;
            case SoldierType.Captian:
                gameObjectName = "SoldierCamp_Captain";
                name = "上尉兵营";
                icon = "CaptainCamp";
                trainTime = 5;
                break;
            default:
                Debug.LogError("无法根据战士类型" + soldierType + "初始化兵营");
                break;
        }

        gameObject = GameObject.Find(gameObjectName);
        position = UnityTools.FindChild(gameObject, "TrainPoint").transform.position;
        SoldierCamp camp = new SoldierCamp(gameObject, name, icon, soldierType, position, trainTime);

        gameObject.AddComponent<CampOnClick>().camp = camp;

        mSoliderCamps.Add(soldierType, camp);
    }

    public void InitCamp(EnemyType enemyType)
    {
        GameObject gameObject = null;
        string gameObjectName = null;
        string name = null;
        string icon = null;
        Vector3 position = Vector3.zero;
        float trainTime = 0;

        switch (enemyType)
        {
            case EnemyType.Elf:
                gameObjectName = "CaptiveCamp_Elf";
                name = "俘兵营";
                icon = "CaptiveCamp";
                trainTime = 3;
                break;
            default:
                Debug.LogError("无法根据敌人类型" + enemyType + "初始化俘兵营");
                break;
        }

        gameObject = GameObject.Find(gameObjectName);
        position = UnityTools.FindChild(gameObject, "TrainPoint").transform.position;
        CaptiveCamp camp = new CaptiveCamp(gameObject, name, icon, enemyType, position, trainTime);
        gameObject.AddComponent<CampOnClick>().camp = camp;
        mCaptiveCamps.Add(enemyType, camp);
    }
}
