using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using DG.Tweening;
using TrainingEnum;

public class CheckPanel : BasePanel
{
    public Button[] buttons;
    public Button[] Chaijizuzhuang;
    public Button[] Shebeicaozuo;

    public CanvasGroup CJZZ, SBCZ;

    public override void InitFind()
    {
        base.InitFind();
        buttons = FindTool.FindChildNode(transform, "Buttons").GetComponentsInChildren<Button>();
        Chaijizuzhuang = FindTool.FindChildNode(transform, "SecondLevelButtons").GetComponentsInChildren<Button>();
        Shebeicaozuo = FindTool.FindChildNode(transform, "SecondLevelButtons (1)").GetComponentsInChildren<Button>();

        CJZZ = FindTool.FindChildComponent<CanvasGroup>(transform, "SecondLevelButtons");
        SBCZ = FindTool.FindChildComponent<CanvasGroup>(transform, "SecondLevelButtons (1)");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        buttons[0].onClick.AddListener(() => {
            //电站认知界面
            TrainingPanel.trainType = TrainType.电站认知;
            PanelState.SwitchPanel(PanelName.ManYouPanel);
        });

        buttons[1].onClick.AddListener(() => {
            CJZZ.DOFade(1, 0.5f);
            CJZZ.blocksRaycasts = true;
        });

        buttons[2].onClick.AddListener(() => {
            SBCZ.DOFade(1, 0.5f);
            SBCZ.blocksRaycasts = true;
        });

        Chaijizuzhuang[0].onClick.AddListener(() => {
            TrainingPanel.trainType = TrainType.拆机组装_拆卸;
            PanelState.SwitchPanel(PanelName.SheBeiPanel);
        });

        Chaijizuzhuang[1].onClick.AddListener(() => {
            TrainingPanel.trainType = TrainType.拆机组装_安装;
            PanelState.SwitchPanel(PanelName.SheBeiPanel);
        });

        Shebeicaozuo[0].onClick.AddListener(() => {
            TrainingPanel.trainType = TrainType.仿真开机;
            PanelState.SwitchPanel(PanelName.FangzhenkaijiPanel);
        });

        Shebeicaozuo[1].onClick.AddListener(() => {
            TrainingPanel.trainType = TrainType.仿真关机;
            PanelState.SwitchPanel(PanelName.FangzhenkaijiPanel);
        });
    }

    public override void Open()
    {
        base.Open();
        Reset();
    }

    public override void Hide()
    {
        base.Hide();
    }

    private void Reset()
    {
        SBCZ.alpha = 0;
        SBCZ.blocksRaycasts = false;

        CJZZ.alpha = 0;
        CJZZ.blocksRaycasts = false;
    }
}
