using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public string Título { get; set; }
        public string FechaPublicacion { get; set; }
        public int AutorId { get; set; }

    }
}
