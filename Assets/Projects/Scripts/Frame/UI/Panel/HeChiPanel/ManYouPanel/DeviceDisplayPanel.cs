using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MTFrame;

public class DeviceDisplayPanel : BasePanel
{
    public Sprite[] Images;
    public Image image;
    public CanvasGroup buttons;
    public Text text,tiltleText;
    public Button LeftButton, RightButton,CloseButton;
    private int Index;

    public override void InitFind()
    {
        base.InitFind();
        image = FindTool.FindChildComponent<Image>(transform, "Image");
        buttons = FindTool.FindChildComponent<CanvasGroup>(transform, "buttons");
        LeftButton = FindTool.FindChildComponent<Button>(transform, "buttons/LeftButton");
        RightButton = FindTool.FindChildComponent<Button>(transform, "buttons/RightButton");
        text = FindTool.FindChildComponent<Text>(transform, "Content/Text_Medium");
        CloseButton = FindTool.FindChildComponent<Button>(transform, "CloseButton");
        tiltleText = FindTool.FindChildComponent<Text>(transform, "TiltleText");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        LeftButton.onClick.AddListener(() => {
            Index--;
            if(Index <= 0)
            {
                Index = 0;
            }
            image.sprite = Images[Index];
        });

        RightButton.onClick.AddListener(() => {
            Index++;
            if (Index >= Images.Length)
            {
                Index = Images.Length - 1;
            }
            image.sprite = Images[Index];
        });

        CloseButton.onClick.AddListener(() => {
            Hide();
        });
    }

    public override void Open()
    {
        base.Open();

        Index = 0;

        if ( Images!=null && Images.Length > 1)
        {
            buttons.Open();
        }
        else
        {
            buttons.Hide();
        }
    }

    public void SetMassage(Sprite[] sprites,string TiltleMsg,string ContentMsg)
    {
        Images = sprites;
        image.sprite = Images[0];
        tiltleText.text = TiltleMsg;
        text.text = ContentMsg;
    }
}
