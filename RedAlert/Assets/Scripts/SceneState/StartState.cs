using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class StartState : ISceneState
{
    private Image mLogo;
    private float mSmoothingSpeed = 0.5f;
    private float mWaitTime = 2f;

    public StartState(SceneStateController controller) : base("01StartScene", controller)
    {

    }

    public override void StateStart()
    {
        mLogo = GameObject.Find("Logo").GetComponent<Image>();
        mLogo.color = Color.black;
        mWaitTime = 2f;
    }

    public override void StateUpdate()
    {
        mLogo.color = Color.Lerp(mLogo.color, Color.white, mSmoothingSpeed * Time.deltaTime);

        mWaitTime -= Time.deltaTime;
        if(mWaitTime <= 0)
        {
            mController.SetState(new MainMenuState(mController));
        }
    }

    public override void StateEnd()
    {
        base.StateEnd();
    }
}
