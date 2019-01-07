using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class ResourcesAssetProxyFactory : IAssetFactory
{
    private ResourcesAssetFactory mAssetFactory = new ResourcesAssetFactory();
    private Dictionary<string, GameObject> mSoldiers = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEnemys = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mWeapons = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEfffects = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioClip> mAudioClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, Sprite> mSprites = new Dictionary<string, Sprite>();



    public AudioClip LoadAudioClip(string name)
    {
        if (mAudioClips.ContainsKey(name))
        {
            return mAudioClips[name];
        }
        else
        {
            AudioClip asset = mAssetFactory.LoadAudioClip(name);
            mAudioClips[name] = asset;
            return asset;
        }
    }

    public GameObject LoadEffect(string name)
    {
        if (mEfffects.ContainsKey(name))
        {
            return GameObject.Instantiate(mEfffects[name]);
        }
        else
        {
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.EffectPath + name) as GameObject;
            mEfffects[name] = asset;
            return GameObject.Instantiate(asset);
        }
    }

    public GameObject LoadEnemy(string name)
    {
        if (mEnemys.ContainsKey(name))
        {
            return GameObject.Instantiate(mEnemys[name]);
        }
        else
        {
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.EnemyPath + name) as GameObject;
            mEnemys[name] = asset;
            return GameObject.Instantiate(asset);
        }
    }

    public GameObject LoadSoldier(string name)
    {
        if (mSoldiers.ContainsKey(name))
        {
            return GameObject.Instantiate(mSoldiers[name]);
        }
        else
        {
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.SoldierPath + name) as GameObject;
            mSoldiers[name] = asset;
            return GameObject.Instantiate(asset);
        }
    }

    public Sprite LoadSprite(string name)
    {
        if (mSprites.ContainsKey(name))
        {
            return mSprites[name];
        }
        else
        {
            Sprite asset = mAssetFactory.LoadSprite(name);
            mSprites[name] = asset;
            return asset;
        }
    }

    public GameObject LoadWeapon(string name)
    {
        if (mWeapons.ContainsKey(name))
        {
            return GameObject.Instantiate(mWeapons[name]);
        }
        else
        {
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.WeaponPath + name) as GameObject;
            mWeapons[name] = asset;
            return GameObject.Instantiate(asset);
        }
    }
}
