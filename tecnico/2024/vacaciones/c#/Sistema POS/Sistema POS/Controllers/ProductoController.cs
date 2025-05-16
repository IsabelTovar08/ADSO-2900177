using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_POS.Models;

namespace Sistema_POS.Controllers
{
    internal class ProductoController
    {
        public DataTable listarProductos()
        {
            return Producto.ObtenerProductos();
        }
        public int CrearPoducto(string nombre, decimal precio, int cantidad, string tipo, decimal impueto)
        {
            Producto producto = new Producto
            {
                Nombre = nombre,
                Precio = precio,
                Cantidad = cantidad,
                Tipo = tipo,
                Impuesto = impueto
            };
            return producto.Guardar();
        }
        public int ActualizarPoducto(int id,string nombre, decimal precio, int cantidad, string tipo, decimal impueto)
        {
            Producto producto = new Producto
            {
                Id = id,
                Nombre = nombre,
                Precio = precio,
                Cantidad = cantidad,
                Tipo = tipo,
                Impuesto = impueto
            };
            return producto.Actualizar();
        }
        public int EliminarProducto(int id)
        {
            return Producto.Eliminar(id);
        }
    }
}
