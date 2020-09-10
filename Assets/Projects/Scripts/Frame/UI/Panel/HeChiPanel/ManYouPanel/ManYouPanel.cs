using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using MTFrame.MTEvent;
using System;
using ManYouEnum;
using DirectoryEnum;

public class ManYouPanel : BasePanel
{
    public Button[] MenuButtons;
    public CanvasGroup Caozuofangshi, transfer, Minimap,ButtonsCanvas, DropdownCanvas;
    //public Button CIS, Chuxianzhuangzhi, Fadianji, Lichixitong,Jizutiaosuju, Bianyaqi, Shuilunji;
    public Text TiltleText, ContentText;
    public Button SwitchButton;
    public CanvasGroup SwitchButtonCanvasGroup;
    public Image Map,Tips;
    public Button[] dropdown;
    public DeviceDisplayPanel deviceDisplayPanel;
    public Button CloseButton;
    public ScrollRect scrollRect;
    public CheckEndPanel checkPanel;
    public Button[] TransportButtons;
    public Sprite[] MapBg;
    public Sprite[] TipsBG;
    public DevicesType CurrentDevices;

    public override void InitFind()
    {
        base.InitFind();
        MenuButtons = FindTool.FindChildNode(transform, "MenuButtons").GetComponentsInChildren<Button>();
        Caozuofangshi = FindTool.FindChildComponent<CanvasGroup>(transform, "caozuofangfa");
        transfer = FindTool.FindChildComponent<CanvasGroup>(transform, "TransportGroup");
        Minimap = FindTool.FindChildComponent<CanvasGroup>(transform, "MiniMap");

        TransportButtons = FindTool.FindChildNode(transform, "TransportGroup/Scroll View/Viewport/Content").GetComponentsInChildren<Button>();

        TiltleText = FindTool.FindChildComponent<Text>(transform, "caozuofangfa/Tiltle");
        ContentText = FindTool.FindChildComponent<Text>(transform, "caozuofangfa/Content/Text_Medium");

        SwitchButton = FindTool.FindChildComponent<Button>(transform, "SwitchButton");
        SwitchButtonCanvasGroup = SwitchButton.gameObject.GetComponent<CanvasGroup>();

        Map = FindTool.FindChildComponent<Image>(transform, "MiniMap/bg");
        ButtonsCanvas = FindTool.FindChildComponent<CanvasGroup>(transform, "MenuButtons");

        deviceDisplayPanel = FindTool.FindChildComponent<DeviceDisplayPanel>(transform, "MassageUI/DeviceDisplayPanel");
        DropdownCanvas = FindTool.FindChildComponent<CanvasGroup>(transform, "MassageUI/menu");

        CloseButton = FindTool.FindChildComponent<Button>(transform, "MassageUI/menu/CloseButton");

        scrollRect = FindTool.FindChildComponent<ScrollRect>(transform, "caozuofangfa/Content");

        checkPanel = FindTool.FindChildComponent<CheckEndPanel>(transform, "CheckEndPanel");

        dropdown = FindTool.FindChildNode(transform, "MassageUI/menu/ButtonGroup").GetComponentsInChildren<Button>();

        Tips = FindTool.FindChildComponent<Image>(transform, "caozuofangfa");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        MenuButtons[0].onClick.AddListener(() => {
            if(Caozuofangshi.alpha == 1)
            {
                Caozuofangshi.alpha = 0;
            }
            else
            {
                Caozuofangshi.alpha = 1;
            }
        });

        MenuButtons[1].onClick.AddListener(() => {
            if (Minimap.alpha == 1)
            {
                Minimap.alpha = 0;
            }
            else
            {
                Minimap.alpha = 1;
            }
        });

        MenuButtons[2].onClick.AddListener(() => {
            if (transfer.alpha == 1)
            {
                transfer.alpha = 0;
                transfer.blocksRaycasts = false;
            }
            else
            {
                transfer.alpha = 1;
                transfer.blocksRaycasts = true;
            }
        });

        SwitchButton.onClick.AddListener(() => {
            Shiwaimanyou();
        });

        CloseButton.onClick.AddListener(() => {
            DropdownCanvas.Hide();
        });

        checkPanel.CloseButton.onClick.AddListener(() => {
            PanelState.SwitchPanel(PanelName.CheckPanel);
        });

        for (int i = 0; i < TransportButtons.Length; i++)
        {
            SetButtonOnClick(TransportButtons[i], i);
        }

        for (int i = 0; i < dropdown.Length; i++)
        {
            SetDropDownButton(dropdown[i], i);
        }

        //dropdown.onValueChanged.AddListener(DropDownValue);
    }

    private void SetButtonOnClick(Button button,int num)
    {
        button.onClick.AddListener(() => {
            SwitchButtonOpen();
            if(num == 1 && num == 2 && num == 3 && num== 4 && num==5)
            {
                Map.sprite = MapBg[2];
            }
            else if(num == 6)
            {
                Map.sprite = MapBg[1];
            }
            else if(num == 7 && num == 8)
            {
                Map.sprite = MapBg[0];
            }

            CurrentDevices = (DevicesType)Enum.ToObject(typeof(DevicesType), num);
        });
    }

    private void SetDropDownButton(Button button,int num)
    {
        button.onClick.AddListener(() => {

            int temp = (int)CurrentDevices;

            switch (num)
            {
                case 0:
                    deviceDisplayPanel.SetMassage(MapBg, CurrentDevices.ToString(), CurrentDevices.ToString());
                    deviceDisplayPanel.Open();
                    break;
                case 1:
                    SetText("设备台账", CurrentDevices.ToString());
                    break;
                case 2:
                    SetText("技术参数", CurrentDevices.ToString());
                    break;
                case 3:
                    SetText("内部组件", CurrentDevices.ToString());
                    break;
                case 4:
                    SetText("设备功能", CurrentDevices.ToString());
                    break;
                default:
                    break;
            }
        });
    }

    public override void Open()
    {
        base.Open();

        SetText("操作方法", "W S A D控制行走，Q E 控制方向");

        if (DirectoryPanel.functionType == FunctionType.Check)
        {
            Check_Hide();
            SwitchButtonCanvasGroup.Hide();
            MainControl.Instance.ShineiScene.gameObject.SetActive(true);

            Tips.sprite = TipsBG[1];
            TiltleText.text = "";
            checkPanel.Open();
            EventManager.AddListener(GenericEventEnumType.Message, DirectoryPanel.functionType.ToString(), Callback2);
        }
        else
        {
            TiltleText.text = "操作方法";
            Tips.sprite = TipsBG[0];
            Check_Open();
            switch (TrainingPanel.trainType)
            {
                case TrainingEnum.TrainType.漫游浏览:
                    Shiwaimanyou();
                    break;
                case TrainingEnum.TrainType.电站认知:
                    Shineimanyou();
                    EventManager.AddListener(GenericEventEnumType.Message, TrainingEnum.TrainType.电站认知.ToString(), Callback);
                    break;
                default:
                    break;
            }
        }
        Main.Instance.MainCamera.enabled = false;
    }

    private void Callback2(EventParamete parameteData)
    {
        if(checkPanel.IsStart)
        {
            DevicesType devicesType = parameteData.GetParameter<DevicesType>()[0];
            switch (devicesType)
            {
                case DevicesType.发电机:
                    checkPanel.ScoreAdd(10);
                    break;
                default:
                    break;
            }

            if (checkPanel.ScoreData >= 100)
            {
                checkPanel.TipsCanvas_Open();
                //if(scrollRect.verticalScrollbar.enabled)
                //{
                //    scrollRect.verticalScrollbar.value = 1;
                //}
            }
                
        }
    }

    private void Callback(EventParamete parameteData)
    {
        DevicesType devicesType = parameteData.GetParameter<DevicesType>()[0];

        Dropdown_Open();

        switch (devicesType)
        {
            case DevicesType.发电机:

                break;
            default:
                break;
        }
    }

    public override void Hide()
    {
        base.Hide();

        deviceDisplayPanel.Hide();
        DropdownCanvas.Hide();

        if(checkPanel.IsOpen)
        {
            checkPanel.Hide();
        }


        MainControl.Instance.ShineiScene.gameObject.SetActive(false);
        MainControl.Instance.ShiwaiScene.gameObject.SetActive(false);
        Main.Instance.MainCamera.enabled = true;

        EventManager.RemoveListener(MTFrame.MTEvent.GenericEventEnumType.Message, TrainingEnum.TrainType.电站认知.ToString(), Callback);
        EventManager.RemoveListener(MTFrame.MTEvent.GenericEventEnumType.Message, DirectoryPanel.functionType.ToString(), Callback2);
    }

    private void Shiwaimanyou()
    {
        SwitchButtonCanvasGroup.Hide();
        Map.sprite = MapBg[3];
        MainControl.Instance.ShiwaiScene.gameObject.SetActive(true);
        MainControl.Instance.ShineiScene.gameObject.SetActive(false);
    }

    private void Shineimanyou()
    {
        Map.sprite = MapBg[1];

        SwitchButtonCanvasGroup.Hide();
        MainControl.Instance.ShiwaiScene.gameObject.SetActive(false);
        MainControl.Instance.ShineiScene.gameObject.SetActive(true);
    }

    private void SwitchButtonOpen()
    {
        if(TrainingPanel.trainType == TrainingEnum.TrainType.漫游浏览)
        {
            SwitchButtonCanvasGroup.Open();

            
        }


        MainControl.Instance.ShineiScene.gameObject.SetActive(true);
        MainControl.Instance.ShiwaiScene .gameObject.SetActive(false);
    }

    private void Check_Open()
    {
        Minimap.alpha = 1;

        transfer.Open();

        ButtonsCanvas.Open();
    }

    private void Check_Hide()
    {
        Minimap.alpha = 0;

        transfer.Hide();

        ButtonsCanvas.Hide();

        SwitchButtonCanvasGroup.Hide();

    }

    private void Dropdown_Open()
    {
        DropdownCanvas.Open();

        //dropdown.value = 0;
    }

    private void SetText(string Tiltle,string Content)
    {
        TiltleText.text = Tiltle;
        ContentText.text = Content;
    }
}
