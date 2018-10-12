using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleState : ISceneState
{
    private GameFacade mFacade;

    public BattleState(SceneStateController controller) : base("03BattleScene", controller)
    {

    }

    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }

    public override void StateEnd()
    {
        GameFacade.Instance.Release();
    }

    public override void StateUpdate()
    {
        if(GameFacade.Instance.isGameOver)
        {
            mController.SetState(new MainMenuState(mController));
        }
        GameFacade.Instance.Update();
    }

    //兵营

    //关卡

    //角色管理

    //行动力

    //成就…
}

