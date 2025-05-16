
using System.ComponentModel.DataAnnotations;

namespace Entity.DTOs.Create
{
    public class UserRolCreateDto
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RolId { get; set; }
    }
}
