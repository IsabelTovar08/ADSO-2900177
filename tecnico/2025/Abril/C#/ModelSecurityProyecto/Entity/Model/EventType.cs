using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }


        public List<Event> Events { get; set; } = new List<Event>(); 
    }
}
