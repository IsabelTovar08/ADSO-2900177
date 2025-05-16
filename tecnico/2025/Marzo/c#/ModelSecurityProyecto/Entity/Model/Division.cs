using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }


        //Relaciones
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
        public List<DivisionBranch> DivisionBranches { get; set; } = new List<DivisionBranch>(); 
    }
}
