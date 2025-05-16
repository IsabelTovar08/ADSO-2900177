using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Assignment
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }


        public int DivisionId { get; set; } 
        public Division Division { get; set; } 
        
        public List<Person> Persons { get; set; } = new List<Person>();

    }
}
