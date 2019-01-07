using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StageSystem : IGameSystem
{
    int mLv = 1;
    List<Vector3> mPosList;
    IStageHandler mRootHandler;
    Vector3 mTargetPos;

    int mCountOfEnemyKielled = 0;

    public override void Init()
    {
        base.Init();

        InitPosition();
        InitStageChain();

        mFacade.RegisterObserver(GameEventType.EmemyKilled, new EnemyKilledObserverStageSystem(this));
    }

    public override void Release()
    {
        //throw new NotImplementedException();
    }

    public override void Update()
    {
        base.Update();
        mRootHandler.Handler(mLv);
    }

    public int GetCountOfEnemyKilled()
    {
        return mCountOfEnemyKielled;
    }

    public int countOfEnemeyKilled
    {
        set
        {
            mCountOfEnemyKielled = value;
        }

        get
        {
            return mCountOfEnemyKielled;
        }
    }

    public void EneterNextStage()
    {
        mLv++;
        //必须放到mLv自增下面
        mFacade.NotifySubject(GameEventType.NewStage);
    }

    public Vector3 targetPosition
    {
        get { return mTargetPos; }
    }

    private void InitStageChain()
    {
        int lv = 1;
        NormalStageHandler handler1 = new NormalStageHandler(this, lv++,EnemyType.Elf, WeaponType.Gun, 3, GetRandomPos(), 3 );
        NormalStageHandler handler2 = new NormalStageHandler(this, lv++, EnemyType.Elf, WeaponType.Rifle, 3, GetRandomPos(), 6);
        NormalStageHandler handler3 = new NormalStageHandler(this, lv++, EnemyType.Elf, WeaponType.Rocket, 3, GetRandomPos(), 9);
        NormalStageHandler handler4 = new NormalStageHandler(this, lv++, EnemyType.Ogre, WeaponType.Gun, 4, GetRandomPos(), 13);
        NormalStageHandler handler5 = new NormalStageHandler(this, lv++, EnemyType.Ogre, WeaponType.Rifle, 4, GetRandomPos(), 17);
        NormalStageHandler handler6 = new NormalStageHandler(this, lv++, EnemyType.Ogre, WeaponType.Rocket, 4, GetRandomPos(), 21);
        NormalStageHandler handler7 = new NormalStageHandler(this, lv++, EnemyType.Troll, WeaponType.Gun, 5, GetRandomPos(), 26);
        NormalStageHandler handler8 = new NormalStageHandler(this, lv++, EnemyType.Troll, WeaponType.Rifle, 5, GetRandomPos(), 31);
        NormalStageHandler handler9 = new NormalStageHandler(this, lv++, EnemyType.Troll, WeaponType.Rocket, 5, GetRandomPos(), 36);

        handler1.SetNextHandler(handler2).SetNextHandler(handler3).
            SetNextHandler(handler4).SetNextHandler(handler5).
            SetNextHandler(handler6).SetNextHandler(handler7).
            SetNextHandler(handler8).SetNextHandler(handler9);

        mRootHandler = handler1;
    }

    private Vector3 GetRandomPos()
    {
        return mPosList[UnityEngine.Random.Range(0, mPosList.Count)];
    }

    private void InitPosition()
    {
        mPosList = new List<Vector3>();

        int i = 1;
        while (true)
        {
            GameObject go = GameObject.Find("Position" + i);
            if(go != null)
            {
                i++;
                mPosList.Add(go.transform.position);
                go.SetActive(false);
            }
            else
            {
                break;
            }
        }

        GameObject targetPos = GameObject.Find("TargetPosition");
        //targetPos.SetActive(false);
        if(targetPos != null)
        {
            mTargetPos = targetPos.transform.position;
        }
    }

}
