using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseConnectionSpace;

namespace Sistema_POS.Models
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Tipo { get; set; }
        public decimal Impuesto { get; set; }

        public static DataTable ObtenerProductos()
        {
            DataBaseConnection db = DataBaseConnection.GetInstance();
            string query = "SELECT * FROM Productos;";
            return db.ExecuteQuery(query);
        }

        public int Guardar()
        {
            DataBaseConnection db = DataBaseConnection.GetInstance();
            string query = $"INSERT INTO Productos (nombre, precio, cantidad, tipo, impuesto) VALUES ('{Nombre}', {Precio}, {Cantidad}, '{Tipo}', {Impuesto});";
            return db.ExecuteNonQuery(query);
        }
        public int Actualizar()
        {
            DataBaseConnection db = DataBaseConnection.GetInstance();
            string query = $"UPDATE Productos SET nombre = '{Nombre}', precio = {Precio}, cantidad = {Cantidad}, tipo = '{Tipo}', impuesto = {Impuesto}  WHERE id = {Id};";
            return db.ExecuteNonQuery(query);
        }
        public static int Eliminar(int id)
        {
            DataBaseConnection db = DataBaseConnection.GetInstance();
            string query = $"DELETE FROM Productos WHERE id = {id};";
            return db.ExecuteNonQuery(query);
        }
    }
}
