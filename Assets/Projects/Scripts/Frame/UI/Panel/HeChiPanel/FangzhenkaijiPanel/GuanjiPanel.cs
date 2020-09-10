using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MTFrame;
using DirectoryEnum;

public class GuanjiPanel : BasePanel
{
    public Image[] StateImage;
    public Button StopButton,LeftButton,RightButton;
    public Text LeftText, RightText;
    public FangzhenkaijiPanel fangzhenkaijiPanel;

    private bool IsDown0, IsDown1, IsDown2;

    public override void InitFind()
    {
        base.InitFind();
        StateImage = FindTool.FindChildNode(transform, "StateImage").GetComponentsInChildren<Image>();
        StopButton = FindTool.FindChildComponent<Button>(transform, "StopButton");
        LeftButton = FindTool.FindChildComponent<Button>(transform, "LeftButton");
        RightButton = FindTool.FindChildComponent<Button>(transform, "RightButton");
        LeftText = FindTool.FindChildComponent<Text>(transform, "TextGroup/left/Button/Text");
        RightText = FindTool.FindChildComponent<Text>(transform, "TextGroup/right/Button/Text");
        fangzhenkaijiPanel = FindTool.FindParentComponent<FangzhenkaijiPanel>(transform, "FangzhenkaijiPanel");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        StopButton.onClick.AddListener(() => {
            IsDown0 = true;

            StateImage[0].color = fangzhenkaijiPanel.Green;

            if (IsDown1 && IsDown2)
            {
                ToGreen();
            }

            if(DirectoryPanel.functionType == FunctionType.Check)
            {
                fangzhenkaijiPanel.checkEndPanel.ScoreAdd(20);
            }

        });

        LeftButton.onClick.AddListener(() => {
            IsDown1 = true;

            LeftText.text = "0";

            if (IsDown1 && IsDown2)
            {
                ToGreen();
            }

            if (DirectoryPanel.functionType == FunctionType.Check)
            {
                fangzhenkaijiPanel.checkEndPanel.ScoreAdd(40);
            }
        });

        RightButton.onClick.AddListener(() => {
            IsDown2 = true;

            RightText.text = "0";

            if (IsDown1 && IsDown0)
            {
                ToGreen();
            }

            if (DirectoryPanel.functionType == FunctionType.Check)
            {
                fangzhenkaijiPanel.checkEndPanel.ScoreAdd(40);
                fangzhenkaijiPanel.checkEndPanel.TipsCanvas_Open();
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
        LeftText.text = "24.78";
        RightText.text = "4.19";

        IsDown0 = IsDown1 = IsDown2 = false;

        for (int i = 0; i < StateImage.Length; i++)
        {
            StateImage[i].color = fangzhenkaijiPanel.Red;
        }
    }

    private void ToGreen()
    {
        for (int i = 0; i < StateImage.Length; i++)
        {
            if (i != 2 && i != 10)
            {
                StateImage[i].color = fangzhenkaijiPanel.Green;
            }
        }
    }
}
