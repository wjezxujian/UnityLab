using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkillPanel : BasePanel
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

        transform.localScale = Vector3.zero;
        transform.DOScale(1, .5f);

    }


    public override void OnExit()
    {
        transform.DOScale(0, .5f).OnComplete(()=> base.OnExit());
    }
}
