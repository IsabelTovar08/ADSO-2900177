namespace Entity.Models
{
    public class Module
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } = false;

        public List<ModuleForm> ModuleForm { get; set; } 
    }
}
