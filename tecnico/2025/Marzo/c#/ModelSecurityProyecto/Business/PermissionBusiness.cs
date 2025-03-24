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
        private readonly ILogger _logger;

        public PermissionBusiness(PermissionData permissionData, ILogger logger)
        {
            _PermissionData = permissionData;
            _logger = logger;
        }

        public async Task<IEnumerable<PermissionDTO>> GetAllPermissionsAsync()
        {
            try
            {
                var permissions = await _PermissionData.GetAllAsync();
                var permissionsDTO = new List<PermissionDTO>();

                foreach (var permission in permissions)
                {
                    permissionsDTO.Add(new PermissionDTO
                    {
                        Id = permission.Id,
                        Name = permission.Name,
                        Description = permission.Description
                    });
                }

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
                    throw new EntityNotFoundException("Formulario", id);
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

        private void ValidatePermission(PermissionDTO permissionDTO)
        {
            if (permissionDTO == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto permission no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(permissionDTO.Name))
            {
                _logger.LogWarning("Se intentó crear/actualizar un permission con nombre vacío.");
                throw new Utilities.Exceptions.ValidationException("Name", "El nombre del permiso es onbigatorio");
            }
        }

        private Permission MapToDTO(Permission permission)
        {
            return new Permission
            {
                Id = permission.Id,
                Name = permission.Name,
                Description = permission.Description
            };
        }

        // Método para mapear de Permission a Permission
        private Permission MapToEntity(Permission permission)
        {
            return new Permission
            {
                Id = permission.Id,
                Name = permission.Name,
                Description = permission.Description
            };
        }

        // Método para mapear una lista de Permission a una lista de Permission
        private IEnumerable<Permission> MapToDTOList(IEnumerable<Permission> permissions)
        {
            var permissionsDTO = new List<Permission>();
            foreach (var user in permissions)
            {
                permissionsDTO.Add(MapToDTO(user));
            }
            return permissionsDTO;
        }
    }
}
