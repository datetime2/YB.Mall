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
    /// 机构类型
    /// </summary>
    public enum OrganizeType
    {
        /// <summary>
        /// 研发部
        /// </summary>
        [Description("研发部")]
        Development,

        /// <summary>
        /// 采购部
        /// </summary>
        [Description("采购部")]
        Purchasing,

        /// <summary>
        /// 财务部
        /// </summary>
        [Description("财务部")]
        Finance,

        /// <summary>
        /// 运营部
        /// </summary>
        [Description("运营部")]
        Operation,

        /// <summary>
        /// 商品部
        /// </summary>
        [Description("商品部")]
        Product
    }
}