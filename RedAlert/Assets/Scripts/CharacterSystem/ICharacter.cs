﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter
{
    protected ICharacterAttr mAttr;

    protected GameObject mGameObject;
    protected NavMeshAgent mNavAgent;
    protected AudioSource mAudio;
    protected IWeapon mWapon;
    protected Animation mAnin;

    public virtual void UpdateFSMAI(List<ICharacter> targets)
    {

    }

    public Vector3 position
    {
        get
        {
            if (mGameObject == null)
            {
                Debug.LogError("mGameObject为空");
                return Vector3.zero;
            }
            return mGameObject.transform.position;
        }
    }

    public float atkRange
    {
        get
        {
            return mWapon.atkRange;
        }
    }

    public ICharacterAttr attr { set { mAttr = value; } }

    public GameObject gameObject
    {
        set
        {
            mGameObject = value;
            mNavAgent = mGameObject.GetComponent<NavMeshAgent>();
            mAudio = mGameObject.GetComponent<AudioSource>();
            mAnin = mGameObject.GetComponentInChildren<Animation>();
        }
    }

    public IWeapon weapon
    {
        set
        {
            mWapon = value;
            mWapon.owner = this;
            GameObject child = UnityTools.FindChild(mGameObject, "weapon-point");
            UnityTools.Attach(child, mWapon.gameObject);
        }
    }

    public void Attack(ICharacter target)
    {
        if(mWapon != null)
        {
            mWapon.Fire(target.position);

            //调整朝向
            mGameObject.transform.LookAt(target.position);
            PlayAnimation("attack");
            target.UnderAttack(mWapon.atk + mAttr.critValue);
        }
        
    }

    public virtual void UnderAttack(int damage)
    {
        mAttr.TakeDamage(damage);

        //攻击的效果 音效 视效 只有敌人有


        //死亡效果 音效 视频效果


    }

    public void Killed()
    {
        //TODO
    }

    public void PlayAnimation(string animName)
    {
        mAnin.CrossFade(animName);
    }

    protected void DoPlayEffect(string effectName)
    {
        //加载特效
        GameObject effectGO = FactoryManager.assetFactory.LoadEffect(effectName);
        effectGO.transform.position = position;

        //控制销毁
        effectGO.AddComponent<DestoryForTime>();
        DestoryForTime comp = effectGO.GetComponent<DestoryForTime>() as DestoryForTime;
        comp.time = 1f;
    }

    protected void DoPlaySound(string soundName)
    {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(soundName);
        mAudio.clip = clip;
        mAudio.Play();
    }

    public void MoveTo(Vector3 targetPosition)
    {
        mNavAgent.SetDestination(targetPosition);
        PlayAnimation("move");
    }

    public virtual void Update()
    {

    }

}