namespace Entity.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } = false;

        public List<RolFormPermission> RolFormPermissions { get; set; }
    }
}
