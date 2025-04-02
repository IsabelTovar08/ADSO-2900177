using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class RoleFormPermission
    {
        public int Id { get; set; }
        public int RoleId {  get; set; }
        public int FormId { get; set; }
        public int PermissionId { get; set; }
        public bool State { get; set; }


        public Role Role { get; set; }
        public Form Form { get; set; }
        public Permission Permission { get; set; }
    }
}