using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class IWeapon
{
    protected int mAtk;
    protected float mAtkRange;
    protected int mAtkPlusValue;

    protected GameObject mGameObject;
    protected ICharacter mOwner;

    protected ParticleSystem mParticle;
    protected LineRenderer mLine;
    protected Light mLight;
    protected AudioSource mAudio;

    protected float mEffectDisplayTime;

    public void Update()
    {
        if(mEffectDisplayTime > 0)
        {
            mEffectDisplayTime -= Time.deltaTime;
            if(mEffectDisplayTime <= 0)
            {
                DisableEffect();
            }
        }
    }

    public virtual void Fire(Vector3 targetPosition)
    {
        //显示枪口特效
        PlayMuzzleEffect();

        //显示子弹轨迹特效
        PlayBulletEffect(targetPosition);

        //特效时间
        SetEffectDisplayTime();

        //播放声音
        PlaySound();

    }

    protected abstract void SetEffectDisplayTime();

    protected virtual void PlayMuzzleEffect()
    {
        //显示枪口特效
        mParticle.Stop();
        mParticle.Play();
        mLight.enabled = true;
    }

    protected virtual void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.05f, targetPosition);
    }

    protected void DoPlayBulletEffect(float width, Vector3 targetPosition)
    {
        mLine.enabled = true;
        mLine.startWidth = width;
        mLine.endWidth = width;
        mLine.SetPosition(0, mGameObject.transform.position);
        mLine.SetPosition(1, targetPosition);
    }

    protected abstract void PlaySound();

    protected void DoPlaySound(string name)
    {
        string clipName = name;

        //TODO
        AudioClip clip = null; 
        mAudio.clip = clip;
        mAudio.Play();
    }

    private void DisableEffect()
    {
        mLine.enabled = false;
        mLight.enabled = false;
    }


}
