using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestScoreCommand : EventCommand
{
    [Inject]
    public IScoreService scoreService { get; set; }
    [Inject]
    public ScoreModel scoreMode { get; set; }
    public override void Execute()
    {
        Retain();
        scoreService.dispatcher.AddListener(Demo1ServiceEvent.RequestScore, OnComplete);

        scoreService.RequestScore("http://xx/xxx/xxx");
    }

    private void OnComplete(IEvent evt)
    {
        Debug.Log("request score complete: " + evt.data);

        scoreService.dispatcher.RemoveListener(Demo1ServiceEvent.RequestScore, OnComplete);

        scoreMode.Score = (int)evt.data;

        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChage, evt.data);



        Release();
    }
}
