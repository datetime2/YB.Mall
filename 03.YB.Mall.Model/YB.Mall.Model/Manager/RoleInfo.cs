using System.Collections.Generic;

namespace YB.Mall.Model
{
    public class RoleInfo
    {
        public RoleInfo()
        {
            this.ManageInfo=new HashSet<ManageInfo>();
        }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int? Status { get; set; }
        public virtual ICollection<ManageInfo> ManageInfo { get; set; } 
    }
}