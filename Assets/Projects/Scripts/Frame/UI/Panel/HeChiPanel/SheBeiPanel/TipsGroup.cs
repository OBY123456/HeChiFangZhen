using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using OBYPool;
using System.Text;

public class TipsGroup : BasePanel
{
    public ScrollRect scrollRect;
    public Text TiltleText;

    public GameObject TextPrefabs;
    public List<GameObject> TextGroup = new List<GameObject>();

    public override void InitFind()
    {
        base.InitFind();
        scrollRect = FindTool.FindChildComponent<ScrollRect>(transform, "TipsText");
        TiltleText = FindTool.FindChildComponent<Text>(transform, "Text_Regular");
    }

    public void CreatText(string str)
    {
        GameObject obj = TipsTextPool.Instence.CreatObject(TextGroup);
        obj.GetComponent<Text>().color = Color.white;
        obj.GetComponent<Text>().text = str;
        obj.transform.SetParent(scrollRect.content);
    }

    /// <summary>
    /// 考核出题用
    /// </summary>
    /// <param name="str"></param>
    public void CheckCreatText(string str)
    {

    }

    /// <summary>
    /// 修改文本内容
    /// </summary>
    /// <param name="str"></param>
    public void DisplayText(string str)
    {
        if(TextGroup.Count > 0)
        {
            TextGroup[0].GetComponent<Text>().text = str;
        }
        else
        {
            CreatText(str);
        }
    }

    public override void Open()
    {
        TextGroup = new List<GameObject>();
    }

    public override void Hide()
    {
        Reset();
    }

    public void Reset()
    {
        if(TextGroup.Count > 0)
        {
            for (int i = 0; i < TextGroup.Count; i++)
            {
                TipsTextPool.Instence.DestroyObject(TextGroup[i], TextGroup);
            }
            TextGroup.Clear();
            TextGroup = null;
        }
    }
}
