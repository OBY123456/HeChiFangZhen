using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using MTFrame.MTEvent;
using System;

public class SheBeiPanel : BasePanel
{
    public Button[] buttons;
    public Text TipsText,TiltleText;
    public CheckEndPanel checkEndPanel;

    public override void InitFind()
    {
        base.InitFind();
        buttons = FindTool.FindChildNode(transform, "ItemGroup/ItemButtons/Viewport/Content").GetComponentsInChildren<Button>();
        TipsText = FindTool.FindChildComponent<Text>(transform, "tips/Content/Text_Medium");
        TiltleText = FindTool.FindChildComponent<Text>(transform, "tips/Content/Text_Regular");
        checkEndPanel = FindTool.FindChildComponent<CheckEndPanel>(transform, "CheckEndPanel");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        buttons[0].onClick.AddListener(() => {

        });

        buttons[1].onClick.AddListener(() => {

        });

        buttons[2].onClick.AddListener(() => {

        });

        buttons[3].onClick.AddListener(() => {

        });

        buttons[4].onClick.AddListener(() => {

        });

        buttons[5].onClick.AddListener(() => {

        });

        buttons[6].onClick.AddListener(() => {

        });

        buttons[7].onClick.AddListener(() => {

        });

        buttons[8].onClick.AddListener(() => {

        });

        checkEndPanel.CloseButton.onClick.AddListener(() => {
            PanelState.SwitchPanel(PanelName.CheckPanel);
        });
    }

    public override void Open()
    {
        base.Open();

        Main.Instance.MainCamera.backgroundColor = Color.white;
        checkEndPanel.Hide();
        switch (TrainingPanel.trainType)
        {
            case TrainingEnum.TrainType.拆机组装_拆卸:
                SetText("机组拆卸","asdasdasdads");
                break;
            case TrainingEnum.TrainType.拆机组装_安装:
                SetText("机组安装", "asdasdasdads"); 
                break;
            default:
                break;
        }

        if(DirectoryPanel.functionType == DirectoryEnum.FunctionType.Check)
        {
            checkEndPanel.Open();
            SetText("考核内容", "asdasdasdads"); 
            EventManager.AddListener(MTFrame.MTEvent.GenericEventEnumType.Message, TrainingEnum.TrainType.拆机组装_安装.ToString(), Callback);
        }
        else
        {
            checkEndPanel.Hide();
        }

        MainControl.Instance.Shebeizhuangxie.gameObject.SetActive(true);
    }

    private void Callback(EventParamete parameteData)
    {
        if(checkEndPanel.IsStart)
        {
            checkEndPanel.ScoreData += 10;
            checkEndPanel.ScoreText.text = checkEndPanel.ScoreData.ToString();
            if (checkEndPanel.ScoreData == 100)
            {
                checkEndPanel.TipsCanvas_Open();
            }
        }

    }

    public override void Hide()
    {
        base.Hide();
        Main.Instance.MainCamera.backgroundColor = Color.black;
        MainControl.Instance.Shebeizhuangxie.gameObject.SetActive(false);
        EventManager.AddListener(MTFrame.MTEvent.GenericEventEnumType.Message, TrainingEnum.TrainType.拆机组装_安装.ToString(), Callback);
        checkEndPanel.Hide();
    }

    private void SetText(string Tiltle, string Content)
    {
        TiltleText.text = Tiltle;
        TipsText.text = Content;
    }
}
