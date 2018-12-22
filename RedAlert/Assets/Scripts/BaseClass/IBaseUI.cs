using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class IBaseUI
{
    public GameObject mRootUI;

    public virtual void Init()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Release()
    {

    }

    protected void Show()
    {
        mRootUI.SetActive(true);
    }

    protected void Hide()
    {
        mRootUI.SetActive(false);
    }
}