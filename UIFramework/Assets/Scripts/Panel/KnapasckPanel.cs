using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KnapasckPanel : BasePanel
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();

        Vector3 temp = transform.localPosition;
        temp.x = 800;
        transform.localPosition = temp;
        transform.DOLocalMoveX(0, 0.5f);
    }

    public override void OnExit()
    {
        base.OnExit();

        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;

        transform.DOLocalMoveX(800, 0.5f).OnComplete(() => canvasGroup.alpha = 0);

    }
}
