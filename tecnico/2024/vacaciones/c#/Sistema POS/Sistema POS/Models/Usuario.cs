using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseConnectionSpace;

namespace Sistema_POS.Models
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public static DataTable ObtenerUsuarios()
        {
            DataBaseConnection db = DataBaseConnection.GetInstance();
            string query = "SELECT * FROM Usuarios;";
            return db.ExecuteQuery(query);
        }

        public int Guardar()
        {
            DataBaseConnection db = DataBaseConnection.GetInstance();
            string query = $"INSERT INTO Usuarios (nombre, correo, direccion, telefono) VALUES ('{Nombre}', {Correo}, {Direccion}, '{Telefono}');";
            return db.ExecuteNonQuery(query);
        }
        public int Actualizar()
        {
            DataBaseConnection db = DataBaseConnection.GetInstance();
            string query = $"UPDATE Usuarios SET nombre = '{Nombre}', correo = {Correo}, direccion = {Direccion}, telefono = '{Telefono}' WHERE id = {Id};";
            return db.ExecuteNonQuery(query);
        }
        public static int Eliminar(int id)
        {
            DataBaseConnection db = DataBaseConnection.GetInstance();
            string query = $"DELETE FROM Usuarios WHERE id = {id};";
            return db.ExecuteNonQuery(query);
        }
    }
}
