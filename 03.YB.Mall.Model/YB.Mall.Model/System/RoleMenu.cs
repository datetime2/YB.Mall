namespace YB.Mall.Model
{
    public class RoleMenu
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public virtual RoleInfo RoleInfo { get; set; }
        public virtual MenuInfo MenuInfo { get; set; }
    }
}