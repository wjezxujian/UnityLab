using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum GameEventType
{
    Null,
    EmemyKilled,
    SoldierKilled,
    NewStage
}

public class GameEventSystem : IGameSystem
{
    private Dictionary<GameEventType, IGameEventSubject> mGameEvents = new Dictionary<GameEventType, IGameEventSubject>();

    public override void Init()
    {
        base.Init();
        InitGameEvents();
    }

    public override void Release()
    {
        //throw new NotImplementedException();
    }

    public override void Update()
    {
        //throw new NotImplementedException();
    }

    private void InitGameEvents()
    {
        //mGameEvents.Add(GameEventType.EmemyKilled, new EnemyKilledSubject());
        //mGameEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
        //mGameEvents.Add(GameEventType.NewStage, new NewStageSubject());
    }

    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        IGameEventSubject sub = GetGameEvent(eventType);
        if (sub != null)
        {
            sub.RegisterObserver(observer);
            observer.SetSubject(sub);
        }
    }

    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        IGameEventSubject sub = GetGameEvent(eventType);
        if (sub != null)
        {
            sub.RemoveObserver(observer);
            observer.SetSubject(null);
        }        
    }
    public void NotifySubject(GameEventType eventType)
    {
        IGameEventSubject sub = GetGameEvent(eventType);

        if (sub != null)
        {
            sub.Notify();
        }
    }

    private IGameEventSubject GetGameEvent(GameEventType eventType)
    {
        if (!mGameEvents.ContainsKey(eventType))
        {
            switch (eventType)
            {
            
                case GameEventType.EmemyKilled:
                    mGameEvents.Add(GameEventType.EmemyKilled, new EnemyKilledSubject());
                    break;
                case GameEventType.SoldierKilled:
                    mGameEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
                    break;
                case GameEventType.NewStage:
                    mGameEvents.Add(GameEventType.NewStage, new NewStageSubject());
                    break;
                case GameEventType.Null:
                default:
                    Debug.LogError("没有对应事件类型" + eventType + "的主题类");
                    return null;
            }
        }


        return mGameEvents[eventType];
    }
    
}
