﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string? ActivationCode { get; set; }


        public int PersonId { get; set; }

        public Person Person { get; set; }

        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
