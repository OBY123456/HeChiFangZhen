using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class SheBeiTask : BaseTask
{
    public SheBeiTask(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<SheBeiPanel>(WindowTypeEnum.ForegroundScreen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<SheBeiPanel>(WindowTypeEnum.ForegroundScreen, UIPanelStateEnum.Hide);
    }
}
