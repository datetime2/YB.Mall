using System.Collections.Generic;

namespace YB.Mall.Model
{
    public class ManageInfo
    {
        public ManageInfo()
        {
            this.ManageRole = new HashSet<ManageRole>();
        }
        public int ManageId { get; set; }
        public string Account { get; set; }
        public string RealName { get; set; }
        public string PassPlat { get; set; }
        public string PassWord { get; set; }
        public bool IsEnabled { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool Gender { get; set; }
        public virtual ICollection<ManageRole> ManageRole { get; set; }
    }
}