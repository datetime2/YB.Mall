using System;
using System.Collections.Generic;

namespace YB.Mall.Model
{
    public class MenuInfo
    {
        public MenuInfo()
        {
            this.RoleInfo = new HashSet<RoleInfo>();
            this.MenuButtonInfo = new HashSet<MenuButtonInfo>();
        }
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public string UrlPath { get; set; }
        public string Target { get; set; }
        public int? Sort { get; set; }
        public bool IsMenu { get; set; }
        public bool IsEnabled { get; set; }
        public string Remark { get; set; }
        public DateTime? LastUpdTime { get; set; }
        public virtual ICollection<RoleInfo> RoleInfo { get; set; }
        public virtual ICollection<MenuButtonInfo> MenuButtonInfo { get; set; }
    }
}