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
    [HideInInspector]
    public CanvasGroup Caozuofangshi, transfer, Minimap,ButtonsCanvas, DropdownCanvas;
    //public Button CIS, Chuxianzhuangzhi, Fadianji, Lichixitong,Jizutiaosuju, Bianyaqi, Shuilunji;
    public Text TiltleText, ContentText;
    public Button SwitchButton;
    public CanvasGroup SwitchButtonCanvasGroup;
    public Image Map;
    public Button[] dropdown;
    public DeviceDisplayPanel deviceDisplayPanel;
    public Button CloseButton;
    public ScrollRect scrollRect;
    public CheckEndPanel checkPanel;
    public Button[] TransportButtons;
    public Sprite[] MapBg;
    public DevicesType CurrentDevices;
    private string[,] deviceMassages = {
        {
            "设备名称　主变压器\n设备编号坪　9F\n出厂编号　DNJPCGBG005\n规格型号　NP08\n制造厂家　广州晓星变压器有限公司\n出厂日期　2003.12\n投运日期　2005.09.21\n主要用途　升压\n设备原值　9万元",
            "额定容量　1000kVA\n电压组合 11\n分接范围 -+ 5%\n低压 6.3\n联结组标号 Yd11\n短路阻抗 5.5%\n损耗空载 1.65\n损耗负载 10.30\n空载电流 0.7\n油重 120KG",
            "\u3000\u3000变压器是用来变换交流电压、电流而传输交流电能的一种静止的电器设备。它是根据电磁感应的原理实现电能传递的。变压器就其用途可分为电力变压器、试验变压器、仪用变压器及特殊用途的变压器：电力变压器是电力输配电、电力用户配电的必要设备；试验变压器对电器设备进行耐压（升压）试验的设备；仪用变压器作为配电系统的电气测量、继电保护之用（PT、CT）；特殊用途的变压器有冶炼用电炉变压器、电焊变压器、电解用整流变压器、小型调压变压器等。",
        },
        {
            "设备名称　出线开关柜\n设备编号坪　4F\n出厂编号　NU899BHS512\n规格型号　G250PW10VSD\n制造厂家　紫瑞环保\n出厂日期　1999.11\n投运日期　2004.03\n主要用途\n设备原值　1万元",
            "额定电压 10000V\n额定电流 9600A\n二次 220V",
            "\u3000\u3000线路保护装置是指主要用于各电压等级的间隔单元的保护测控，具备完善的保护、测量、控制、备用电源自投及通信监视功能，为变电站、发电厂、高低压配电及厂用电系统的保护与控制提供了完整的解决方案，可有力地保障高低压电网及厂用电系统的安全稳定运行的装置。",
        },
        {
            "",
            "",
            "",
        },
        {
            "设备名称　发电机\n设备编号　GB/T7894\n出厂编号　HF-14-1 \n规格型号　FF2500-48/3620\n制造厂家　广西宜州市同心圆电力有限责任公司\n出厂日期　2007.1\n投运日期　2007.2\n主要用途　把机械能转换为电能\n设备原值　80万元",
            "额定容量 2500/2941\n额定电流 161.7A\n额定电压 10500V\n绝缘频率 50Hz\n额定功率因数 0.85\n额定励磁电压 165V\n额定励磁电流 305A\n额定转速 125r/min\n飞逸转速 280r/min\n绝缘等级 F\n重量 69T\n(滞后)相数 3\n可控硅接法 Y",
            "\u3000\u3000水轮发电机是指以水轮机为原动机将水能转化为电能的发电机。水流经过水轮机时，将水能转换成机械能，水轮机的转轴又带动发电机的转子，转轮通过主轴与发电机转子联轴，带动转子旋转并切割发电机定子磁力线圈，利用电磁感应原理在发电机线圈中产生高压电，再经过变压器升压通过输电线路将电力输出到电网起中，是水电站生产电能的主要动力设备。",
        },
        {
            "设备名称　机组调速柜\n设备编号坪　3F\n出厂编号　851EIDISN84R\n规格型号　INND14\n制造厂家　能事达电气\n出厂日期　2003.12\n投运日期　2005.4\n主要用途　控制发电机速度\n设备原值　14万元",
            "控制电机功率：160KW；\n控制电压：380V；\n压力控制精度:0.02MPa\n测频范围: 100HZ\n人工失灵区范围Ef: 0.5 HZ\n永态转差系数bp: 10 %\n比例增益Kp: 20\n积分增益Ki:  1/s ",
            "\u3000\u3000调速器用于减小某些机器非周期性速度波动的自动调节装置。可使机器转速保持定值或接近设定值。水轮机、汽轮机、燃气轮机和内燃机等与电动机不同，其输出的力矩不能自动适应本身的载荷变化，因而当载荷变动时，由它们驱动的机组就会失去稳定性。这类机组必须设置调速器，使其能随着载荷等条件变化，随时建立载荷与能源供给量之间的适应关系，以保证机组作正常运转。调速器的理论和设计问题，是机械动力学的研究内容。调速器的种类很多。其中应用最广泛的是机械式离心调速器。而以测速发电机或其他电子器件作为传感器的调速器，已在各个工业部门中广为应用。",
        },
        {
            "设备名称　励磁系统\n设备编号坪　3F\n出厂编号　3BHE023784R\n规格型号　PP D113\n制造厂家　广州擎天实业有限公司\n出厂日期　2004.12\n投运日期　2005.9\n主要用途　供给同步发电\n设备原值　28万元",
            "额励磁变额定容量 6000kVA\n励磁变额定电压 20KV/0.89KV\n励磁变额定频率 50Hz\n励磁变相数 3\n励磁方式 单向\n励磁变联结组标号 Y/d-11\n励磁变绝缘等级 F\n励磁变防护等级 IP32\n励磁变冷却方式 FN\n励磁变短路阻抗 8%",
            "\u3000\u3000供给同步发电机励磁电流的电源及其附属设备统称为励磁系统。它一般由励磁功率单元和励磁调节器两个主要部分组成。励磁功率单元向同步发电机转子提供励磁电流；而励磁调节器则根据输入信号和给定的调节准则控制励磁功率单元的输出。励磁系统的自动励磁调节器对提高电力系统并联机组的稳定性具有相当大的作用。尤其是现代电力系统的发展导致机组稳定极限降低的趋势，也促使励磁技术不断发展",
        },
        {
            "设备名称　油压装置\n设备编号坪　3F\n出厂编号　3BHE023784R\n规格型号　PP D113\n制造厂家　广西第二安装公司压力容器制造厂制造\n出厂日期　2004.12\n投运日期　2005.9\n主要用途　提供动力\n设备原值　4万元",
            "容器净重 2867kg\n容积 5.6m3\n设计压力 2.9MPa\n最高工作压力 2.8MPa\n耐压实验压力3.63MPa\n设计温度 60°",
            "\u3000\u3000指提供汽轮机系统各液压操作元件压力油源的专用设备。",
        },
        {
            "设备名称　空气压缩机\n设备编号坪　1F\n出厂编号　JH8437H7R\n规格型号　G250PW10VSD\n制造厂家　德耐尔\n出厂日期　2006.12\n投运日期　2007.04\n主要用途　空气压缩\n设备原值　8万元",
            "冷却方式 水冷\n排气温度 -+10°\n噪音 77-+3dB(A)\n排气含油量 2ppm\n排气除尘精度 2um\n电机功率 250KW\n电压 380V\n电机防护等级 IP55\n电机绝缘等级 F",
            "\u3000\u3000空气压缩机是一种用以压缩气体的设备。空气压缩机与水泵构造类似。大多数空气压缩机是往复活塞式，旋转叶片或旋转螺杆。离心式压缩机是非常大的应用程序。",
        },
        {
            "设备名称　离心泵\n设备编号坪　1F\n出厂编号　8H89NKHG65\n规格型号　RDL600-830A\n制造厂家　广东科琪调速有限公司\n出厂日期　2006.12\n投运日期　2007.01\n主要用途　水泵\n设备原值　2万元",
            "流量 160m3/h\n吸入口径 125mm\n功率 22kw\n叶轮结构 封闭式叶轮\n排出口径 125mm\n扬程 32m\n叶轮吸入方式 单吸式\n电压 380V",
            "\u3000\u3000水泵是输送液体或使液体增压的机械。它将原动机的机械能或其他外部能量传送给液体，使液体能量增加，主要用来输送液体包括水、油、酸碱液、乳化液、悬乳液和液态金属等。也可输送液体、气体混合物以及含悬浮固体物的液体。水泵性能的技术参数有流量、吸程、扬程、轴功率、水功率、效率等；根据不同的工作原理可分为容积水泵、叶片泵等类型。容积泵是利用其工作室容积的变化来传递能量；叶片泵是利用回转叶片与水的相互作用来传递能量，有离心泵、轴流泵和混流泵等类型。",
        },
    };

    //private string CheckMsg = "考核开始\n第一题：请找出并选中场景中的发电机。总分20分。\n第二题：请找出并选中场景中的机组调速柜。总分20分。\n第三题：请找出并选中场景中的励磁装置。总分20分。\n第四题：请找出并选中场景中的油压装置。总分20分。\n第五题：请找出并选中场景中的出线装置。总分20分。";

    private string[] CheckMsgs = {

        "考核开始\n第一题：请找出并选中场景中的发电机，总分20分。",
        "考核开始\n<color=red>第一题：请找出并选中场景中的发电机，总分20分。</color>\n第二题：请找出并选中场景中的机组调速柜，总分20分。",
        "考核开始\n<color=red>第一题：请找出并选中场景中的发电机，总分20分。\n第二题：请找出并选中场景中的机组调速柜，总分20分。</color>\n第三题：请找出并选中场景中的励磁装置，总分20分。",
        "考核开始\n<color=red>第一题：请找出并选中场景中的发电机，总分20分。\n第二题：请找出并选中场景中的机组调速柜，总分20分。\n第三题：请找出并选中场景中的励磁装置，总分20分。</color>\n第四题：请找出并选中场景中的油压装置，总分20分。",
        "考核开始\n<color=red>第一题：请找出并选中场景中的发电机，总分20分。\n第二题：请找出并选中场景中的机组调速柜，总分20分。\n第三题：请找出并选中场景中的励磁装置，总分20分。\n第四题：请找出并选中场景中的油压装置，总分20分。</color>\n第五题：请找出并选中场景中的出线装置，总分20分。",
        "考核开始\n<color=red>第一题：请找出并选中场景中的发电机，总分20分。\n第二题：请找出并选中场景中的机组调速柜，总分20分。\n第三题：请找出并选中场景中的励磁装置，总分20分。\n第四题：请找出并选中场景中的油压装置，总分20分。\n第五题：请找出并选中场景中的出线装置，总分20分。</color>",
    };

    private bool IsCheck1, IsCheck2, IsCheck3, IsCheck4;

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
            if(num == 1 || num == 3 || num == 4 || num== 5 || num==6)
            {
                Map.sprite = MapBg[1];
            }
            else if(num == 7 || num == 8)
            {
                Map.sprite = MapBg[0];
            }

            MainControl.Instance.shineiScene.SceneOpen(ShineiSceneEnum.SceneType.Scene1, 0);
            //CurrentDevices = (DevicesType)Enum.ToObject(typeof(DevicesType), num);
        });
    }

    private void SetDropDownButton(Button button,int num)
    {
        button.onClick.AddListener(() => {

            int temp = (int)CurrentDevices;

            switch (num)
            {
                case 0:
                    DropdownCanvas.Hide();
                    deviceDisplayPanel.Open();
                    break;
                case 1:
                    SetText("设备台账", deviceMassages[temp,0]);
                    break;
                case 2:
                    SetText("技术参数", deviceMassages[temp, 1]);
                    break;
                case 3:
                    DropdownCanvas.Hide();
                    SetText("内部组件", CurrentDevices.ToString());
                    MainControl.Instance.shineiScene.SceneOpen(ShineiSceneEnum.SceneType.Scene2, temp);
                    break;
                case 4:
                    SetText("设备功能", deviceMassages[temp, 2]);
                    break;
                default:
                    break;
            }
        });
    }

    public override void Open()
    {
        base.Open();

        

        if (DirectoryPanel.functionType == FunctionType.Check)
        {
            Check_Hide();
            SwitchButtonCanvasGroup.Hide();
            MainControl.Instance.ShineiScene.gameObject.SetActive(true);
            SetText("考核内容", CheckMsgs[0]);
            checkPanel.Open();
            EventManager.AddListener(GenericEventEnumType.Message, DirectoryPanel.functionType.ToString(), Callback2);
        }
        else
        {
            SetText("操作方法", "W S A D控制行走 鼠标控制方向");
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
                    if(!IsCheck1)
                    {
                        IsCheck1 = true;
                        checkPanel.ScoreAdd(20);
                        SetText("考核内容", CheckMsgs[1]);
                    }
                    break;
                case DevicesType.机组调速柜:
                    if(IsCheck1 && !IsCheck2)
                    {
                        IsCheck2 = true;
                        checkPanel.ScoreAdd(20);
                        SetText("考核内容", CheckMsgs[2]);
                    }
                    break;
                case DevicesType.励磁系统:
                    if (IsCheck2 && !IsCheck3)
                    {
                        IsCheck3 = true;
                        checkPanel.ScoreAdd(20);
                        SetText("考核内容", CheckMsgs[3]);
                    }
                    break;
                case DevicesType.油压装置:
                    if (IsCheck3 && !IsCheck4)
                    {
                        IsCheck4 = true;
                        checkPanel.ScoreAdd(20);
                        SetText("考核内容", CheckMsgs[4]);
                    }
                    break;
                case DevicesType.出线装置:
                    if (IsCheck4)
                    {
                        checkPanel.ScoreAdd(20);
                        SetText("考核内容", CheckMsgs[5]);
                    }
                    break;
                default:
                    break;
            }
            switch (devicesType)
            {
                case DevicesType.发电机:
                   
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
        Dropdown_Open();

        CurrentDevices = parameteData.GetParameter<DevicesType>()[0];
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

        IsCheck1 = IsCheck2 = IsCheck3 = IsCheck4 = false;

        MainControl.Instance.ShineiScene.gameObject.SetActive(false);
        MainControl.Instance.ShiwaiScene.gameObject.SetActive(false);
        Main.Instance.MainCamera.enabled = true;

        EventManager.RemoveListener(MTFrame.MTEvent.GenericEventEnumType.Message, TrainingEnum.TrainType.电站认知.ToString(), Callback);
        EventManager.RemoveListener(MTFrame.MTEvent.GenericEventEnumType.Message, DirectoryPanel.functionType.ToString(), Callback2);
    }

    private void Shiwaimanyou()
    {
        SwitchButtonCanvasGroup.Hide();
        Map.sprite = MapBg[2];
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
