using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Entity.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int PersonId { get; set; }

        public Person Person { get; set; }
        public List<UserRol> UserRoles { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
