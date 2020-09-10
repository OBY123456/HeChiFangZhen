using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using DirectoryEnum;

public class DirectoryPanel : BasePanel
{
    public Button[] Tourists;
    public Button[] Student;
    public Button[] Teacher;
    public Button[] Administrator;

    public CanvasGroup[] ButtonCanvasGroup;

    public static FunctionType functionType;

    public override void InitFind()
    {
        base.InitFind();
        Tourists = FindTool.FindChildNode(transform, "ButtonGroup/Buttons_Tourists").GetComponentsInChildren<Button>();
        Student = FindTool.FindChildNode(transform, "ButtonGroup/Buttons_Student").GetComponentsInChildren<Button>();
        Teacher = FindTool.FindChildNode(transform, "ButtonGroup/Buttons_Teacher").GetComponentsInChildren<Button>();
        Administrator = FindTool.FindChildNode(transform, "ButtonGroup/Buttons_Administrator").GetComponentsInChildren<Button>();

        ButtonCanvasGroup = FindTool.FindChildNode(transform, "ButtonGroup").GetComponentsInChildren<CanvasGroup>();
    }

    public override void InitEvent()
    {
        base.InitEvent();
        Tourists[0].onClick.AddListener(()=>{
            Enter_TrainingPanel();
        });

        Student[0].onClick.AddListener(() => {
            Enter_TrainingPanel();
        });

        Student[1].onClick.AddListener(() => {
            Enter_CheckPanel();
        });

        Student[2].onClick.AddListener(() => {
            Enter_ScorePanel();
        });

        Teacher[0].onClick.AddListener(() => {
            Enter_TrainingPanel();
        });

        Teacher[1].onClick.AddListener(() => {
            Enter_ScorePanel();
        });

        Administrator[0].onClick.AddListener(() => {
            Enter_TrainingPanel();
        });

        Administrator[1].onClick.AddListener(() => {
            Enter_ChangeAccount();
        });

        Administrator[2].onClick.AddListener(() => {
            Enter_ScorePanel();
        });
    }

    public override void Open()
    {
        base.Open();
        switch (WaitPanel.accountType)
        {
            case WaitEnum.AccountType.Tourists:
                CanvasGroupsOpen(0);
                break;
            case WaitEnum.AccountType.Student:
                CanvasGroupsOpen(1);
                break;
            case WaitEnum.AccountType.Teacher:
                CanvasGroupsOpen(2);
                break;
            case WaitEnum.AccountType.Administrator:
                CanvasGroupsOpen(3);
                break;
            default:
                break;
        }
    }

    public override void Hide()
    {
        base.Hide();
        Reset();
    }

    private void Enter_TrainingPanel()
    {
        functionType = FunctionType.Training;
        PanelState.SwitchPanel(PanelName.TrainingPanel);
    }

    private void Enter_CheckPanel()
    {
        functionType = FunctionType.Check;
        PanelState.SwitchPanel(PanelName.CheckPanel);
    }

    private void Enter_ScorePanel()
    {
        functionType = FunctionType.Score;
        PanelState.SwitchPanel(PanelName.ScorePanel);
    }

    private void Enter_ChangeAccount()
    {
        functionType = FunctionType.ChangeAccount;
        PanelState.SwitchPanel(PanelName.AdminPanel);
    }

    private void CanvasGroupsOpen(int number)
    {
        ButtonCanvasGroup[number].alpha = 1;
        ButtonCanvasGroup[number].blocksRaycasts = true;
    }

    private void Reset()
    {
        for (int i = 0; i < ButtonCanvasGroup.Length; i++)
        {
            ButtonCanvasGroup[i].alpha = 0;
            ButtonCanvasGroup[i].blocksRaycasts = false;
        }
    }
}
