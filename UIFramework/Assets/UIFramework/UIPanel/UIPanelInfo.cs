using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UIPanelInfo : ISerializationCallbackReceiver
{
    [NonSerialized]
    public UIPanelType panelType;
    public string panelTypeStr;
    //{
    //    get
    //    {
    //        return panelType.ToString();
    //    }
    //    set
    //    {
    //        panelType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), value);
    //    }
    //}
    public string path;

    //反序列化
    public void OnAfterDeserialize()
    {
        Debug.Log(panelTypeStr);
        panelType = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeStr);
    }

    public void OnBeforeSerialize()
    {
        //Debug.Log(panelTypeStr);
    }
}
