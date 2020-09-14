using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;

public class StudentPanel : BasePanel
{
    private List<GameObject> studentTables = new List<GameObject>();
    public ScrollRect scrollView;

    protected override void Start()
    {

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
        for (int i = 0; i < 50; i++)
        {
            GameObject obj = ScorePool.Instance.CreatObject(studentTables);
            obj.transform.SetParent(scrollView.content);
            obj.transform.SetAsLastSibling();
        }
    }

    public override void Hide()
    {
        base.Hide();
        while(studentTables.Count > 0)
        {
            ScorePool.Instance.DestroyObject(studentTables[0], studentTables);
        }
    }
}
