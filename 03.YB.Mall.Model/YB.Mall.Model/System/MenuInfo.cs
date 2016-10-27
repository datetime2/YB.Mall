using System;
using System.Collections.Generic;

namespace YB.Mall.Model
{
    public class MenuInfo
    {
        public MenuInfo()
        {
            this.RoleMenu = new HashSet<RoleMenu>();
        }
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public string UrlPath { get; set; }
        public string Target { get; set; }
        public string ElementId { get; set; }
        public string Event { get; set; }
        public int? Sort { get; set; }
        public AuthorizeType MenuType { get; set; }
        public bool IsEnabled { get; set; }
        public string Remark { get; set; }
        public DateTime? LastUpdTime { get; set; }
        public virtual ICollection<RoleMenu> RoleMenu { get; set; }
    }
}