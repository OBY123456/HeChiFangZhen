using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MTFrame;
using DirectoryEnum;

public class KaijiPanel : BasePanel
{
    public Image[] images;
    public Button[] buttons;
    public FangzhenkaijiPanel fangzhenkaijiPanel;

    private float Score = 12.5f;
    private string CheckContent = "考核内容";

    private bool IsDown0, IsDown1, IsDown2, IsDown3, IsDown4, IsDown5,IsDown6;

    private string[] CheckMsg = {
        "设备开机操作考核现在开始",
        "第一题：请点击第一步要操作的按钮。总分12.5分。",
        "第二题：请点击第二步要操作的按钮。总分12.5分。",
        "第三题：请点击第三步要操作的按钮。总分12.5分。",
        "第四题：请点击第四步要操作的按钮。总分12.5分。",
        "第五题：请点击第五步要操作的按钮。总分12.5分。",
        "第六题：请点击第六步要操作的按钮。总分12.5分。",
        "第七题：请点击第七步要操作的按钮。总分12.5分。",
        "第八题：请点击第八步要操作的按钮。总分12.5分。",
    };

    public override void InitFind()
    {
        base.InitFind();
        buttons = FindTool.FindChildNode(transform, "buttons").GetComponentsInChildren<Button>();
        fangzhenkaijiPanel = FindTool.FindParentComponent<FangzhenkaijiPanel>(transform, "FangzhenkaijiPanel");
    }

    public override void InitEvent()
    {
        base.InitEvent();

        //复归PLC
        buttons[0].onClick.AddListener(() => {

            IsDown0 = true;
            images[0].color = fangzhenkaijiPanel.Green;

            if (DirectoryPanel.functionType == FunctionType.Check)
            {
                fangzhenkaijiPanel.checkEndPanel.ScoreAdd(Score);
                fangzhenkaijiPanel.tipsGroup.SetCheckText(CheckContent, CheckMsg[2]);
            }
        });

        //1GS开机令
        buttons[1].onClick.AddListener(() => {

            if(IsDown0 && !IsDown1)
            {
                IsDown1 = true;
                images[1].color = fangzhenkaijiPanel.Green;
                images[2].color = fangzhenkaijiPanel.Green;

                if (DirectoryPanel.functionType == FunctionType.Check)
                {
                    fangzhenkaijiPanel.checkEndPanel.ScoreAdd(Score);
                    fangzhenkaijiPanel.tipsGroup.SetCheckText(CheckContent, CheckMsg[3]);
                }
            }

        });

        //空转到空载
        buttons[2].onClick.AddListener(() => {

            if(IsDown1 && !IsDown2)
            {
                images[3].color = fangzhenkaijiPanel.Green;
                images[4].color = fangzhenkaijiPanel.Green;
                IsDown2 = true;

                if (DirectoryPanel.functionType == FunctionType.Check)
                {
                    fangzhenkaijiPanel.checkEndPanel.ScoreAdd(Score);
                    fangzhenkaijiPanel.tipsGroup.SetCheckText(CheckContent, CheckMsg[4]);
                }
            }

        });

        //1GS并网 
        buttons[3].onClick.AddListener(() => {

            if(IsDown2 && !IsDown3)
            {
                IsDown3 = true;

                if (IsDown4)
                {
                    images[4].color = fangzhenkaijiPanel.Green;

                    if (DirectoryPanel.functionType == FunctionType.Check)
                    {
                        fangzhenkaijiPanel.checkEndPanel.ScoreAdd(Score*2);
                        fangzhenkaijiPanel.tipsGroup.SetCheckText(CheckContent, CheckMsg[5]);
                    }
                }
            }

        });

        //1GS切同期
        buttons[4].onClick.AddListener(() => {

            if(IsDown2 && !IsDown4)
            {
                IsDown4 = true;

                if (IsDown3)
                {
                    images[5].color = fangzhenkaijiPanel.Green;

                    if (DirectoryPanel.functionType == FunctionType.Check)
                    {
                        fangzhenkaijiPanel.checkEndPanel.ScoreAdd(Score*2);
                        fangzhenkaijiPanel.tipsGroup.SetCheckText(CheckContent, CheckMsg[6]);
                    }
                }
            }

        });

        //11GS起励
        buttons[5].onClick.AddListener(() => {

            if(IsDown4 && IsDown3 && !IsDown5)
            {
                IsDown5 = true;

                if (IsDown6)
                {
                    images[6].color = fangzhenkaijiPanel.Green;

                    if (DirectoryPanel.functionType == FunctionType.Check)
                    {
                        fangzhenkaijiPanel.checkEndPanel.ScoreAdd(Score*2);
                        fangzhenkaijiPanel.tipsGroup.SetCheckText(CheckContent, CheckMsg[7]);
                    }
                }
            }

        });

        //11GS并网
        buttons[6].onClick.AddListener(() => {
            if (IsDown4 && IsDown3 && !IsDown6)
            {
                IsDown6 = true;

                if (IsDown5)
                {
                    images[6].color = fangzhenkaijiPanel.Green;

                    if (DirectoryPanel.functionType == FunctionType.Check)
                    {
                        fangzhenkaijiPanel.checkEndPanel.ScoreAdd(Score*2);
                        fangzhenkaijiPanel.tipsGroup.SetCheckText(CheckContent, CheckMsg[8]);
                    }
                }
            }

        });

        buttons[7].onClick.AddListener(() => {

            if(IsDown6)
            {
                images[6].color = fangzhenkaijiPanel.Green;
                images[7].color = fangzhenkaijiPanel.Green;
                images[8].color = fangzhenkaijiPanel.Green;

                if (DirectoryPanel.functionType == FunctionType.Check)
                {
                    fangzhenkaijiPanel.checkEndPanel.ScoreAdd(Score);
                    fangzhenkaijiPanel.tipsGroup.SetTextColor(fangzhenkaijiPanel.tipsGroup.TextGroup.Count - 1);
                }
            }
  
        });
    }

    public override void Open()
    {
        base.Open();
        if (DirectoryPanel.functionType == DirectoryEnum.FunctionType.Check)
        {
            fangzhenkaijiPanel.tipsGroup.SetCheckText("考核内容", CheckMsg[0]);
            fangzhenkaijiPanel.tipsGroup.SetCheckText("考核内容", CheckMsg[1]);
        }
        Reset();
    }

    public override void Hide()
    {
        base.Hide();
    }

    private void Reset()
    {
        IsDown0 = IsDown1 = IsDown2 = IsDown3 = IsDown4 = IsDown5 = IsDown6 = false;

        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = fangzhenkaijiPanel.Red;
        }
    }
}
