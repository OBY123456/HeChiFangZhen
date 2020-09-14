using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using ScoreEnum;
using MTFrame.MTEvent;
using System;

public class AdminPanel : BasePanel
{
    //总是教师资源在0，学生资源在1
    public Sprite[] bgIma,ChangeIma,NewIma;
    public Image bg;
    public CanvasGroup TeacherCanvas, StudentCanvas;
    public Button[] SwitchButton;
    public Button NewButton;
    public CanvasGroup[] Tips;
    public ScrollRect TeacherScroll, StudentScroll;

    //修改框UI
    public InputField Change_Number, Change_Name, Change_Academy, Change_Class;
    public Button Change_yes_Button, Change_no_Button;
    public Image Change_bg;

    //新建框UI
    public InputField New_Number, New_Name, New_Academy, New_Class;
    public Button New_yes_Button, New_no_Button;
    public Image New_bg;

    //重置框UI
    public Button Reset_yes_Button, Reset_no_Button;

    //删除框UI
    public Button Delete_yes_Button, Delete_no_Button;

    private TableType tableType;
    private List<GameObject> TeacherList = new List<GameObject>();
    private List<GameObject> StudentList = new List<GameObject>();

    /// <summary>
    /// 当前选中的信息在链表中的索引
    /// </summary>
    public int Index;

    public override void InitFind()
    {
        base.InitFind();
        TeacherCanvas = FindTool.FindChildComponent<CanvasGroup>(transform, "Scroll View Template Teacher");
        StudentCanvas = FindTool.FindChildComponent<CanvasGroup>(transform, "Scroll View Template Student");
        SwitchButton = FindTool.FindChildNode(transform, "SwitchButtons").GetComponentsInChildren<Button>();
        NewButton = FindTool.FindChildComponent<Button>(transform, "NewButton");
        Tips = FindTool.FindChildNode(transform, "tips").GetComponentsInChildren<CanvasGroup>();
        bg = FindTool.FindChildComponent<Image>(transform, "bg2");

        TeacherScroll = FindTool.FindChildComponent<ScrollRect>(transform, "Scroll View Template Teacher");
        StudentScroll = FindTool.FindChildComponent<ScrollRect>(transform, "Scroll View Template Student");

        Change_Number = FindTool.FindChildComponent<InputField>(transform, "tips/change/Number");
        Change_Name = FindTool.FindChildComponent<InputField>(transform, "tips/change/Name");
        Change_Academy = FindTool.FindChildComponent<InputField>(transform, "tips/change/Academy");
        Change_Class = FindTool.FindChildComponent<InputField>(transform, "tips/change/Class");
        Change_yes_Button = FindTool.FindChildComponent<Button>(transform, "tips/change/baocun");
        Change_no_Button = FindTool.FindChildComponent<Button>(transform, "tips/change/quxiao");
        Change_bg = FindTool.FindChildComponent<Image>(transform, "tips/change");

        New_Number = FindTool.FindChildComponent<InputField>(transform, "tips/new/Number");
        New_Name = FindTool.FindChildComponent<InputField>(transform, "tips/new/Name");
        New_Academy = FindTool.FindChildComponent<InputField>(transform, "tips/new/Academy");
        New_Class = FindTool.FindChildComponent<InputField>(transform, "tips/new/Class");
        New_yes_Button = FindTool.FindChildComponent<Button>(transform, "tips/new/queding");
        New_no_Button = FindTool.FindChildComponent<Button>(transform, "tips/new/quxiao");
        New_bg = FindTool.FindChildComponent<Image>(transform, "tips/new");

        Reset_yes_Button = FindTool.FindChildComponent<Button>(transform, "tips/reset/yes");
        Reset_no_Button = FindTool.FindChildComponent<Button>(transform, "tips/reset/no");

        Delete_yes_Button = FindTool.FindChildComponent<Button>(transform, "tips/delete/yes");
        Delete_no_Button = FindTool.FindChildComponent<Button>(transform, "tips/delete/no");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        SwitchButton[0].onClick.AddListener(() => {
            tableType = TableType.Teacher;

            TeacherCanvas_Open();
            StudentCanvas_Hide();

            bg.sprite = bgIma[0];

            Change_bg.sprite = ChangeIma[0];
            Change_Number.placeholder.GetComponent<Text>().text = "请输入工号...";

            New_bg.sprite = ChangeIma[0];
            New_Number.placeholder.GetComponent<Text>().text = "请输入工号...";
        });

        SwitchButton[1].onClick.AddListener(() => {
            tableType = TableType.Student;

            StudentCanvas_Open();
            TeacherCanvas_Hide();

            bg.sprite = bgIma[1];

            Change_bg.sprite = ChangeIma[1];
            Change_Number.placeholder.GetComponent<Text>().text = "请输入学号...";

            New_bg.sprite = ChangeIma[1];
            New_Number.placeholder.GetComponent<Text>().text = "请输入学号...";
        });

        NewButton.onClick.AddListener(() => {
            New_Academy.text = New_Name.text = New_Class.text = New_Number.text = "";
            TipsCanvase_Open(1);
        });

        Change_yes_Button.onClick.AddListener(() => {
            if (Change_Number.text == "" || Change_Class.text == "" || Change_Academy.text == "" || Change_Name.text == "")
            {

            }
            else
            {
                ChangeListValue();
                TipsCanvase_Hide();
            }
        });

        Change_no_Button.onClick.AddListener(() => {
            TipsCanvase_Hide();
        });

        New_yes_Button.onClick.AddListener(() => {
            if(New_Number.text =="" || New_Class.text=="" || New_Academy.text=="" || New_Name.text=="")
            {

            }
            else
            {
                GameObject obj;
                if (tableType == TableType.Teacher)
                {
                    obj = AdminPool.Instance.CreatObject(TeacherList);
                    obj.transform.SetParent(TeacherScroll.content);
                    obj.transform.SetAsLastSibling();
                }
                else
                {
                    obj = AdminPool.Instance.CreatObject(StudentList);
                    obj.transform.SetParent(StudentScroll.content);
                    obj.transform.SetAsLastSibling();
                }

                obj.GetComponent<AdminStdTable>().Number.text = New_Number.text;
                obj.GetComponent<AdminStdTable>().Academy.text = New_Academy.text;
                obj.GetComponent<AdminStdTable>().Name.text = New_Name.text;
                obj.GetComponent<AdminStdTable>().Class.text = New_Class.text;
                obj.GetComponent<AdminStdTable>().adminPanel = this;

                switch (tableType)
                {
                    case TableType.Student:
                        StudentList.Add(obj);
                        break;
                    case TableType.Teacher:
                        TeacherList.Add(obj);
                        break;
                    default:
                        break;
                }

                obj = null;
                TipsCanvase_Hide();
            }

            
        });

        New_no_Button.onClick.AddListener(() => {
            TipsCanvase_Hide();
           
        });

        Reset_yes_Button.onClick.AddListener(() => {
            TipsCanvase_Hide();
        });

        Reset_no_Button.onClick.AddListener(() => {

            TipsCanvase_Hide();
        });

        Delete_yes_Button.onClick.AddListener(() => {

            DeleteButton();
            TipsCanvase_Hide();
        });

        Delete_no_Button.onClick.AddListener(() => {

            TipsCanvase_Hide();
        });
    }

    protected override void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject obj = obj = AdminPool.Instance.CreatObject(TeacherList);
            obj.GetComponent<AdminStdTable>().adminPanel = this;
            obj.transform.SetParent(TeacherScroll.content);
        }

        for (int i = 0; i < 10; i++)
        {
            GameObject obj = obj = AdminPool.Instance.CreatObject(StudentList);
            obj.GetComponent<AdminStdTable>().adminPanel = this;
            obj.transform.SetParent(StudentScroll.content);
        }
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

    private void TeacherCanvas_Open()
    {
        TeacherCanvas.Open();
    }

    private void TeacherCanvas_Hide()
    {
        TeacherCanvas.Hide();
    }

    private void StudentCanvas_Open()
    {
        StudentCanvas.Open();
    }

    private void StudentCanvas_Hide()
    {
        StudentCanvas.Hide();
    }

    private void TipsCanvase_Open(int num)
    {
        if(num < Tips.Length && num >= 0)
        {
            for (int i = 0; i < Tips.Length; i++)
            {
                Tips[i].Hide();
            }

            Tips[num].Open();
        }
    }

    private void TipsCanvase_Hide()
    {
        for (int i = 0; i < Tips.Length; i++)
        {
            Tips[i].Hide();
        }
        Index = -1;
    }

    private void Reset()
    {
        tableType = TableType.Teacher;

        TeacherCanvas_Open();
        StudentCanvas_Hide();

        bg.sprite = bgIma[0];

        Change_bg.sprite = ChangeIma[0];
        Change_Number.placeholder.GetComponent<Text>().text = "请输入工号...";

        New_bg.sprite = ChangeIma[0];
        New_Number.placeholder.GetComponent<Text>().text = "请输入工号...";

        TipsCanvase_Hide();
        New_Academy.text = New_Name.text = New_Class.text = New_Number.text = "";
        Change_Academy.text = Change_Name.text = Change_Class.text = Change_Number.text = "";

        Index = -1;

        while(TeacherList.Count > 0)
        {
            AdminPool.Instance.DestroyObject(TeacherList[0], TeacherList);
        }

        while (TeacherList.Count > 0)
        {
            AdminPool.Instance.DestroyObject(StudentList[0], StudentList);
        }
    }

    /// <summary>
    /// 修改页面确定键方法
    /// </summary>
    private void ChangeListValue()
    {
        switch (tableType)
        {
            case TableType.Student:
                StudentList[Index].GetComponent<AdminStdTable>().Number.text = Change_Number.text;
                StudentList[Index].GetComponent<AdminStdTable>().Academy.text = Change_Academy.text;
                StudentList[Index].GetComponent<AdminStdTable>().Name.text = Change_Name.text;
                StudentList[Index].GetComponent<AdminStdTable>().Class.text = Change_Class.text;

                break;
            case TableType.Teacher:
                TeacherList[Index].GetComponent<AdminStdTable>().Number.text = Change_Number.text;
                TeacherList[Index].GetComponent<AdminStdTable>().Academy.text = Change_Academy.text;
                TeacherList[Index].GetComponent<AdminStdTable>().Name.text = Change_Name.text;
                TeacherList[Index].GetComponent<AdminStdTable>().Class.text = Change_Class.text;

                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 删除页面确定键方法
    /// </summary>
    private void DeleteButton()
    {
        switch (tableType)
        {
            case TableType.Student:
                AdminPool.Instance.DestroyObject(StudentList[Index], StudentList);
                break;
            case TableType.Teacher:
                AdminPool.Instance.DestroyObject(TeacherList[Index], TeacherList);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 调用此方法将数据现在是change面板上
    /// </summary>
    /// <param name="obj"></param>
    public void DisPlayData(GameObject obj)
    {
        Change_Number.text = obj.GetComponent<AdminStdTable>().Number.text;
        Change_Name.text = obj.GetComponent<AdminStdTable>().Name.text;
        Change_Academy.text = obj.GetComponent<AdminStdTable>().Academy.text;
        Change_Class.text = obj.GetComponent<AdminStdTable>().Class.text;

        TipsCanvase_Open(0);

        switch (tableType)
        {
            case TableType.Student:
                Index = StudentList.IndexOf(obj);
                break;
            case TableType.Teacher:
                Index = TeacherList.IndexOf(obj);
                break;
            default:
                break;
        }
        
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    /// <param name="obj"></param>
    public void DeleteData(GameObject obj)
    {
        TipsCanvase_Open(3);
        switch (tableType)
        {
            case TableType.Student:
                Index = StudentList.IndexOf(obj);
                break;
            case TableType.Teacher:
                Index = TeacherList.IndexOf(obj);
                break;
            default:
                break;
        }
    }

    public void ResetData(GameObject obj)
    {
        TipsCanvase_Open(2);

    }
}
