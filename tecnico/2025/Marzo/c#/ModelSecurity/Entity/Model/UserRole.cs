﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    internal class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoloId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
