using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool IsDeleted { get; set; }


        public List<Libro> Libros { get; set; } = new List<Libro>();
    }
}
