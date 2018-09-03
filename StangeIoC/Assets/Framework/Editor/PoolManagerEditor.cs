using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PoolManagerEditor : MonoBehaviour
{
    [MenuItem("Manager/Create GameObjectPoolConfig")]
    static void CreateGameObjectPoolList()
    {
        GameObjectPoolList poolList = ScriptableObject.CreateInstance<GameObjectPoolList>();
        AssetDatabase.CreateAsset(poolList, PoolManager.PoolConfigPath);
    }
}
