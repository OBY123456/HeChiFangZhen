using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class ManYouTask : BaseTask
{
    public ManYouTask(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<ManYouPanel>(WindowTypeEnum.ForegroundScreen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<ManYouPanel>(WindowTypeEnum.ForegroundScreen, UIPanelStateEnum.Hide);
    }
}
