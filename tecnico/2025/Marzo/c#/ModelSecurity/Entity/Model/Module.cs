using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    internal class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Form> Forms { get; set; }
        public virtual ICollection<RoleModule> RoleModules { get; set; }
    }
}
