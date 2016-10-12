using System.Collections.Generic;

namespace YB.Mall.Model
{
    public class ManageInfo
    {
        public ManageInfo()
        {
            this.RoleInfo=new HashSet<RoleInfo>();
        }
        public int ManageId { get; set; }
        public string ManageName { get; set; }
        public string RealName { get; set; }
        public string PassPlat { get; set; }
        public string PassWord { get; set; }
        public int? Status { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<RoleInfo> RoleInfo { get; set; }

    }
}