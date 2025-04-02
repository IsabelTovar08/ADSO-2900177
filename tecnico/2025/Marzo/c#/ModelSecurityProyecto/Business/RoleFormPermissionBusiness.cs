using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business
{
    public class RoleFormPermissionBusiness
    {
        private readonly RoleFormPermissionData _RoleFormPermissionData;
        private readonly ILogger _logger;
        public RoleFormPermissionBusiness(RoleFormPermissionData roleFormPermissionData, ILogger logger)
        {
            _RoleFormPermissionData = roleFormPermissionData;
            _logger = logger;
        }

        public async Task<IEnumerable<RoleFormPermissionDTO>> GetAllRoleFormPermissionsAsync()
        {
            try
            {
                var roleFormPermissions = await _RoleFormPermissionData.GetAllAsync();
                return MapToDTOList(roleFormPermissions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los permisos por formulario para cada rol.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de permisos por formulario para cada rol.", ex);
            }
        }

        public async Task<RoleFormPermissionDTO> GetRoleFormPermissionByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Se intentó obtener un permiso por formulario para cada rol con ID inválido: {id}");
                throw new Utilities.Exceptions.ValidationException("id", "El id del permiso por formulario para cada rol debe ser mayor que cero.");
            }
            try
            {
                var roleFormPermission = await _RoleFormPermissionData.GetByIdAsync(id);
                if (roleFormPermission == null)
                {
                    _logger.LogInformation($"No se encontró ningún permiso por formulario para cada rol con: {id}");
                    throw new EntityNotFoundException("Permiso por formulario para cada rol", id);
                }
                return MapToDTO(roleFormPermission);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el permiso por formulario para cada rol con ID: {id} ", ex);

            }
        }

        public async Task<RoleFormPermissionDTO> CreateRoleFormPermissionAsync(RoleFormPermissionDTO roleFormPermissionDTO)
        {
            try
            {
                ValidateForm(roleFormPermissionDTO);

                var roleFormPermission = MapToEntity(roleFormPermissionDTO);

                var roleFormPermissionCreado = await _RoleFormPermissionData.CreateAsync(roleFormPermission);

                return MapToDTO(roleFormPermissionCreado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo permiso por formulario para cada rol: {roleFormPermissionDTO?.FormName ?? "null"}");
                throw new ExternalServiceException("Base de datos", "Error al crear el permiso por formulario para cada rol", ex);
            }
        }

        private void ValidateForm(RoleFormPermissionDTO roleFormPermissionDTO)
        {
            if (roleFormPermissionDTO == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto permiso por formulario para cada rol no puede ser nulo.");
            }

            //if (string.IsNullOrWhiteSpace(roleFormPermissionDTO.Name))
            //{
            //    _logger.LogWarning("Se intentó crear/actualizar un form con nombre vacío.");
            //    throw new Utilities.Exceptions.ValidationException("Name", "El nombre del formulario es onbigatorio");
            //}
        }

        private RoleFormPermissionDTO MapToDTO(RoleFormPermission roleFormPermission)
        {
            return new RoleFormPermissionDTO
            {
                Id = roleFormPermission.Id,
                RoleId = roleFormPermission.RoleId,
                RoleName = roleFormPermission.Role.Name,
                FormId = roleFormPermission.FormId,
                FormName = roleFormPermission.Form.Name,
                PermissionId = roleFormPermission.PermissionId,
                PermissionName = roleFormPermission.Permission.Name
            };
        }

        // Método para mapear de RoleFormPermissionDTO a Form
        private RoleFormPermission MapToEntity(RoleFormPermissionDTO roleFormPermissionDTO)
        {
            return new RoleFormPermission
            {
                RoleId = roleFormPermissionDTO.RoleId,
                FormId = roleFormPermissionDTO.FormId,
                PermissionId = roleFormPermissionDTO.PermissionId,
            };
        }

        // Método para mapear una lista de Form a una lista de RoleFormPermissionDTO
        private IEnumerable<RoleFormPermissionDTO> MapToDTOList(IEnumerable<RoleFormPermission> roleFormPErmissions)
        {
            var roleFormPErmissionsDTO = new List<RoleFormPermissionDTO>();
            foreach (var roleFormPermission in roleFormPErmissions)
            {
                roleFormPErmissionsDTO.Add(MapToDTO(roleFormPermission));
            }
            return roleFormPErmissionsDTO;
        }
    }
}
