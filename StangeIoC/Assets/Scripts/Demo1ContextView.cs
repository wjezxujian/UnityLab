using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;

public class Demo1ContextView : ContextView
{
    void Awake()
    {
        context = new Demo1Context(this);

        //context.Start(); //启动StrangIoC框架
    }
}
