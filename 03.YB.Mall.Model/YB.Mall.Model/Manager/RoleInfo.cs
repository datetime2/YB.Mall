using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace YB.Mall.Model
{
    public class RoleInfo
    {
        public RoleInfo()
        {
            this.ManageRole = new HashSet<ManageRole>();
            this.RoleMenu = new HashSet<RoleMenu>();
        }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int Status { get; set; }
        public bool AllowDelte { get; set; }
        public bool AllowEdit { get; set; }
        public RoleType RoleType { get; set; }
        public int? OrganizeId { get; set; }
        public string OrganizeName { get; set; }
        public DateTime? CreateTime { get; set; }
        public bool IsEnabled { get; set; }
        public int Sort { get; set; }
        public string Remark { get; set; }
        public DateTime? LastUpdTime { get; set; }
        public virtual ICollection<ManageRole> ManageRole { get; set; }
        public virtual ICollection<RoleMenu> RoleMenu { get; set; }
    }
}