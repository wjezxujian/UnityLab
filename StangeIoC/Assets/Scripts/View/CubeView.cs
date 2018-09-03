using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeView : View
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

   
    private Text scoreText;

    /// <summary>
    /// 做初始化
    /// </summary>
    public void Init()
    {
        scoreText = GetComponentInChildren<Text>();
    }

    public void Update()
    {
        transform.Translate(new Vector3(Random.Range(-2, 3), Random.Range(-1, 2), Random.Range(-1, 2)) * 0.03f);

        if(Input.GetMouseButtonDown(0))
        {
            PoolManager.Instance.GetInst("Bullet");
        }
    }

    private void OnMouseDown()
    {
        //加分
        Debug.Log("OnMouseDown");

        dispatcher.Dispatch(Demo1MediatorEvent.ClickDown);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
