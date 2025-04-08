using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Data;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business
{
    /// <summary>
    /// Clase para gestionar la lógica de negocio de los roles.
    /// </summary>
    public class RolBusiness
    {
        private readonly RolData _rolData;
        private readonly ILogger<RolBusiness> _logger;

        /// <summary>
        /// Constructor de la clase RolBusiness.
        /// </summary>
        public RolBusiness(RolData rolData, ILogger<RolBusiness> logger)
        {
            _rolData = rolData;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los roles.
        /// </summary>
        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            try
            {
                var roles = await _rolData.GetAllAsyncSQL();
                //var rolesDTO = new List<RoleDTO>();
                var rolesDTO = MapToDTOList(roles);

                return rolesDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los roles.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de roles", ex);
            }
        }

        /// <summary>
        /// Obtiene un rol por su ID.
        /// </summary>
        public async Task<RoleDTO> GetRoleByIdAsync(int id)
        {
            if(id <= 0)
            {
                _logger.LogWarning($"Se intentó obtener un rol con ID inválido: {id}");
                throw new Utilities.Exceptions.ValidationException("id", "El id del rol debe ser mayor que cero.");
            }
            try
            {
                var rol = await _rolData.GetByIdAsyncSQL(id);
                if (rol == null)
                {
                    _logger.LogInformation($"No se encontró ningún rol con: {id}");
                    throw new EntityNotFoundException("Rol", id);
                }
                return MapToDTO(rol);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el rol con ID: {id} ", ex);

            }
        }

        /// <summary>
        /// Crea un nuevo rol.
        /// </summary>
        public async Task<RoleDTO> CreateRoleAsync(RoleDTO roleDTO)
        {
            try
            {
                ValidateRol(roleDTO);

                var rol = MapToEntity(roleDTO);

                var rolCreado = await _rolData.CreateAsync(rol);

                return MapToDTO(rolCreado);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo rol: {roleDTO?.Name ?? "null"}");
                throw new ExternalServiceException("Base de datos", "Error al crear el rol", ex);
            }
        }

        /// <summary>
        /// Actualiza un rol existente.
        /// </summary>
        public async Task<RoleDTO> UpdateRoleAsync(RoleDTO roleDTO)
        {
      
            if (roleDTO.Id <= 0)
            {
                _logger.LogWarning($"Intento de actualizar un rol con ID inválido: {roleDTO.Id}");
                throw new ValidationException("Id", "El ID del rol debe ser mayor que cero.");
            }

            try
            {
                ValidateRol(roleDTO);

                var existingRole = await _rolData.GetByIdAsyncSQL(roleDTO.Id);
                if (existingRole == null)
                {
                    _logger.LogInformation($"No se encontró ningún rol con ID: {roleDTO.Id}");
                    throw new EntityNotFoundException("Rol", roleDTO.Id);
                }

                var roleEntity = MapToEntity(roleDTO);

                bool updated = await _rolData.UpdateAsync(roleEntity);
                if (!updated)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo actualizar el rol.");
                }

                return MapToDTO(roleEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el rol con ID: {roleDTO.Id}");
                throw new ExternalServiceException("Base de datos", $"Error al actualizar el rol con ID: {roleDTO.Id}", ex);
            }
        }

        /// <summary>
        /// Realiza una eliminación lógica de un rol.
        /// </summary>
        public async Task<bool> SoftDeleteRoleAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Intento de eliminación lógica con ID inválido: {id}");
                throw new ValidationException("id", "El ID del rol debe ser mayor que cero.");
            }

            try
            {
                var existingRole = await _rolData.GetByIdAsyncSQL(id);
                if (existingRole == null)
                {
                    _logger.LogInformation($"No se encontró ningún rol con ID: {id}");
                    throw new EntityNotFoundException("Rol", id);
                }

                bool deleted = await _rolData.SoftDeleteAsync(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo realizar la eliminación lógica del rol.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar lógicamente el rol con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar lógicamente el rol con ID: {id}", ex);
            }
        }

        /// <summary>
        /// Realiza una eliminación permanente de un rol.
        /// </summary>
        public async Task<bool> HardDeleteRoleAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Intento de eliminación permanente con ID inválido: {id}");
                throw new ValidationException("id", "El ID del rol debe ser mayor que cero.");
            }

            try
            {
                var existingRole = await _rolData.GetByIdAsyncSQL(id);
                if (existingRole == null)
                {
                    _logger.LogInformation($"No se encontró ningún rol con ID: {id}");
                    throw new EntityNotFoundException("Rol", id);
                }

                bool deleted = await _rolData.HardDeleteAsync(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo eliminar permanentemente el rol.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar permanentemente el rol con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar permanentemente el rol con ID: {id}", ex);
            }
        }

        private void ValidateRol(RoleDTO roleDTO)
        {
            if(roleDTO == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto rol no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(roleDTO.Name))
            {
                _logger.LogWarning("Se intentó crear/actualizar un rol con nombre vacío.");
                throw new Utilities.Exceptions.ValidationException("Name", "El nombre del rol es onbigatorio");
            }
        }

        // Método para mapear de Rol a RolDTO
        private RoleDTO MapToDTO(Role role)
        {
            return new RoleDTO
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description // Si existe en la entidad
                
            };
        }

        // Método para mapear de RolDTO a Rol
        private Role MapToEntity(RoleDTO rolDTO)
        {
            return new Role
            {
                Id = rolDTO.Id,
                Name = rolDTO.Name,
                Description = rolDTO.Description, // Si existe en la entidad
                //Status = 
            };
        }

        // Método para mapear una lista de Rol a una lista de RolDTO
        private IEnumerable<RoleDTO> MapToDTOList(IEnumerable<Role> roles)
        {
            var rolesDTO = new List<RoleDTO>();
            foreach (var rol in roles)
            {
                rolesDTO.Add(MapToDTO(rol));
            }
            return rolesDTO;
        }

    }
}
