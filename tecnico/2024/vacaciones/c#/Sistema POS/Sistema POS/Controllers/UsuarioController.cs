using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_POS.Models;

namespace Sistema_POS.Controllers
{
    internal class UsuarioController
    {
        public DataTable listarUsuarios()
        {
            return Usuario.ObtenerUsuarios();
        }
        public int CrearUsuario(string nombre, string correo, string direccion, string telefono)
        {
            Usuario usuario = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                Direccion = direccion,
                Telefono = telefono
            };
            return usuario.Guardar();
        }
        public int ActualizarUsuario(int id, string nombre, string correo, string direccion, string telefono)
        {
            Usuario usuario = new Usuario
            {
                Id = id,
                Nombre = nombre,
                Correo = correo,
                Direccion = direccion,
                Telefono = telefono
            };
            return usuario.Actualizar();
        }
        public int EliminarUSuario(int id)
        {
            return Usuario.Eliminar(id);
        }
    }
}
