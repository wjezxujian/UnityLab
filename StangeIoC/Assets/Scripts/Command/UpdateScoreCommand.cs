using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScoreCommand : EventCommand
{
    [Inject]
    public ScoreModel scoreModel { get; set; }

    [Inject]
    public IScoreService scoreService { get; set; }

    public override void Execute()
    {
        scoreModel.Score++;
        scoreService.UpdateScore("http//xxx/xx/x", scoreModel.Score);

        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChage, scoreModel.Score);
    }
}
