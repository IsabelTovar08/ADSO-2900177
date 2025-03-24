using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class RoleFormPermissionDTO
    {
        public int RoleId {  get; set; }
        public int FormID { get; set; }
        public int PermissionId { get; set; }    
    }
}
