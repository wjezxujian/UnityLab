using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponGun : IWeapon
{
    //public override void Fire(Vector3 targetPosition)
    //{
    //    Debug.Log("显示特效 Gun");
    //    Debug.Log("播放声音 Gun");

    //    //显示枪口特效
    //    mParticle.Stop();
    //    mParticle.Play();
    //    mLight.enabled = true;

    //    //显示子弹轨迹特效
    //    mLine.enabled = true;
    //    mLine.startWidth = 0.05f;
    //    mLine.endWidth = 0.05f;
    //    mLine.SetPosition(0, mGameObject.transform.position);
    //    mLine.SetPosition(1, targetPosition);

    //    //播放声音
    //    string clipName = "GunShot";
    //    AudioClip clip = null; //TODO
    //    mAudio.clip = clip;
    //    mAudio.Play();

    //}

    public WeaponGun(int atk, float atkRange, GameObject gameObject) : base(atk, atkRange, gameObject)
    {

    }

    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.2f;
    }

    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.05f, targetPosition);
    }

    protected override void PlaySound()
    {
        DoPlaySound("GunShot");
    }

}