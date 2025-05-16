using System.ComponentModel.DataAnnotations;
using Entity.Models;

namespace Entity.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? Identification { get; set; }
        public bool IsDeleted { get; set; } = false;

        public List<User> Users { get; set; }
    }
}
