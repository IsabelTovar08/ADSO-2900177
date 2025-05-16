
namespace Entity.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }
        public bool Status { get; set; }
        public int? PersonId { get; set; } 
        public Person? Person { get; set; }
        public List<UserRol> UserRoles { get; set; } = new List<UserRol>();

    }
}
