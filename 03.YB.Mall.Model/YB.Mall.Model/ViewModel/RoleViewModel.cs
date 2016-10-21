namespace YB.Mall.Model.ViewModel
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleType { get; set; }
        public bool AllowDelte { get; set; }
        public bool AllowEdit { get; set; }
    }
}