namespace YB.Mall.Model
{
    public class Organize
    {
        public int OrganizeId { get; set; }
        public int ParentId { get; set; }
        public string OrganizeName { get; set; }
        public string OrganizeEnCode { get; set; }
        public OrganizeType OrganizeType { get; set; }
        public string ManagerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsEnabled { get; set; }
        public string Description { get; set; }
    }

   
}