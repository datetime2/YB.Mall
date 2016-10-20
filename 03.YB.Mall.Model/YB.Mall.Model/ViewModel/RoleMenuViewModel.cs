using System.Collections.Generic;

namespace YB.Mall.Model.ViewModel
{
    public class RoleMenuViewModel
    {
        public int? MenuId { get; set; }
        public int? ParentId { get; set; }
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public List<Children> ChildrenNodes { get; set; }
    }
    public class Children
    {
        public int? MenuId { get; set; }
        public int? ParentId { get; set; }
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public string UrlPath { get; set; }
        public string Target { get; set; }
    }
}