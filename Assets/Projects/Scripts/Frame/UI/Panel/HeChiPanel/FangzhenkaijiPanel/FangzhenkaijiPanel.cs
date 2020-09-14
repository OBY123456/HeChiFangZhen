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
    public TipsGroup tipsGroup;

    private string KaijiMsg = "设备开机操作学习现在开始\n第一步：请点击复位PLC\n第二步：请点击1GS开机令\n第三步：请点击空转到空载\n第四步：请点击1GS并网\n第五步：请点击1GS切同期\n第六步：请点击11GS起励\n第七步：请点击11GS并网\n第八步：请点击发11GS切同期";
    private string GuanjiMsg = "设备关机操作学习现在开始\n第一步：请点击停机\n第二步：请点击减负荷1\n第三步：请点击减负荷2\n第四步：请点击风闸开关";

    public override void InitFind()
    {
        base.InitFind();
        kaijiPanel = FindTool.FindChildComponent<KaijiPanel>(transform, "KaijiPanel");
        guanjiPanel = FindTool.FindChildComponent<GuanjiPanel>(transform, "GuanjiPanel");
        endPanel = FindTool.FindChildComponent<CheckEndPanel>(transform, "CheckEndPanel");
        checkEndPanel = FindTool.FindChildComponent<CheckEndPanel>(transform, "CheckEndPanel");

        tipsGroup = FindTool.FindChildComponent<TipsGroup>(transform, "TipsGroup");
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
        tipsGroup.Open();
        if (DirectoryPanel.functionType == DirectoryEnum.FunctionType.Check)
        {
            endPanel.Open();
            switch (TrainingPanel.trainType)
            {
                case TrainingEnum.TrainType.仿真开机:
                    guanjiPanel.Hide();
                    kaijiPanel.Open();
                    break;
                case TrainingEnum.TrainType.仿真关机:
                    kaijiPanel.Hide();
                    guanjiPanel.Open();
                    break;
                default:
                    break;
            }
        }
        else
        {
            endPanel.Hide();
            switch (TrainingPanel.trainType)
            {
                case TrainingEnum.TrainType.仿真开机:
                    guanjiPanel.Hide();
                    kaijiPanel.Open();
                    tipsGroup.SetText("仿真开机", KaijiMsg);
                    break;
                case TrainingEnum.TrainType.仿真关机:
                    kaijiPanel.Hide();
                    guanjiPanel.Open();
                    tipsGroup.SetText("仿真关机", GuanjiMsg);
                    break;
                default:
                    break;
            }
        }
    }

    public override void Hide()
    {
        base.Hide();
        kaijiPanel.Hide();
        guanjiPanel.Hide();
        endPanel.Hide();
        tipsGroup.Hide();
    }
}
