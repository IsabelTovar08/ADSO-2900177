using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateOnly Hour {  get; set; }
        public string TypeOfRecord { get; set; }
        public bool Active { get; set; }


        public int CardId { get; set; }
        public Card Card { get; set; } 

        public List<AccessPoint> AccessPoints { get; set; } = new List<AccessPoint>();
    }
}
