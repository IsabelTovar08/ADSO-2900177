namespace Productos.Entidadess
{
    public class Producto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public string Descripcion { get; set; }
        public required decimal Precio { get; set; }
        public required int Stock { get; set; }
    }
}
