using System;
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

    public IWeapon weapon { set { mWapon = value; } }

    public void Attack(Vector3 targetPosition)
    {
        if(mWapon != null)
        {
            mWapon.Fire(targetPosition);
        }
        
    }

}