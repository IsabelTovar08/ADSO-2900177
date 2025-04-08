using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateOnly Date { get; set; }
        public bool Status { get; set; }


        public int EventTypeId { get; set; } 
        public EventType EventType { get; set; } 

        public List<AccessPoint> AccessPoints { get; set; } = new List<AccessPoint>(); 
    }
}
