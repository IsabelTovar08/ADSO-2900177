using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class RoleFormPermissionDTO
    {
        public int Id { get; set; }
        public int RoleId {  get; set; }
        public string RoleName { get; set; }
        public int FormId { get; set; }
        public string FormName { get; set; }
        public int PermissionId { get; set; }    
        public string PermissionName { get; set; }
    }
}
