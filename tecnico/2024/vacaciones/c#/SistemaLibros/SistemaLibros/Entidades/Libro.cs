namespace SistemaLibros.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public required DateTime FechaPublicacion { get; set; }

    }
}
