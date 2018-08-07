using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对Dictionary的扩展
/// </summary>
public static class DictionaryExtension
{
    /// <summary>
    /// 尝试根据Key得到Value, 得到了的画直接返回value, 没有得到直接返回null
    /// </summary>
    public static Tvalue TryGet<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> dict,  Tkey key)
    {
        Tvalue value;
        dict.TryGetValue(key, out value);

        return value;
    }
}
