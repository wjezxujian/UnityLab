using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnergySystem : IGameSystem
{
    private const float MAX_ENERGY = 100;
    private float mNowEnergy = MAX_ENERGY;
    private float mRecoverSpeed = 3;

    public void Init()
    {
        base.Init();
    }

    public void Release()
    {
        base.Release();
    }

    public void Update()
    {
        base.Update();

        mFacade.UpdateEnergySlider((int)mNowEnergy, (int)MAX_ENERGY);
        if (mNowEnergy >= MAX_ENERGY)
        {
            return;
        }

        mNowEnergy += mRecoverSpeed * Time.deltaTime;
        mNowEnergy = Mathf.Min(mNowEnergy, MAX_ENERGY);
    }

    public bool TakeEnergy(int value)
    {
        if(mNowEnergy >= value)
        {
            mNowEnergy -= value;
            return true;
        }

        return false;
    }

    public void Recycle(int value)
    {
        mNowEnergy += value;
        mNowEnergy = Mathf.Min(mNowEnergy, MAX_ENERGY);
    }
}
