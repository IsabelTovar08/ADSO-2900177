﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        //public string UserName { get; set; }
        public int RoleId { get; set; }
        //public string RoleName { get; set; }
        public bool Status { get; set; }


        public User User { get; set; }
        public Role Role { get; set; }
    }
}
