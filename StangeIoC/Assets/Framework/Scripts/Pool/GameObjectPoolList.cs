using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//继承自ScriptableObject 表示把类GameObjectPoolList变成可以自定义资源配置的文件
public class GameObjectPoolList : ScriptableObject
{
    public List<GameObjectPool> poolList;
}
