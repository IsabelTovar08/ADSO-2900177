using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int PersonId { get; set; }
        public string? PersonFirstName { get; set; }
        public string? PersonLastName { get; set; }


    }
}
