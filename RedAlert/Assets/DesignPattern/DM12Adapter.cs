using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM12Adapter : MonoBehaviour
{
    private void Start()
    {
        Adapter si = new Adapter(new NewPlugin());
        si.Request();
    }

}

interface StandardInterface
{
    void Request();
}

class StandardImplementA : StandardInterface
{
    public void Request()
    {
        Debug.Log("使用标准方法实现请求");
    }
}

class Adapter : StandardInterface
{
    private NewPlugin mNewPlugin;

    public Adapter(NewPlugin newPlugin)
    {
        mNewPlugin = newPlugin;
    }

    public void Request()
    {
        mNewPlugin.SpecificRequest();
    }
}

class NewPlugin
{
    public void SpecificRequest()
    {
        Debug.Log("使用特殊方法实现请求");
    }
}
