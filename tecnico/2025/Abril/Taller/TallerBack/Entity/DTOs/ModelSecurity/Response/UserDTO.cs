

namespace Entity.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NamePerson { get; set; }
        public int PersonId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
