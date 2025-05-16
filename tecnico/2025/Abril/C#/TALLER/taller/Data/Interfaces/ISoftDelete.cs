using System.Threading.Tasks;

namespace Data.Interfaces
{
    /// <summary>
    /// Interfaz opcional para entidades que permiten eliminación lógica.
    /// </summary>
    /// <typeparam name="T">Tipo de la entidad.</typeparam>
    public interface ISoftDelete<T> where T : class
    {
        /// <summary>
        /// Realiza una eliminación lógica de la entidad por ID.
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <returns>True si la eliminación lógica fue exitosa; false si no se encontró o no se pudo eliminar.</returns>
        Task<bool> SoftDeleteAsync(int id);
    }
}
