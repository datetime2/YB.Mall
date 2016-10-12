using System.Collections.Generic;

namespace YB.Mall.Model
{
    public class RoleInfo
    {
        public RoleInfo()
        {
            this.ManageInfo=new HashSet<ManageInfo>();
            this.MenuInfo=new HashSet<MenuInfo>();
        }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int? Status { get; set; }
        public virtual ICollection<ManageInfo> ManageInfo { get; set; }
        public virtual ICollection<MenuInfo> MenuInfo { get; set; }
    }
}