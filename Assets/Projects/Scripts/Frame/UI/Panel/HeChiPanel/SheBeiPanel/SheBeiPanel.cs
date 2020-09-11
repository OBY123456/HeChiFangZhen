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
    public Text TiltleText;
    public CheckEndPanel checkEndPanel;
    public ScrollRect TipsScrollrect;

    private string ZuZhuangMsg = "机组安装学习开始\n第一步：请点击下机架\n第二步：请点击下导轴承\n第三步：请点击转子\n第四步：请点击推力瓦\n第五步：请点击上导轴承\n第六步：请点击定子\n第七步：请点击上机架\n第八步：请点击发电机外壳\n学习完毕，点击返回键退出。";
    private string ChaiXieMsg = "机组安装学习开始\n第一步：请点击发电机外壳\n第二步：请点击上机架\n第三步：请点击定子\n第四步：请点击上导轴承\n第五步：请点击推力瓦\n第六步：请点击转子\n第七步：请点击下导轴承\n第八步：请点击下机架\n学习完毕，点击返回键退出。";

    private string[] CheckMsg_ZuZhuang = {

        "机组安装学习开始\n第一步：请点击下机架",
        "机组安装学习开始\n<color=red>第一步：请点击下机架</color>\n第二步：请点击下导轴承",
        "机组安装学习开始\n<color=red>第一步：请点击下机架\n第二步：请点击下导轴承</color>\n第三步：请点击转子",
        ""
    }; 

    public override void InitFind()
    {
        base.InitFind();
        buttons = FindTool.FindChildNode(transform, "ItemGroup/ItemButtons/Viewport/Content").GetComponentsInChildren<Button>();
        TipsScrollrect = FindTool.FindChildComponent<ScrollRect>(transform, "tips/TipsText");
        TiltleText = FindTool.FindChildComponent<Text>(transform, "tips/Text_Regular");
        checkEndPanel = FindTool.FindChildComponent<CheckEndPanel>(transform, "CheckEndPanel");
    }

    public override void InitEvent()
    {
        base.InitEvent();

        //定子
        buttons[0].onClick.AddListener(() => {

        });

        //转子
        buttons[1].onClick.AddListener(() => {

        });

        //上机架
        buttons[2].onClick.AddListener(() => {

        });

        //下机架
        buttons[3].onClick.AddListener(() => {

        });

        //集电环
        buttons[4].onClick.AddListener(() => {

        });

        //推力轴承
        buttons[5].onClick.AddListener(() => {

        });

        //上导轴承
        buttons[6].onClick.AddListener(() => {

        });

        //下导轴承
        buttons[7].onClick.AddListener(() => {

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
                SetText("机组拆卸",ChaiXieMsg);
                break;
            case TrainingEnum.TrainType.拆机组装_安装:
                SetText("机组安装", ZuZhuangMsg); 
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
        //TipsText.text = Content;
    }
}
