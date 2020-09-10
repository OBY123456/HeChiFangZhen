using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;

public class FangzhenkaijiPanel : BasePanel
{
    public KaijiPanel kaijiPanel;
    public GuanjiPanel guanjiPanel;
    public CheckEndPanel endPanel;
    public Color Red, Green;
    public CheckEndPanel checkEndPanel;

    public Text TiltleText, TipsText;

    public override void InitFind()
    {
        base.InitFind();
        kaijiPanel = FindTool.FindChildComponent<KaijiPanel>(transform, "KaijiPanel");
        guanjiPanel = FindTool.FindChildComponent<GuanjiPanel>(transform, "GuanjiPanel");
        endPanel = FindTool.FindChildComponent<CheckEndPanel>(transform, "CheckEndPanel");
        checkEndPanel = FindTool.FindChildComponent<CheckEndPanel>(transform, "CheckEndPanel");

        TipsText = FindTool.FindChildComponent<Text>(transform, "tips/Content/Text_Medium");
        TiltleText = FindTool.FindChildComponent<Text>(transform, "tips/Text_Regular");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        checkEndPanel.CloseButton.onClick.AddListener(() => {
            PanelState.SwitchPanel(PanelName.CheckPanel);
        });
    }

    public override void Open()
    {
        base.Open();
        switch (TrainingPanel.trainType)
        {
            case TrainingEnum.TrainType.仿真开机:
                guanjiPanel.Hide();
                kaijiPanel.Open();
                SetText("仿真开机", TrainingEnum.TrainType.仿真开机.ToString());
                break;
            case TrainingEnum.TrainType.仿真关机:
                kaijiPanel.Hide();
                guanjiPanel.Open();
                SetText("仿真关机", TrainingEnum.TrainType.仿真关机.ToString());
                break;
            default:
                break;
        }

        if (DirectoryPanel.functionType == DirectoryEnum.FunctionType.Check)
        {
            endPanel.Open();
            SetText("考核内容", TrainingEnum.TrainType.仿真关机.ToString());
        }
        else
        {
            endPanel.Hide();
        }
    }

    public override void Hide()
    {
        base.Hide();
        kaijiPanel.Hide();
        guanjiPanel.Hide();
        endPanel.Hide();
    }

    private void SetText(string Tiltle, string Content)
    {
        TiltleText.text = Tiltle;
        TipsText.text = Content;
    }
}
