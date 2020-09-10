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

    private bool IsDown0, IsDown1, IsDown2, IsDown3, IsDown4, IsDown5;

    public override void InitFind()
    {
        base.InitFind();
        buttons = FindTool.FindChildNode(transform, "buttons").GetComponentsInChildren<Button>();
        fangzhenkaijiPanel = FindTool.FindParentComponent<FangzhenkaijiPanel>(transform, "FangzhenkaijiPanel");
    }

    public override void InitEvent()
    {
        base.InitEvent();

        //1GS开机令
        buttons[0].onClick.AddListener(() => {

            IsDown0 = true;
            images[0].color = fangzhenkaijiPanel.Green;
            images[1].color = fangzhenkaijiPanel.Green;

            if(DirectoryPanel.functionType == FunctionType.Check)
            {
                fangzhenkaijiPanel.checkEndPanel.ScoreAdd(15);
            }
        });

        //空转到空载
        buttons[1].onClick.AddListener(() => {

            if(IsDown0)
            {
                images[2].color = fangzhenkaijiPanel.Green;
                images[3].color = fangzhenkaijiPanel.Green;
                IsDown1 = true;

                if (DirectoryPanel.functionType == FunctionType.Check)
                {
                    fangzhenkaijiPanel.checkEndPanel.ScoreAdd(15);
                }
            }

        });

        //1GS并网 
        buttons[2].onClick.AddListener(() => {

            if(IsDown1)
            {
                IsDown2 = true;

                if (IsDown3)
                {
                    images[4].color = fangzhenkaijiPanel.Green;

                    if (DirectoryPanel.functionType == FunctionType.Check)
                    {
                        fangzhenkaijiPanel.checkEndPanel.ScoreAdd(15);
                    }
                }
            }

        });

        //1GS切同期
        buttons[3].onClick.AddListener(() => {

            if(IsDown1)
            {
                IsDown3 = true;

                if (IsDown2)
                {
                    images[4].color = fangzhenkaijiPanel.Green;

                    if (DirectoryPanel.functionType == FunctionType.Check)
                    {
                        fangzhenkaijiPanel.checkEndPanel.ScoreAdd(15);
                    }
                }
            }

        });

        //11GS起励
        buttons[4].onClick.AddListener(() => {

            if(IsDown2 && IsDown3)
            {
                IsDown4 = true;

                if (IsDown5)
                {
                    images[5].color = fangzhenkaijiPanel.Green;

                    if (DirectoryPanel.functionType == FunctionType.Check)
                    {
                        fangzhenkaijiPanel.checkEndPanel.ScoreAdd(15);
                    }
                }
            }

        });

        //11GS并网
        buttons[5].onClick.AddListener(() => {
            if (IsDown2 && IsDown3)
            {
                IsDown5 = true;

                if (IsDown4)
                {
                    images[5].color = fangzhenkaijiPanel.Green;

                    if (DirectoryPanel.functionType == FunctionType.Check)
                    {
                        fangzhenkaijiPanel.checkEndPanel.ScoreAdd(15);
                    }
                }
            }

        });

        buttons[6].onClick.AddListener(() => {

            if(IsDown4 && IsDown5)
            {
                images[6].color = fangzhenkaijiPanel.Green;
                images[7].color = fangzhenkaijiPanel.Green;

                if (DirectoryPanel.functionType == FunctionType.Check)
                {
                    fangzhenkaijiPanel.checkEndPanel.ScoreAdd(10);
                    fangzhenkaijiPanel.checkEndPanel.TipsCanvas_Open();
                }
            }
  
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
        IsDown0 = IsDown1 = IsDown2 = IsDown3 = IsDown4 = IsDown5 = false;

        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = fangzhenkaijiPanel.Red;
        }
    }
}
