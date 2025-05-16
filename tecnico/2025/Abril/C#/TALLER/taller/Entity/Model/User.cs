using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UserNAme { get; set; }
        public string Rol { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

    }
}
