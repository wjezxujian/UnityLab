using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreService
{
    //请求分数
    void RequestScore(string url); 

    //收到服务器端发送过来的分数
    void OnReceiveScore(int score);

    //更新分数
    void UpdateScore(string url, int socre);

    IEventDispatcher dispatcher { get; set; }


    
}
