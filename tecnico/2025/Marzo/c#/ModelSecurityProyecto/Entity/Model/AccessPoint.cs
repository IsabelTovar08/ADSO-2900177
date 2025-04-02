using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Entity.Model
{
    public class AccessPoint
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Ubication { get; set; }
        public bool Status { get; set; }


        public int EventId { get; set; } 
        public Event Event { get; set; }

    }
}
