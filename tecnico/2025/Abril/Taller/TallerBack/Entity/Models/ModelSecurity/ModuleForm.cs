using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class ModuleForm
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int FormId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Module Module { get; set; }
        public Form Form { get; set; }
    }
}
