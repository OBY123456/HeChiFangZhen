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
    public List<GameObject> TextGroup = new List<GameObject>();

    public override void InitFind()
    {
        base.InitFind();
        scrollRect = FindTool.FindChildComponent<ScrollRect>(transform, "TipsText");
        TiltleText = FindTool.FindChildComponent<Text>(transform, "Text_Regular");
    }

    private void CreatText(string str)
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
    private void CheckCreatText(string str)
    {
        CreatText(str);
        if (TextGroup.Count > 2)
        {
            TextGroup[TextGroup.Count-2].GetComponent<Text>().color = Color.red;
        }  
    }

    public void SetTextColor(int num)
    {
        TextGroup[num].GetComponent<Text>().color = Color.red;
    }

    private void DisplayText(string str)
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
            while(TextGroup.Count > 0)
            {
                TipsTextPool.Instence.DestroyObject(TextGroup[0], TextGroup);
            }
            TextGroup.Clear();
            TextGroup = null;
        }
    }

    /// <summary>
    /// 修改文本内容
    /// </summary>
    /// <param name="Tiltle"></param>
    /// <param name="content"></param>
    public void SetText(string Tiltle,string content)
    {
        TiltleText.text = Tiltle;
        DisplayText(content);
    }

    public void SetCheckText(string Tiltle, string content)
    {
        TiltleText.text = Tiltle;
        CheckCreatText(content);
    }
}
