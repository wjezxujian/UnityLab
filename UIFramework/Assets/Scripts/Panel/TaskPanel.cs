using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TaskPanel : BasePanel
{
    private CanvasGroup canvasGroup;

    // Use this for initialization
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnClosePanel()
    {
        UIManager.Instance.PopPanel();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        GetComponent<CanvasGroup>().DOFade(1, 1.0f);
       
    }


    public override void OnExit()
    {
        base.OnExit();

        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        GetComponent<CanvasGroup>().DOFade(0, 0.5f);
    }
}
