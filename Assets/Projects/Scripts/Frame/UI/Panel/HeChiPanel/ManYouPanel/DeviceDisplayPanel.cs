using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MTFrame;

public class DeviceDisplayPanel : BasePanel
{
    public Sprite[] Images;
    public Image image;
    public CanvasGroup buttons;
    public Text text,tiltleText;
    public Button LeftButton, RightButton,CloseButton;
    private int Index;
    public ManYouPanel manyoupanel;

    private string[] DeviceMsg = {
        "\u3000\u3000电力变压器按用途分类：升压（发电厂6.3kV/10.5kV或10.5kV/110kV等）、联络（变电站间用220kV/110kV或110kV/10.5kV）、降压（配电用35kV/0.4kV或10.5kV/0.4kV）。电力变压器按相数分类：单相、三相。电力变压器按绝缘介质分类：油浸变压器（阻燃型、非阻燃型）、干式变压器、110kVSF6气体绝缘变压器。电力变压器铁心均为芯式结构。",
        "\u3000\u3000优点\n1）机组正常起、停不需切换厂用电，只需操作发电机出口开关，厂用电可靠性高。\n2）机组在发电机开关以内发生故障时（如发电机、汽机、锅炉故障），只需跳开发电机开关，减少机组事故时的操作量。\n3）对保护主变压器、高压厂用工作变压器有利。对于主变压器、高压厂用工作变压器发生内部故障时，由于发电机励磁电流衰减需要一定时间，在发电机-变压器组保护动作切除主变压器高压侧开关后，发电机在励磁电流衰减阶段仍向故障点供电，而装设发电机开关后由于能快速切开发电机开关，而使主变压器受到更好的保护，这一点对于大型机组非常有利。另一个更有利的作用是：避免或减少了由于高压开关的非全相操作而造成的对发电机的危害。对于发电机变压器组接线，其高压开关由于额定电压较高（500KV），敞开式开关相间距离较大，不能做成三相机械连动，高压开关的非全相工况即使在正常操作时也时有发生，高压开关的非全相运行会在发电机定子上产生负序电流，而发电机转子承受负序磁场的能力是非常有限的，严重时会导致转子损坏。而发电机出口开关在设计和制造中都考虑了三相机械连动，有效防止了非全相操作的发生。",
        "",
        "\u3000\u3000同步电机，和感应电机（即异步电机）一样是一种常用的交流电机。同步电机是电力系统的心脏，它是一种集旋转与静止、电磁变化与机械运动于一体，实现电能与机械能变换的元件，其动态性能十分复杂，而且其动态性能又对全电力系统的动态性能有极大影响。特点是：稳态运行时，转子的转速和电网频率之间有不变的关系n=ns=60f/p，其中f为电网频率，p为电机的极对数，ns称为同步转速。若电网的频率不变，则稳态时同步电机的转速恒为常数而与负载的大小无关。同步电机分为同步发电机和同步电动机。现代发电厂中的交流机以同步发电机为主。",
        "\u3000\u3000调速器用于减小某些机器非周期性速度波动的自动调节装置。可使机器转速保持定值或接近设定值。水轮机、汽轮机、燃气轮机和内燃机等与电动机不同，其输出的力矩不能自动适应本身的载荷变化，因而当载荷变动时，由它们驱动的机组就会失去稳定性。这类机组必须设置调速器，使其能随着载荷等条件变化，随时建立载荷与能源供给量之间的适应关系，以保证机组作正常运转。调速器的理论和设计问题，是机械动力学的研究内容。调速器的种类很多。其中应用最广泛的是机械式离心调速器。而以测速发电机或其他电子器件作为传感器的调速器，已在各个工业部门中广为应用。",
        "\u3000\u3000励磁系统主要由功率单元和调节器（装置）两大部分组成。　其中励磁功率单元是指向同步发电机转子绕组提供直流励磁电流的励磁电源部分，而励磁调节器则是根据控制要求的输入信号和给定的调节准则控制励磁功率单元输出的装置。由励磁调节器、励磁功率单元和发电机本身一起组成的整个系统称为励磁系统控制系统。励磁系统是发电机的重要组成部份，它对电力系统及发电机本身的安全稳定运行有很大的影响。",
        "\u3000\u3000油压装置的功用是为各种设备提供安全、可靠和稳定的工作油压的液压能源能源装置，目前广泛用于水轮发电机组调速系统和机组控制系统，大型水电站，以及进水阀门等，其它需用压力油做为能源的地方也可以选用。",
        "\u3000\u3000空气压缩机（空压机）的种类很多。按工作原理可分为三大类：容积型、动力型（速度型或透平型）、热力型压缩机。按润滑方式可分为无油空压机和润滑空压机。螺杆压缩机——是回转容积式压缩机，在其中两个带有螺旋型齿轮的转子相互啮合，使两个转子啮合处体积由大变小，从而将气体压缩并排出。螺杆式空气压缩机中的螺杆压缩组件，采用最新型数控磨床内部制造， 并配合在线激光技术，确保制造公差精确无比。速度型压缩机——是回转式连续气流压缩机，在其中高速旋转的叶片使通过它的气体加速，从而将速度能转化为压力。这种转化部分发生在旋转叶片上，部分发生在固定的扩压器或回流器挡板上。离心式压缩机——属速度型压缩机，在其中有一个或多个旋转叶轮（叶片通常在侧面）使气体加速。主气流是径向的。轴流式压缩机——属速度型压缩机，在其中气体由装有叶片的转子加速。主气流是轴向的。",
        "\u3000\u3000离心泵：水泵开动前，先将泵和进水管灌满水，水泵运转后，在叶轮高速旋转而产生的离心力的作用下，叶轮流道里的水被甩向四周，压入蜗壳，叶轮入口形成真空，水池的水在外界大气压力下沿吸水管被吸入补充了这个空间。继而吸入的水又被叶轮甩出经蜗壳而进入出水管。由此可见，若离心泵叶轮不断旋转，则可连续吸水、压水，水便可源源不断地从低处扬到高处或远方。综上所述，离心泵是由于在叶轮的高速旋转所产生的离心力的作用下，将水提向高处的，故称离心泵。轴流泵：轴流泵与离心泵的工作原理不同，它主要是利用叶轮的高速旋转所产生的推力提水。轴流泵叶片旋转时对水所产生的升力，可把水从下方推到上方。",
    }; 

    public override void InitFind()
    {
        base.InitFind();
        image = FindTool.FindChildComponent<Image>(transform, "Image");
        buttons = FindTool.FindChildComponent<CanvasGroup>(transform, "buttons");
        LeftButton = FindTool.FindChildComponent<Button>(transform, "buttons/LeftButton");
        RightButton = FindTool.FindChildComponent<Button>(transform, "buttons/RightButton");
        text = FindTool.FindChildComponent<Text>(transform, "Content/Text_Medium");
        CloseButton = FindTool.FindChildComponent<Button>(transform, "CloseButton");
        tiltleText = FindTool.FindChildComponent<Text>(transform, "TiltleText");
        manyoupanel = FindTool.FindParentComponent<ManYouPanel>(transform, "ManYouPanel");
    }

    public override void InitEvent()
    {
        base.InitEvent();
        LeftButton.onClick.AddListener(() => {
            Index--;
            if(Index <= 0)
            {
                Index = 0;
            }
            image.sprite = Images[Index];
        });

        RightButton.onClick.AddListener(() => {
            Index++;
            if (Index >= Images.Length)
            {
                Index = Images.Length - 1;
            }
            image.sprite = Images[Index];
        });

        CloseButton.onClick.AddListener(() => {
            Hide();
        });
    }

    public override void Open()
    {
        base.Open();

        Index = 0;

        SetMassage();
        //if ( Images!=null && Images.Length > 1)
        //{
        //    buttons.Open();
        //}
        //else
        //{
        //    buttons.Hide();
        //}
    }

    public void SetMassage()
    {
        int temp = (int)manyoupanel.CurrentDevices;

        image.sprite = Images[temp];
        tiltleText.text = manyoupanel.CurrentDevices.ToString();
        text.text = DeviceMsg[temp];
        //image.sprite = sprites;
        //tiltleText.text = TiltleMsg;
        //text.text = ContentMsg;
    }

   
}
