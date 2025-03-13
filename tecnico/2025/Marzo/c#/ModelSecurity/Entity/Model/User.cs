using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
