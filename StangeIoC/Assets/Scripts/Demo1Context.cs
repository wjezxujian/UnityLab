using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1Context : MVCSContext
{
    public Demo1Context(MonoBehaviour view) : base(view)
    {

    }

    //进行绑定映射
    protected override void mapBindings()
    {
        //base.mapBindings();
        //manager
        injectionBinder.Bind<AudioManager>().To<AudioManager>().ToSingleton();

        //Model
        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();

        //Services
        //ToSingleton生成单例
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();

        //Command
        commandBinder.Bind(Demo1CommandEvent.RequestScore).To<RequestScoreCommand>();
        commandBinder.Bind(Demo1CommandEvent.UpdateScore).To<UpdateScoreCommand>();

        //Mediator
        //完成Mediator与View的绑定
        mediationBinder.Bind<CubeView>().To<CubeMediator>();

        //创建一个startCommand
        //Once触发一次解绑
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
        
    }
}
