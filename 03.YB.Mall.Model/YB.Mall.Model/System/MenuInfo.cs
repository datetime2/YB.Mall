using System;
using System.Collections.Generic;

namespace YB.Mall.Model
{
    public class MenuInfo
    {
        public MenuInfo()
        {
            this.Target = "iframe";
            this.RoleInfo=new HashSet<RoleInfo>();
        }
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public string UrlPath { get; set; }
        public string Target { get; set; }
        public int? Status { get; set; }
        public int? Sort { get; set; }
        public DateTime? LastUpdTime { get; set; }
        public virtual ICollection<RoleInfo> RoleInfo { get; set; }
    }
}