using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : ISceneState
{
    public MainMenuState(SceneStateController controller) : base("02MainMenuScene", controller)
    {

    }

    public override void StateStart()
    {
        GameObject.Find("StartButton").GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
    }

    public override void StateEnd()
    {
        base.StateEnd();
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    private void OnStartButtonClick()
    {
        mController.SetState(new BattleState(mController));
    }
}