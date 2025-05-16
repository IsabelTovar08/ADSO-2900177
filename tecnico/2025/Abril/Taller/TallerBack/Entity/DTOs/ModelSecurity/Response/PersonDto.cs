using System.ComponentModel.DataAnnotations;

namespace Entity.DTOs
{
    public class PersonDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string Identification { get; set; }
        public string? Phone { get; set; }
        public bool IsDeleted { get; set; }
    }
}
