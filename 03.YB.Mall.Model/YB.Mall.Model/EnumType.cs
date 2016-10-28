using System.ComponentModel;

namespace YB.Mall.Model
{
    /// <summary>
    /// 角色类型
    /// </summary>
    public enum RoleType
    {
        /// <summary>
        /// 系统
        /// </summary>
        [Description("系统")]
        System,

        /// <summary>
        /// 业务
        /// </summary>
        [Description("业务")]
        Business
    }
    /// <summary>
    /// 权限类型
    /// </summary>
    public enum AuthorizeType
    {
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        None,
        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        Menu,
        /// <summary>
        /// 按钮
        /// </summary>
        [Description("按钮")]
        Button
    }
    /// <summary>
    /// 机构类型
    /// </summary>
    public enum OrganizeType
    {
        /// <summary>
        /// 集团
        /// </summary>
        [Description("集团")]
        Group,

        /// <summary>
        /// 公司
        /// </summary>
        [Description("公司")]
        Company,

        /// <summary>
        /// 部门
        /// </summary>
        [Description("部门")]
        Department,

        /// <summary>
        /// 小组
        /// </summary>
        [Description("小组")]
        WorkGroup
    }    
}