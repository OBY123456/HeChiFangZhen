using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MTFrame;
using DirectoryEnum;

public class GuanjiPanel : BasePanel
{
    public Image[] StateImage;
    public Button StopButton,LeftButton,RightButton,SwitchButton;
    public Text LeftText, RightText;
    public FangzhenkaijiPanel fangzhenkaijiPanel;

    private bool IsDown0, IsDown1, IsDown2;
    private float Score = 25;
    private string CheckContent = "考核内容";
    private string[] CheckMsg = {
        "设备关机操作考核现在开始",
        "第一题：请点击第一步要操作的按钮。总分25分。",
        "第二题：请点击第二步要操作的按钮。总分25分。",
        "第三题：请点击第三步要操作的按钮。总分25分。",
        "第四题：请点击第三步要操作的按钮。总分25分。",
    };

    public override void InitFind()
    {
        base.InitFind();
        //StateImage = FindTool.FindChildNode(transform, "StateImage").GetComponentsInChildren<Image>();
        StopButton = FindTool.FindChildComponent<Button>(transform, "StopButton");
        LeftButton = FindTool.FindChildComponent<Button>(transform, "LeftButton");
        RightButton = FindTool.FindChildComponent<Button>(transform, "RightButton");
        SwitchButton = FindTool.FindChildComponent<Button>(transform, "switchButton");
        LeftText = FindTool.FindChildComponent<Text>(transform, "TextGroup/left/Button/Text");
        RightText = FindTool.FindChildComponent<Text>(transform, "TextGroup/right/Button/Text");
        fangzhenkaijiPanel = FindTool.FindParentComponent<FangzhenkaijiPanel>(transform, "FangzhenkaijiPanel");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        StopButton.onClick.AddListener(() => {

            if(!IsDown0)
            {
                IsDown0 = true;
                StateImage[0].color = fangzhenkaijiPanel.Green;

                if (DirectoryPanel.functionType == FunctionType.Check)
                {
                    fangzhenkaijiPanel.checkEndPanel.ScoreAdd(Score);
                    fangzhenkaijiPanel.tipsGroup.SetCheckText(CheckContent, CheckMsg[2]);
                }
            }
        });

        LeftButton.onClick.AddListener(() => {

            if(!IsDown1 && IsDown0)
            {
                IsDown1 = true;

                LeftText.text = "0";

                if (DirectoryPanel.functionType == FunctionType.Check)
                {
                    fangzhenkaijiPanel.checkEndPanel.ScoreAdd(Score);
                    fangzhenkaijiPanel.tipsGroup.SetCheckText(CheckContent, CheckMsg[3]);
                }
            }

        });

        RightButton.onClick.AddListener(() => {

            if(IsDown1 && !IsDown2)
            {
                IsDown2 = true;

                RightText.text = "0";

                if (DirectoryPanel.functionType == FunctionType.Check)
                {
                    fangzhenkaijiPanel.checkEndPanel.ScoreAdd(Score);
                    fangzhenkaijiPanel.tipsGroup.SetCheckText(CheckContent, CheckMsg[4]);
                }

                ToGreen();
            }
        });

        SwitchButton.onClick.AddListener(() => {
            if (IsDown2)
            {
                RightText.text = "0";

                if (DirectoryPanel.functionType == FunctionType.Check)
                {
                    fangzhenkaijiPanel.checkEndPanel.ScoreAdd(Score);
                    fangzhenkaijiPanel.tipsGroup.SetTextColor(fangzhenkaijiPanel.tipsGroup.TextGroup.Count - 1);
                }

                StateImage[8].color = fangzhenkaijiPanel.Green;
                StateImage[9].color = fangzhenkaijiPanel.Green;
                StateImage[11].color = fangzhenkaijiPanel.Green;
            }
        });
    }

    public override void Open()
    {
        base.Open();

        if (DirectoryPanel.functionType == DirectoryEnum.FunctionType.Check)
        {
            fangzhenkaijiPanel.tipsGroup.SetCheckText(CheckContent, CheckMsg[0]);
            fangzhenkaijiPanel.tipsGroup.SetCheckText(CheckContent, CheckMsg[1]);
        }
        Reset();
    }

    public override void Hide()
    {
        base.Hide();
    }

    private void Reset()
    {
        LeftText.text = "24.78";
        RightText.text = "4.19";

        IsDown0 = IsDown1 = IsDown2  = false;

        for (int i = 0; i < StateImage.Length; i++)
        {
            StateImage[i].color = fangzhenkaijiPanel.Red;
        }
    }

    private void ToGreen()
    {
        for (int i = 0; i < StateImage.Length - 4; i++)
        {
            if (i != 2)
            {
                StateImage[i].color = fangzhenkaijiPanel.Green;
            }
        }
    }
}
