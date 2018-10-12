using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class WeaponRocket : IWeapon
{
    //public override void Fire(Vector3 targetPosition)
    //{
    //    Debug.Log("显示特效 Rocket");
    //    Debug.Log("播放声音 Rocket");
    //}

    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.4f;
    }

    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.3f, targetPosition);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RocketShot");
    }
}
