using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMediator : Mediator
{
    [Inject]
    public CubeView cubeView{get; set;}
    //全局的Dispatcher
    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }

    [Inject]
    public AudioManager audioManager { get; set; }

    //[Inject]
    //public ScoreModel scoreModel { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        //Debug.Log(cubeView);
        Debug.Log(audioManager);

        cubeView.Init();

        cubeView.dispatcher.AddListener(Demo1MediatorEvent.ClickDown, OnClickDown);

        dispatcher.AddListener(Demo1MediatorEvent.ScoreChage, OnScoreChange);

        //通过dispacther发起请求命令
        dispatcher.Dispatch(Demo1CommandEvent.RequestScore);
    }

    public override void OnRemove()
    {
        base.OnRemove();

        cubeView.dispatcher.RemoveListener(Demo1MediatorEvent.ClickDown, OnClickDown);

        dispatcher.RemoveListener(Demo1MediatorEvent.ScoreChage, OnScoreChange);
    }

    public void OnScoreChange(IEvent evt)
    {
        cubeView.UpdateScore((int)evt.data);
        //不建议采用Model
        //cubeView.UpdateScore(scoreModel.Score);
    }

    public void OnClickDown()
    {
        dispatcher.Dispatch(Demo1CommandEvent.UpdateScore);
    }
}
