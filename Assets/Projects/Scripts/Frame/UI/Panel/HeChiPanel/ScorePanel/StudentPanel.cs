using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;

public class StudentPanel : BasePanel
{
    public GameObject StudentPrefab;
    private List<GameObject> studentTables = new List<GameObject>();
    public ScrollRect scrollView;

    protected override void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject obj = Instantiate(StudentPrefab, scrollView.content);
            studentTables.Add(obj);
        }
    }

    public override void InitFind()
    {
        base.InitFind();
        scrollView = FindTool.FindChildComponent<ScrollRect>(transform, "Scroll View Template");
    }

    public override void InitEvent()
    {
        base.InitEvent();
    }

    public override void Open()
    {
        base.Open();

    }

    public override void Hide()
    {
        base.Hide();
    }
}
