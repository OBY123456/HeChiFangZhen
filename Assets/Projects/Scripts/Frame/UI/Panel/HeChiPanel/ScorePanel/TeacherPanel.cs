using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using ScoreEnum;

public class TeacherPanel : BasePanel
{
    private List<GameObject> studentTables = new List<GameObject>();
    public ScrollRect scrollRect;
    public Dropdown ChooseClass, ChooseSubjects;
    public InputField InputField;
    public Button SearchButton;

    public ClassType classType;
    public SubjectsType subjectsType;

    protected override void Start()
    {

    }

    public override void InitFind()
    {
        base.InitFind();
        scrollRect = FindTool.FindChildComponent<ScrollRect>(transform, "Scroll View Template");
        ChooseClass = FindTool.FindChildComponent<Dropdown>(transform, "ChooseClass");
        ChooseSubjects = FindTool.FindChildComponent<Dropdown>(transform, "ChooseSubjects");
        InputField = FindTool.FindChildComponent<InputField>(transform, "Search");
        SearchButton = FindTool.FindChildComponent<Button>(transform, "StartButton");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        ChooseClass.onValueChanged.AddListener(Class);
        ChooseSubjects.onValueChanged.AddListener(Subjects);

        SearchButton.onClick.AddListener(() => {
            if(InputField.text == "")
            {
                Seach(classType, subjectsType);
            }
            else
            {
                Seach(classType, subjectsType,InputField.text);
            }
        });
    }

    public void Class(int value)
    {
        if (studentTables.Count <= 0)
            return;

        switch (value)
        {
            case 0:
                classType = ClassType.All;
                break;
            case 1:
                classType = ClassType.水电1班;
                break;
            case 2:
                classType = ClassType.水电2班;
                break;
            case 3:
                classType = ClassType.水电3班;
                break;
            default:
                break;
        }

        Seach(classType, subjectsType);
    }

    public void Subjects(int value)
    {
        if (studentTables.Count <= 0)
            return;

        switch (value)
        {
            case 0:
                subjectsType = SubjectsType.All;
                break;
            case 1:
                subjectsType = SubjectsType.项目一;
                break;
            case 2:
                subjectsType = SubjectsType.项目二;
                break;
            case 3:
                subjectsType = SubjectsType.项目三;
                break;
            default:
                break;
        }

        Seach(classType, subjectsType);
    }

    public override void Open()
    {
        base.Open();
        Reset();
        for (int i = 0; i < 50; i++)
        {
            GameObject obj = ScorePool.Instance.CreatObject(studentTables);
            obj.transform.SetParent(scrollRect.content);
            switch (i)
            {
                case 0:
                    obj.GetComponent<StudentTable>().Name.text = "真真真";
                    break;
                case 1:
                    obj.GetComponent<StudentTable>().Class.text = ClassType.水电2班.ToString();
                    break;
                case 2:
                    obj.GetComponent<StudentTable>().Class.text = ClassType.水电3班.ToString();
                    break;
                case 3:
                    obj.GetComponent<StudentTable>().Subjects.text = SubjectsType.项目三.ToString();
                    break;
                default:
                    break;
            }
            obj.transform.SetAsLastSibling();
        }
        
    }

    public override void Hide()
    {
        base.Hide();
        while (studentTables.Count > 0)
        {
            ScorePool.Instance.DestroyObject(studentTables[0], studentTables);
        }
    }

    private void Seach(ClassType classType,SubjectsType subjectsType,string name = null)
    {
        if(name == null)
        {
            for (int i = 0; i < studentTables.Count; i++)
            {
                if (classType == ClassType.All)
                {
                    if (subjectsType == SubjectsType.All)
                    {
                        studentTables[i].SetActive(true);
                    }
                    else
                    {
                        if (studentTables[i].GetComponent<StudentTable>().Subjects.text.Contains(subjectsType.ToString()))
                        {
                            studentTables[i].SetActive(true);
                        }
                        else
                        {
                            studentTables[i].SetActive(false);
                        }
                    }
                }
                else
                {
                    if (subjectsType == SubjectsType.All)
                    {
                        if (studentTables[i].GetComponent<StudentTable>().Class.text.Contains(classType.ToString()))
                        {
                            studentTables[i].SetActive(true);
                        }
                        else
                        {
                            studentTables[i].SetActive(false);
                        }
                    }
                    else
                    {
                        if (studentTables[i].GetComponent<StudentTable>().Class.text.Contains(classType.ToString()) && studentTables[i].GetComponent<StudentTable>().Subjects.text.Contains(subjectsType.ToString()))
                        {
                            studentTables[i].SetActive(true);
                        }
                        else
                        {
                            studentTables[i].SetActive(false);
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < studentTables.Count; i++)
            {
                if (classType == ClassType.All)
                {
                    if (subjectsType == SubjectsType.All)
                    {
                        if(studentTables[i].GetComponent<StudentTable>().Name.text.Contains(name))
                        {
                            studentTables[i].SetActive(true);
                        }
                        else
                        {
                            studentTables[i].SetActive(false);
                        }
                        
                    }
                    else
                    {
                        if (studentTables[i].GetComponent<StudentTable>().Subjects.text.Contains(subjectsType.ToString()) && studentTables[i].GetComponent<StudentTable>().Name.text.Contains(name))
                        {
                            studentTables[i].SetActive(true);
                        }
                        else
                        {
                            studentTables[i].SetActive(false);
                        }
                    }
                }
                else
                {
                    if (subjectsType == SubjectsType.All)
                    {
                        if (studentTables[i].GetComponent<StudentTable>().Class.text.Contains(classType.ToString()) && studentTables[i].GetComponent<StudentTable>().Name.text.Contains(name))
                        {
                            studentTables[i].SetActive(true);
                        }
                        else
                        {
                            studentTables[i].SetActive(false);
                        }
                    }
                    else
                    {
                        if (studentTables[i].GetComponent<StudentTable>().Class.text.Contains(classType.ToString()) && studentTables[i].GetComponent<StudentTable>().Subjects.text.Contains(subjectsType.ToString()) && studentTables[i].GetComponent<StudentTable>().Name.text.Contains(name))
                        {
                            studentTables[i].SetActive(true);
                        }
                        else
                        {
                            studentTables[i].SetActive(false);
                        }
                    }
                }
            }
        }
    }

    private void Reset()
    {
        InputField.text = "";
        ChooseClass.value = 0;
        ChooseSubjects.value = 0;
        subjectsType = SubjectsType.All;
        classType = ClassType.All;
        Seach(classType, subjectsType);
    }
}
