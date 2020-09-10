using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using DG.Tweening;
using TrainingEnum;

public class TrainingPanel : BasePanel
{
    public Button[] buttons;
    public Button[] Chaijizuzhuang;
    public Button[] Shebeicaozuo;

    public CanvasGroup CJZZ,SBCZ;

    public Image Arrow_CJZZ, Arrow_SBCZ;

    public static TrainType trainType;

    public Sprite[] Arrow;

    public override void InitFind()
    {
        base.InitFind();
        buttons = FindTool.FindChildNode(transform, "Buttons").GetComponentsInChildren<Button>();
        Chaijizuzhuang = FindTool.FindChildNode(transform, "SecondLevelButtons").GetComponentsInChildren<Button>();
        Shebeicaozuo = FindTool.FindChildNode(transform, "SecondLevelButtons (1)").GetComponentsInChildren<Button>();

        CJZZ = FindTool.FindChildComponent<CanvasGroup>(transform, "SecondLevelButtons");
        SBCZ = FindTool.FindChildComponent<CanvasGroup>(transform, "SecondLevelButtons (1)");

        Arrow_CJZZ = FindTool.FindChildComponent<Image>(transform, "Buttons/chaijizuzhuang/Image");
        Arrow_SBCZ = FindTool.FindChildComponent<Image>(transform, "Buttons/shebeicaozuo/Image");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        buttons[0].onClick.AddListener(() => {
            //漫游浏览界面
            trainType = TrainType.漫游浏览;
            PanelState.SwitchPanel(PanelName.ManYouPanel);
        });

        buttons[1].onClick.AddListener(() => {
            //电站认知界面
            trainType = TrainType.电站认知;
            PanelState.SwitchPanel(PanelName.ManYouPanel);
        });

        buttons[2].onClick.AddListener(() => {

            CJZZ.Open();
            Arrow_CJZZ.sprite = Arrow[1];

            SBCZ.Hide();
            Arrow_SBCZ.sprite = Arrow[0];
        });

        buttons[3].onClick.AddListener(() => {

            SBCZ.Open();
            Arrow_SBCZ.sprite = Arrow[1];

            CJZZ.Hide();
            Arrow_CJZZ.sprite = Arrow[0];
        });

        Chaijizuzhuang[0].onClick.AddListener(() => {
            trainType = TrainType.拆机组装_拆卸;
            PanelState.SwitchPanel(PanelName.SheBeiPanel);
        });

        Chaijizuzhuang[1].onClick.AddListener(() => {
            trainType = TrainType.拆机组装_安装;
            PanelState.SwitchPanel(PanelName.SheBeiPanel);
        });

        Shebeicaozuo[0].onClick.AddListener(() => {
            trainType = TrainType.仿真开机;
            PanelState.SwitchPanel(PanelName.FangzhenkaijiPanel);
        });

        Shebeicaozuo[1].onClick.AddListener(() => {
            trainType = TrainType.仿真关机;
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
        SBCZ.Hide();
        Arrow_SBCZ.sprite = Arrow[0];

        CJZZ.Hide();
        Arrow_CJZZ.sprite = Arrow[0];
    }
}
