namespace YB.Mall.Model
{
    public class MenuInfo
    {
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string MenuName { get; set; }
        public int? Status { get; set; }
        public int? Sort { get; set; }
    }
}