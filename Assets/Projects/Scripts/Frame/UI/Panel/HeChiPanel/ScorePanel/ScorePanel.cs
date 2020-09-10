using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;

public class ScorePanel : BasePanel
{

    public StudentPanel studentPanel;
    public TeacherPanel teacherPanel;

    public override void InitFind()
    {
        base.InitFind();
        studentPanel = FindTool.FindChildComponent<StudentPanel>(transform, "StudentPanel");
        teacherPanel = FindTool.FindChildComponent<TeacherPanel>(transform, "TeacherPanel");
    }

    public override void InitEvent()
    {
        base.InitEvent();
    }

    public override void Open()
    {
        base.Open();
        Reset();
        switch (WaitPanel.accountType)
        {
            case WaitEnum.AccountType.Student:
                studentPanel.Open();
                break;
            case WaitEnum.AccountType.Teacher:
                teacherPanel.Open();
                break;
            case WaitEnum.AccountType.Administrator:
                teacherPanel.Open();
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

    private void Reset()
    {
        studentPanel.Hide();
        teacherPanel.Hide();
    }
}
