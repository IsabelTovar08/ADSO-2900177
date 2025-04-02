using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Utilities.Exceptions;

namespace Business
{
    public class PermissionBusiness
    {
        private readonly PermissionData _PermissionData;
        private readonly ILogger<PermissionData> _logger;

        public PermissionBusiness(PermissionData permissionData, ILogger<PermissionData> logger)
        {
            _PermissionData = permissionData;
            _logger = logger;
        }

        public async Task<IEnumerable<PermissionDTO>> GetAllPermissionsAsync()
        {
            try
            {
                var permissions = await _PermissionData.GetAllAsync();
                var permissionsDTO = MapToDTOList(permissions);
                

                return permissionsDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los permisos.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de permisos", ex);
            }
        }

        public async Task<PermissionDTO> GetPermissionByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Se intentó obtener un permiso con ID inválido: {id}");
                throw new Utilities.Exceptions.ValidationException("id", "El id del permiso debe ser mayor que cero.");
            }
            try
            {
                var permission = await _PermissionData.GetByIdAsync(id);
                if (permission == null)
                {
                    _logger.LogInformation($"No se encontró ningún permiso con: {id}");
                    throw new EntityNotFoundException("Permiso", id);
                }
                return new PermissionDTO
                {
                    Id = permission.Id,
                    Name = permission.Name,
                    Description = permission.Description
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el permiso con ID: {id} ", ex);

            }
        }

        public async Task<PermissionDTO> CreatePermissionAsync(PermissionDTO permissionDTO)
        {
            try
            {
                ValidatePermission(permissionDTO);

                var permission = new Permission
                {
                    Name = permissionDTO.Name,
                    Description = permissionDTO.Description
                };

                var permissionCreado = await _PermissionData.CreateAsync(permission);

                return new PermissionDTO
                {
                    Id = permission.Id,
                    Name = permission.Name,
                    Description = permission.Description
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo permission: {permissionDTO?.Name ?? "null"}");
                throw new ExternalServiceException("Base de datos", "Error al crear el permiso", ex);
            }
        }

        /// <summary>
        /// Actualiza un permiso existente.
        /// </summary>
        public async Task<PermissionDTO> UpdatePermissionAsync(PermissionDTO permissionDTO)
        {
            if (permissionDTO.Id <= 0)
            {
                _logger.LogWarning($"Intento de actualizar un permiso con ID inválido: {permissionDTO.Id}");
                throw new ValidationException("Id", "El ID del permiso debe ser mayor que cero.");
            }

            try
            {
                ValidatePermission(permissionDTO);

                var existingPermission = await _PermissionData.GetByIdAsync(permissionDTO.Id);
                if (existingPermission == null)
                {
                    _logger.LogInformation($"No se encontró ningún permiso con ID: {permissionDTO.Id}");
                    throw new EntityNotFoundException("Permiso", permissionDTO.Id);
                }

                var permissionEntity = MapToEntity(permissionDTO);

                bool updated = await _PermissionData.UpdateAsync(permissionEntity);
                if (!updated)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo actualizar el permiso.");
                }

                return MapToDTO(permissionEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el permiso con ID: {permissionDTO.Id}");
                throw new ExternalServiceException("Base de datos", $"Error al actualizar el permiso con ID: {permissionDTO.Id}", ex);
            }
        }

        /// <summary>
        /// Realiza una eliminación lógica de un permiso.
        /// </summary>
        public async Task<bool> SoftDeletePermissionAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Intento de eliminación lógica con ID inválido: {id}");
                throw new ValidationException("id", "El ID del permiso debe ser mayor que cero.");
            }

            try
            {
                var existingPermission = await _PermissionData.GetByIdAsync(id);
                if (existingPermission == null)
                {
                    _logger.LogInformation($"No se encontró ningún permiso con ID: {id}");
                    throw new EntityNotFoundException("Permiso", id);
                }

                bool deleted = await _PermissionData.SoftDeleteAsync(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo realizar la eliminación lógica del permiso.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar lógicamente el permiso con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar lógicamente el permiso con ID: {id}", ex);
            }
        }

        /// <summary>
        /// Realiza una eliminación permanente de un permiso.
        /// </summary>
        public async Task<bool> HardDeletePermissionAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Intento de eliminación permanente con ID inválido: {id}");
                throw new ValidationException("id", "El ID del permiso debe ser mayor que cero.");
            }

            try
            {
                var existingPermission = await _PermissionData.GetByIdAsync(id);
                if (existingPermission == null)
                {
                    _logger.LogInformation($"No se encontró ningún permiso con ID: {id}");
                    throw new EntityNotFoundException("Permiso", id);
                }

                bool deleted = await _PermissionData.HardDeleteAsync(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo eliminar permanentemente el permiso.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar permanentemente el permiso con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar permanentemente el permiso con ID: {id}", ex);
            }
        }


        private void ValidatePermission(PermissionDTO permissionDTO)
        {
            if (permissionDTO == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto permission no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(permissionDTO.Name))
            {
                _logger.LogWarning("Se intentó crear/actualizar un permission con nombre vacío.");
                throw new Utilities.Exceptions.ValidationException("Name", "El nombre del permiso es obligatorio");
            }
        }

        private PermissionDTO MapToDTO(Permission permission)
        {
            return new PermissionDTO
            {
                Id = permission.Id,
                Name = permission.Name,
                Description = permission.Description
            };
        }

        // Método para mapear de Permission a Permission
        private Permission MapToEntity(PermissionDTO permissionDTO)
        {
            return new Permission
            {
                Id = permissionDTO.Id,
                Name = permissionDTO.Name,
                Description = permissionDTO.Description
            };
        }

        // Método para mapear una lista de Permission a una lista de Permission
        private IEnumerable<PermissionDTO> MapToDTOList(IEnumerable<Permission> permissions)
        {
            var permissionsDTO = new List<PermissionDTO>();
            foreach (var permission in permissions)
            {
                permissionsDTO.Add(MapToDTO(permission));
            }
            return permissionsDTO;
        }
    }
}
