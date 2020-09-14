using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;

public class CheckEndPanel : BasePanel
{
    public Button CloseButton;
    public Text ScoreText, TimeText;
    public CanvasGroup ScoreUI,TipsCanvas;

    //考核Data
    public float ScoreData;
    public int TimeData;
    [HideInInspector]
    public bool IsStart;

    public override void InitFind()
    {
        base.InitFind();
        CloseButton = FindTool.FindChildComponent<Button>(transform, "Panel/bg/Button_Medium");
        ScoreText = FindTool.FindChildComponent<Text>(transform, "ScoreUI/ScoreItem/Score/Text_Medium");
        TimeText = FindTool.FindChildComponent<Text>(transform, "ScoreUI/TimeItem/Time/Text_Medium");
        ScoreUI = FindTool.FindChildComponent<CanvasGroup>(transform, "ScoreUI");
        TipsCanvas = FindTool.FindChildComponent<CanvasGroup>(transform, "Panel");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        CloseButton.onClick.AddListener(() => {
            Hide();
        });
    }

    public override void Open()
    {
        base.Open();
        ScoreUI.Open();
        TipsCanvas.Hide();
        StartCheck();
    }

    public override void Hide()
    {
        base.Hide();
        Reset();
    }

    /// <summary>
    /// 开始考试
    /// </summary>
    public void StartCheck()
    {
        ScoreData = 0;
        TimeData = 60;

        ScoreText.text = 0.ToString();
        TimeText.text = 60.ToString();

        IsStart = true;

        StartCoroutine("Countdown");
    }

    private void EndCheck()
    {
        StopCoroutine("Countdown");
    }

    /// <summary>
    /// 考试结束
    /// </summary>
    public void TipsCanvas_Open()
    {
        IsStart = false;
        TipsCanvas.Open();
        EndCheck();      
    }
   
    /// <summary>
    /// 成绩+
    /// </summary>
    /// <param name="num"></param>
    public void ScoreAdd(float num)
    {
        ScoreData += num;
        ScoreText.text = ScoreData.ToString();
        if(ScoreData >= 100)
        {
            ScoreText.text = "100";
            TipsCanvas_Open();
        }
    }

    private IEnumerator Countdown()
    {
        while (IsStart)
        {
            yield return new WaitForSeconds(1.0f);
            if (IsStart)
            {
                TimeData--;
                if (TimeData < 0)
                {
                    TipsCanvas_Open();
                }
                else
                {
                    TimeText.text = TimeData.ToString();
                }
            }
        }
    }

    private void Reset()
    {
        ScoreUI.Hide();
        TipsCanvas.Hide();
        EndCheck();
        IsStart = false;
    }
}
