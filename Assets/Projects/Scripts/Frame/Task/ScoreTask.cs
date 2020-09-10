using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class ScoreTask : BaseTask
{
    public ScoreTask(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<ScorePanel>(WindowTypeEnum.ForegroundScreen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<ScorePanel>(WindowTypeEnum.ForegroundScreen, UIPanelStateEnum.Hide);
    }
}
