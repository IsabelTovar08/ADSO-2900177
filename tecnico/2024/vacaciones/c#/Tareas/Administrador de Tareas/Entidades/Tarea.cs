namespace Administrador_de_Tareas.Entidades
{
    public class Tarea
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public Boolean Completada { get; set; } = false;
    }
}
