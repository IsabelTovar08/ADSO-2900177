using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Libro
    {
        public int Id { get; set; }
        public string Título { get; set; }
        public string FechaPublicacion { get; set; }
        public bool IsDeleted { get; set; }

        public int AutorId { get; set; }
    }
}
