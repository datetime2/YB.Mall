using System.ComponentModel;

namespace YB.Mall.Model
{
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
}