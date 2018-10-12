using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class WeaponRifle : IWeapon
{
    //public override void Fire(Vector3 targetPosition)
    //{
    //    Debug.Log("显示特效 Rilfe");
    //    Debug.Log("播放声音 Rilfe");
    //}

    protected override void SetEffectDisplayTime()
    {
        mEffectDisplayTime = 0.3f;
    }

    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffect(0.1f, targetPosition);
    }

    protected override void PlaySound()
    {
        DoPlaySound("RifleShot");
    }
}
