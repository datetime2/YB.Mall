namespace YB.Mall.Model.ViewModel
{
    public class MenuViewModel
    {
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string MenuName { get; set; }
        public string UrlPath { get; set; }
        public string Target { get; set; }
        public string Icon { get; set; }
        public bool IsMenu { get; set; }
        public bool IsButton { get; set; }
        public bool IsEnabled { get; set; }
        public string Remark { get; set; }
        public string ElementId { get; set; }
        public string Event { get; set; }
        public string MenuType { get; set; }
    }
    public class OrganizeViewModel
    {
        public int OrganizeId { get; set; }
        public int ParentId { get; set; }
        public string OrganizeName { get; set; }
        public string OrganizeEnCode { get; set; }
        public string OrganizeType { get; set; }
        public string ManagerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsEnabled { get; set; }
        public string Description { get; set; }
    }
}