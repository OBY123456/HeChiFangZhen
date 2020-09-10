namespace WaitEnum
{
    public enum AccountType
    {
        /// <summary>
        /// 游客
        /// </summary>
        Tourists = 0,

        /// <summary>
        /// 学生
        /// </summary>
        Student = 1,

        /// <summary>
        /// 教师
        /// </summary>
        Teacher = 2,

        /// <summary>
        /// 管理员
        /// </summary>
        Administrator = 3
    }
}

namespace MTFrame
{
    public enum PanelName
    {
        /// <summary>
        /// 首页/一级页面
        /// </summary>
        WaitPanel,

        /// <summary>
        /// 功能选择页/二级页面
        /// </summary>
        DirectoryPanel,

        /// <summary>
        /// 菜单页/三级页面/培训页
        /// </summary>
        TrainingPanel,

        /// <summary>
        /// 菜单页/三级页面/考核页
        /// </summary>
        CheckPanel,

        /// <summary>
        /// 菜单页/三级页面/成绩页
        /// </summary>
        ScorePanel,

        /// <summary>
        /// 菜单页/三级页面/修改账号页
        /// </summary>
        AdminPanel,

        /// <summary>
        /// 菜单页/四级页面/漫游
        /// </summary>
        ManYouPanel,

        /// <summary>
        /// 菜单页/四级页面/设备拆卸/组装
        /// </summary>
        SheBeiPanel,

        /// <summary>
        /// 菜单页/四级页面/仿真开机流程
        /// </summary>
        FangzhenkaijiPanel,
    }

    public enum EventType
    {
        PanelSwitch,
    }
}