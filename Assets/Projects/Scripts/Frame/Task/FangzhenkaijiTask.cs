using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class FangzhenkaijiTask : BaseTask
{
    public FangzhenkaijiTask(BaseState state) : base(state)
    {
    }

    public override void Enter()
    {
        base.Enter();
        UIManager.CreatePanel<FangzhenkaijiPanel>(WindowTypeEnum.ForegroundScreen);
    }

    public override void Exit()
    {
        base.Exit();
        UIManager.ChangePanelState<FangzhenkaijiPanel>(WindowTypeEnum.ForegroundScreen, UIPanelStateEnum.Hide);
    }
}
