using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum WeaponType
{
    Gun,
    Rifle,
    Rocket,
    MAX
}

public abstract class IWeapon
{
    protected WeaponBaseAttr mBaseAttr;
    //protected int mAtkPlusValue;

    protected GameObject mGameObject;
    protected ICharacter mOwner;

    protected ParticleSystem mParticle;
    protected LineRenderer mLine;
    protected Light mLight;
    protected AudioSource mAudio;

    protected float mEffectDisplayTime;

    public float atkRange { get { return mBaseAttr.atkRange; } }

    public int atk { get { return mBaseAttr.atk; } }

    public ICharacter owner { set { mOwner = value; } }

    public GameObject gameObject { get { return mGameObject; } }

    public IWeapon(WeaponBaseAttr baseAttr, GameObject gameObject)
    {
        mBaseAttr = baseAttr;
        mGameObject = gameObject;

        Transform effect = mGameObject.transform.Find("Effect");
        mParticle = effect.GetComponent<ParticleSystem>();
        mLine = effect.GetComponent<LineRenderer>();
        mLight = effect.GetComponent<Light>();
        mAudio = effect.GetComponent<AudioSource>();
    }

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

        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(clipName); 
        mAudio.clip = clip;
        mAudio.Play();
    }

    private void DisableEffect()
    {
        mLine.enabled = false;
        mLight.enabled = false;
    }


}
