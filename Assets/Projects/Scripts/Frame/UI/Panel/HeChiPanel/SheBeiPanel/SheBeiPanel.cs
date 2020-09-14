using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using MTFrame.MTEvent;
using System;
using ShebeiEnum;

public class SheBeiPanel : BasePanel
{
    public Button[] buttons;
    public CheckEndPanel checkEndPanel;
    public TipsGroup Tipsgroup;
    private string CheckTiltle = "考核内容";

    private string ZuZhuangMsg = "机组安装学习开始\n第一步：请点击下机架\n第二步：请点击下导轴承\n第三步：请点击转子\n第四步：请点击推力瓦\n第五步：请点击上导轴承\n第六步：请点击定子\n第七步：请点击上机架\n第八步：请点击发电机外壳\n学习完毕，点击返回键退出。";
    private string ChaiXieMsg = "机组拆卸学习开始\n第一步：请点击发电机外壳\n第二步：请点击上机架\n第三步：请点击定子\n第四步：请点击上导轴承\n第五步：请点击推力瓦\n第六步：请点击转子\n第七步：请点击下导轴承\n第八步：请点击下机架\n学习完毕，点击返回键退出。";

    private string[] CheckMsg_ZuZhuang = {
        "机组安装考核开始",
        "第一题：请在右边操作组件栏中选择第一步要组装的组件。总分12.5分。",
        "第二题：请在右边操作组件栏中选择第二步要组装的组件。总分12.5分。",
        "第三题：请在右边操作组件栏中选择第三步要组装的组件。总分12.5分。",
        "第四题：请在右边操作组件栏中选择第四步要组装的组件。总分12.5分。",
        "第五题：请在右边操作组件栏中选择第五步要组装的组件。总分12.5分。",
        "第六题：请在右边操作组件栏中选择第六步要组装的组件。总分12.5分。",
        "第七题：请在右边操作组件栏中选择第七步要组装的组件。总分12.5分。",
        "第八题：请在右边操作组件栏中选择第八步要组装的组件。总分12.5分。",
    };

    private string[] CheckMsg_ChaiXie = {

        "机组拆卸考核开始",
        "第一题：请在右边操作组件栏中选择第一步要拆卸的组件。总分12.5分。",
        "第二题：请在右边操作组件栏中选择第二步要拆卸的组件。总分12.5分。",
        "第三题：请在右边操作组件栏中选择第三步要拆卸的组件。总分12.5分。",
        "第四题：请在右边操作组件栏中选择第四步要拆卸的组件。总分12.5分。",
        "第五题：请在右边操作组件栏中选择第五步要拆卸的组件。总分12.5分。",
        "第六题：请在右边操作组件栏中选择第六步要拆卸的组件。总分12.5分。",
        "第七题：请在右边操作组件栏中选择第七步要拆卸的组件。总分12.5分。",
        "第八题：请在右边操作组件栏中选择第八步要拆卸的组件。总分12.5分。",
    };

    private bool IsCheck1, IsCheck2, IsCheck3, IsCheck4, IsCheck5, IsCheck6, IsCheck7;

    public override void InitFind()
    {
        base.InitFind();
        buttons = FindTool.FindChildNode(transform, "ItemGroup/ItemButtons/Viewport/Content").GetComponentsInChildren<Button>();
        Tipsgroup = FindTool.FindChildComponent<TipsGroup>(transform, "TipsGroup");
        checkEndPanel = FindTool.FindChildComponent<CheckEndPanel>(transform, "CheckEndPanel");
    }

    public override void InitEvent()
    {
        base.InitEvent();

        //定子
        buttons[0].onClick.AddListener(() => {

            CheckFundation(SheBeiType.定子, TrainingPanel.trainType);
        });

        //转子
        buttons[1].onClick.AddListener(() => {

            CheckFundation(SheBeiType.转子, TrainingPanel.trainType);
        });

        //上机架
        buttons[2].onClick.AddListener(() => {
            CheckFundation(SheBeiType.上机架, TrainingPanel.trainType);
        });

        //下机架
        buttons[3].onClick.AddListener(() => {
            CheckFundation(SheBeiType.下机架, TrainingPanel.trainType);
        });

        //电机外壳
        buttons[4].onClick.AddListener(() => {
            CheckFundation(SheBeiType.电机外壳, TrainingPanel.trainType);
        });

        //推力轴承
        buttons[5].onClick.AddListener(() => {
            CheckFundation(SheBeiType.推力轴承, TrainingPanel.trainType);
        });

        //上导轴承
        buttons[6].onClick.AddListener(() => {
            CheckFundation(SheBeiType.上导轴承, TrainingPanel.trainType);
        }); 

        //下导轴承
        buttons[7].onClick.AddListener(() => {
            CheckFundation(SheBeiType.下导轴承, TrainingPanel.trainType);
        });

        checkEndPanel.CloseButton.onClick.AddListener(() => {
            PanelState.SwitchPanel(PanelName.CheckPanel);
        });
    }

    private void SentMsg(SheBeiType sheBeiType)
    {
        EventParamete eventParamete = new EventParamete();
        eventParamete.AddParameter(sheBeiType);
        EventManager.TriggerEvent(GenericEventEnumType.Message, "SBZX", eventParamete);
    }

    private void CheckFundation(SheBeiType sheBeiType, TrainingEnum.TrainType trainType)
    {
        SentMsg(sheBeiType);
        if (DirectoryPanel.functionType == DirectoryEnum.FunctionType.Check)
        {
            switch (trainType)
            {
                case TrainingEnum.TrainType.拆机组装_拆卸:
                    switch (sheBeiType)
                    {
                        case SheBeiType.定子:
                            if (IsCheck2 && !IsCheck3)
                            {
                                IsCheck3 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ChaiXie[4]);
                                checkEndPanel.ScoreAdd(12.5f);
                            }
                            break;
                        case SheBeiType.转子:
                            if (IsCheck5 && !IsCheck6)
                            {
                                IsCheck6 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ChaiXie[7]);
                                checkEndPanel.ScoreAdd(12.5f);
                                
                            }
                            break;
                        case SheBeiType.上机架:
                            if (IsCheck1 && !IsCheck2)
                            {
                                IsCheck2 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ChaiXie[3]);
                                checkEndPanel.ScoreAdd(12.5f);
                            }
                            break;
                        case SheBeiType.下机架:
                            if (IsCheck7)
                            {
                                Tipsgroup.SetTextColor(Tipsgroup.TextGroup.Count - 1);
                                checkEndPanel.ScoreAdd(12.5f);
                            }
                            break;
                        case SheBeiType.电机外壳:
                            if(!IsCheck1)
                            {
                                IsCheck1 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ChaiXie[2]);
                                checkEndPanel.ScoreAdd(12.5f);
                            }
                            break;
                        case SheBeiType.推力轴承:
                            if (IsCheck4 && !IsCheck5)
                            {
                                IsCheck5 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ChaiXie[6]);
                                checkEndPanel.ScoreAdd(12.5f);
                            }
                            break;
                        case SheBeiType.上导轴承:
                            if (IsCheck3 && !IsCheck4)
                            {
                                IsCheck4 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ChaiXie[5]);
                                checkEndPanel.ScoreAdd(12.5f);
                            }
                            break;
                        case SheBeiType.下导轴承:
                            if (IsCheck6 && !IsCheck7)
                            {
                                IsCheck7 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ChaiXie[8]);
                                checkEndPanel.ScoreAdd(12.5f);
                                StartCoroutine("InsSrollBar");
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case TrainingEnum.TrainType.拆机组装_安装:
                    switch (sheBeiType)
                    {
                        case SheBeiType.定子:
                            if (!IsCheck6 && IsCheck5)
                            {
                                IsCheck6 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ZuZhuang[7]);
                                checkEndPanel.ScoreAdd(12.5f);
                            }
                            break;
                        case SheBeiType.转子:
                            if (!IsCheck3 && IsCheck2)
                            {
                                IsCheck3 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ZuZhuang[4]);
                                checkEndPanel.ScoreAdd(12.5f);
                            }
                            break;
                        case SheBeiType.上机架:
                            if (!IsCheck7 && IsCheck6)
                            {
                                IsCheck7 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ZuZhuang[8]);
                                checkEndPanel.ScoreAdd(12.5f);
                                StartCoroutine("InsSrollBar");
                            }
                            break;
                        case SheBeiType.下机架:
                            if(!IsCheck1)
                            {
                                IsCheck1 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ZuZhuang[2]);
                                checkEndPanel.ScoreAdd(12.5f);
                            }

                            break;
                        case SheBeiType.电机外壳:
                            if (IsCheck7)
                            {
                                Tipsgroup.SetTextColor(Tipsgroup.TextGroup.Count - 1);
                                checkEndPanel.ScoreAdd(12.5f);
                            }
                            break;
                        case SheBeiType.推力轴承:
                            if (!IsCheck4 && IsCheck3)
                            {
                                IsCheck4 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ZuZhuang[5]);
                                checkEndPanel.ScoreAdd(12.5f);
                            }
                            break;
                        case SheBeiType.上导轴承:
                            if (!IsCheck5 && IsCheck4)
                            {
                                IsCheck5 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ZuZhuang[6]);
                                checkEndPanel.ScoreAdd(12.5f);
                            }
                            break;
                        case SheBeiType.下导轴承:
                            if (!IsCheck2 && IsCheck1)
                            {
                                IsCheck2 = true;
                                Tipsgroup.SetCheckText(CheckTiltle, CheckMsg_ZuZhuang[3]);
                                checkEndPanel.ScoreAdd(12.5f);
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator InsSrollBar()
    {
        yield return new WaitForEndOfFrame();
        Tipsgroup.scrollRect.verticalNormalizedPosition = 0;
    }

    public override void Open()
    {
        base.Open();

        Main.Instance.MainCamera.backgroundColor = Color.white;
        checkEndPanel.Hide();
        Tipsgroup.Open();
        IsCheck1 = IsCheck2 = IsCheck3 = IsCheck4 = IsCheck5 = IsCheck6 = IsCheck7 = false;

        if (DirectoryPanel.functionType == DirectoryEnum.FunctionType.Check)
        {
            checkEndPanel.Open();
            switch (TrainingPanel.trainType)
            {
                case TrainingEnum.TrainType.拆机组装_拆卸:
                    Tipsgroup.SetCheckText("考核内容", CheckMsg_ChaiXie[0]);
                    Tipsgroup.SetCheckText("考核内容", CheckMsg_ChaiXie[1]);
                    break;
                case TrainingEnum.TrainType.拆机组装_安装:
                    Tipsgroup.SetCheckText("考核内容", CheckMsg_ZuZhuang[0]);
                    Tipsgroup.SetCheckText("考核内容", CheckMsg_ZuZhuang[1]);
                    break;
                default:
                    break;
            }
            EventManager.AddListener(MTFrame.MTEvent.GenericEventEnumType.Message, TrainingEnum.TrainType.拆机组装_安装.ToString(), Callback);
        }
        else
        {
            switch (TrainingPanel.trainType)
            {
                case TrainingEnum.TrainType.拆机组装_拆卸:
                    Tipsgroup.SetText("机组拆卸", ChaiXieMsg);
                    break;
                case TrainingEnum.TrainType.拆机组装_安装:
                    Tipsgroup.SetText("机组安装", ZuZhuangMsg);
                    break;
                default:
                    break;
            }
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
        Tipsgroup.Hide();
    }
}
