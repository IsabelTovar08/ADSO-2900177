﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Card
    {
        public int Id { get; set; }
        public string QR { get; set; }
        public bool Status { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly ExpirationDate { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
