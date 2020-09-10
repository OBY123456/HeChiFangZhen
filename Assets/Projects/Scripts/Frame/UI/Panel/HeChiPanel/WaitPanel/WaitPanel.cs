using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using MTFrame.MTEvent;
using System;
using WaitEnum;

public class WaitPanel : BasePanel
{
    public Button[] buttons;
    public InputField Login_Id, Login_Password;
    public Button LoginButton;

    public Button CloseButton;
    public Text TipsText;
    public CanvasGroup CloseCanvasGroup;

    public Sprite[] ButtonBg;

    public static AccountType accountType;

    public int Account = 1234567899;

    protected override void Start()
    {
        base.Start();
        Reset();
    }

    public override void Open()
    {
        base.Open();
        LoginPanel.Instance.Buttons_Hide();
    }

    public override void Hide()
    {
        base.Hide();
        LoginPanel.Instance.Buttons_Open();
    }

    public override void InitFind()
    {
        base.InitFind();
        buttons = FindTool.FindChildNode(transform,"loginGroup/ButtonGroup").GetComponentsInChildren<Button>();
        Login_Id = FindTool.FindChildComponent<InputField>(transform, "loginGroup/InputFieldGroup/bg1/InputField_Regular_ID");
        Login_Password = FindTool.FindChildComponent<InputField>(transform, "loginGroup/InputFieldGroup/bg2/InputField_Regular_Password");
        LoginButton = FindTool.FindChildComponent<Button>(transform, "loginGroup/Button_Regular");
        TipsText = FindTool.FindChildComponent<Text>(transform, "Tips/Text_Medium_content");
        CloseButton = FindTool.FindChildComponent<Button>(transform, "Tips/Button_Medium_Close");
        CloseCanvasGroup = FindTool.FindChildComponent<CanvasGroup>(transform, "Tips");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        buttons[0].onClick.AddListener(() => {
            accountType = AccountType.Tourists;
            Login_Id.text = Account.ToString();
            Login_Password.text = "qq123456";

            ButtonOnclick(0);
        });

        buttons[1].onClick.AddListener(() => {
            accountType = AccountType.Student;
            ResetInput();
            ButtonOnclick(1);
        });

        buttons[2].onClick.AddListener(() => {
            accountType = AccountType.Teacher;
            ResetInput();
            ButtonOnclick(2);
        });

        buttons[3].onClick.AddListener(() => {
            accountType = AccountType.Administrator;
            ResetInput();
            ButtonOnclick(3);
        });

        LoginButton.onClick.AddListener(() => {
            switch (accountType)
            {
                case AccountType.Tourists:
                    Login_Tourists();
                    break;
                case AccountType.Student:
                    Login_Student();
                    break;
                case AccountType.Teacher:
                    Login_Teacher();
                    break;
                case AccountType.Administrator:
                    Login_Administrator();
                    break;
                default:
                    break;
            }
        });

        CloseButton.onClick.AddListener(() => {
            CanvasGroup_Close();
        });
    }

    private void Login_Tourists()
    {
        PanelState.SwitchPanel(PanelName.DirectoryPanel);
        LoginPanel.Instance.SetName("游客");
    }

    private void Login_Student()
    {
        if (Login_Id.text == Account.ToString() && Login_Password.text == "qq123456")
        {
            PanelState.SwitchPanel(PanelName.DirectoryPanel);
            LoginPanel.Instance.SetName("王小明");
        }
        else
        {
            TipsText.text = "账号或密码错误！";
            CanvasGroup_Open();
        }
    }

    private void Login_Teacher()
    {
        if (Login_Id.text == Account.ToString() && Login_Password.text == "qq123456")
        {
            PanelState.SwitchPanel(PanelName.DirectoryPanel);
            LoginPanel.Instance.SetName("王小明");
        }
        else
        {
            TipsText.text = "账号或密码错误！";
            CanvasGroup_Open();
        }
    }

    private void Login_Administrator()
    {
        if (Login_Id.text == Account.ToString() && Login_Password.text == "qq123456")
        {
            PanelState.SwitchPanel(PanelName.DirectoryPanel);
            LoginPanel.Instance.SetName("王小明");
        }
        else
        {
            TipsText.text = "账号或密码错误！";
            CanvasGroup_Open();
        }
    }

    private void CanvasGroup_Close()
    {
        CloseCanvasGroup.alpha = 0;
        CloseCanvasGroup.blocksRaycasts = false;
    }

    private void CanvasGroup_Open()
    {
        CloseCanvasGroup.alpha = 1;
        CloseCanvasGroup.blocksRaycasts = true;
    }

    public void Reset()
    {
        accountType = AccountType.Tourists;
        Login_Id.text = Account.ToString();
        Login_Password.text = "qq123456";
        CanvasGroup_Close();
        TipsText.text = "";
        ButtonOnclick(0);
    }

    private void ButtonOnclick(int num)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if(i == num)
            {
                buttons[i].GetComponent<Image>().sprite = ButtonBg[1];
            }
            else
            {
                buttons[i].GetComponent<Image>().sprite = ButtonBg[0];
            }
        }
    }

    private void ResetInput()
    {
        Login_Id.text = "";
        Login_Password.text = "";
        Login_Id.ActivateInputField();
    }
}
