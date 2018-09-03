using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreService : IScoreService
{

    public void OnReceiveScore(int score)
    {
        dispatcher.Dispatch(Demo1ServiceEvent.RequestScore, score);
    }

    public void RequestScore(string url)
    {
        Debug.Log("request socre from url:" + url);

        int score = Random.Range(0, 100);

        OnReceiveScore(score);
    }

    public void UpdateScore(string url, int score)
    {
        Debug.Log("update score to url:" + url + " new score:" + score);
    }

    [Inject]
    public IEventDispatcher dispatcher { get; set; }
}
