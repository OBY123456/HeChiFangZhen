using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class AdminTask : BaseTask
{
    public AdminTask(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<AdminPanel>(WindowTypeEnum.ForegroundScreen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<AdminPanel>(WindowTypeEnum.ForegroundScreen, UIPanelStateEnum.Hide);
    }
}
