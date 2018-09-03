using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    private static PoolManager _instance;
    private Dictionary<string, GameObjectPool> poolDict;

    private static string poolConfigPathPrefix = "Assets/Framework/Resources/";
    private const string poolConfigPathMiddle = "GameObjectPool";
    private const string poolConfigPathPostfix = ".asset";

    public static string PoolConfigPath
    {
        get
        {
            return poolConfigPathPrefix + poolConfigPathMiddle + poolConfigPathPostfix;
        }
    }

    public static PoolManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new PoolManager();
            }
            return _instance;
        }
    }

    private PoolManager()
    {
        var poolList = Resources.Load<GameObjectPoolList>(poolConfigPathMiddle);

        poolDict = new Dictionary<string, GameObjectPool>();

        foreach(GameObjectPool pool in poolList.poolList)
        {
            poolDict.Add(pool.name, pool);
        }
    }

    public void Init()
    {
        //Do Nothing
    }

    public GameObject GetInst(string poolName)
    {
        GameObjectPool pool = null;
        if(poolDict.TryGetValue(poolName, out pool))
        {
            return pool.GetInst();
        }
        else
        {
            Debug.LogWarning("Pool：" + poolName + "is not exits!!");
            return null;
        }
    }
}
