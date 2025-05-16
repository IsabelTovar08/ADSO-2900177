namespace Entity.Models
{
    public class Form 
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } = false;

        public List<RolFormPermission> RolFormPermissions { get; set; } 

        public List<ModuleForm> ModuleForm { get; set; } 
    }
}
