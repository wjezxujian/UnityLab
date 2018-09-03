using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//开始命令
public class StartCommand : Command
{
    [Inject]
    public AudioManager audioManager { get; set; }
    /// <summary>
    /// 当这个命令被执行的时候，默认会调用Excute方法
    /// </summary>
    public override void Execute()
    {
        Debug.Log("start command execute");

        audioManager.Init();

        PoolManager.Instance.Init();

        LocalizationManager.Instance.Init();
    }

}
