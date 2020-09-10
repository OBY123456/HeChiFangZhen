using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class TrainingTask : BaseTask
{
    public TrainingTask(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<TrainingPanel>(WindowTypeEnum.ForegroundScreen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<TrainingPanel>(WindowTypeEnum.ForegroundScreen, UIPanelStateEnum.Hide);
    }
}
