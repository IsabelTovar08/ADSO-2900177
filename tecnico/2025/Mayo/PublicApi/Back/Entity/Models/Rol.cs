namespace Entity.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public bool IsDeleted { get; set; } = false;

        public List<UserRol> UserRoles { get; set; }
        public List<RolFormPermission> RolFormPermissions { get; set; }

    }
}
