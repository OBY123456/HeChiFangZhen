using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using WaitEnum;

public class LoginPanel : BasePanel
{
    public static LoginPanel Instance;

    public Text Name, State;
    public Button Login_Out, Help,Close;
    public CanvasGroup ButtonsCanvas;
    public CanvasGroup HelpPanel;
    public Image StateImage;
    public Sprite[] StateBg;


    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    public override void InitFind()
    {
        base.InitFind();
        Name = FindTool.FindChildComponent<Text>(transform, "NameGroup/Name");
        State = FindTool.FindChildComponent<Text>(transform, "StateGroup/State");
        Login_Out = FindTool.FindChildComponent<Button>(transform, "buttons/Login_Out");
        Help = FindTool.FindChildComponent<Button>(transform, "buttons/Help");
        HelpPanel = FindTool.FindChildComponent<CanvasGroup>(transform, "HelpPanel");
        ButtonsCanvas = FindTool.FindChildComponent<CanvasGroup>(transform, "buttons");
        Close = FindTool.FindChildComponent<Button>(transform, "HelpPanel/bg/CloseButton");
        StateImage = FindTool.FindChildComponent<Image>(transform, "StateGroup/Image");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        Login_Out.onClick.AddListener(() => {

            PanelState.SwitchPanel(PanelName.WaitPanel);
            Reset();
            
        });

        Help.onClick.AddListener(() => {
            HelpPanel_Open();
        });

        Close.onClick.AddListener(() => {
            HelpPanel_Hide();
        });
    }

    private void HelpPanel_Open()
    {
        HelpPanel.alpha = 1;
        HelpPanel.blocksRaycasts = true;
    }

    private void HelpPanel_Hide()
    {
        HelpPanel.alpha = 0;
        HelpPanel.blocksRaycasts = false;
    }

    public void Buttons_Open()
    {
        ButtonsCanvas.alpha = 1;
        ButtonsCanvas.blocksRaycasts = true;
    }

    public void Buttons_Hide()
    {
        ButtonsCanvas.alpha = 0;
        ButtonsCanvas.blocksRaycasts = false;
    }

    public void SetName(string name)
    {
        Name.text = name;
        if(name.Contains("游客"))
        {
            State.text = "数据库未连接";
            State.color = Color.white;
            StateImage.sprite = StateBg[0];
        }
        else
        {
            State.text = "数据库已连接";
            State.color = Color.green;
            StateImage.sprite = StateBg[1];
        }

    }

    private void Reset()
    {
        Name.text = "游客";
        State.text = "数据库未连接";
        State.color = Color.white;

        HelpPanel_Hide();

        Buttons_Hide();

        StateImage.sprite = StateBg[0];
    }

}
