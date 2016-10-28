namespace YB.Mall.Model
{
    public class ManageRole
    {
        public int Id { get; set; }
        public int ManageId { get; set; }
        public int RoleId { get; set; }
        public virtual ManageInfo ManageInfo { get; set; }
        public virtual RoleInfo RoleInfo { get; set; }
    }
}