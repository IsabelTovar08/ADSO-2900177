using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.AuditLog
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string Action { get; set; }
        public string FieldName { get; set; }  
        public string OldValue { get; set; }  
        public string NewValue { get; set; } 
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
