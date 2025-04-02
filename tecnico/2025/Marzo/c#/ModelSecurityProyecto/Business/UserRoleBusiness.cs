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
    public class UserRoleBusiness
    {
        private readonly UserRoleData _userRoleData;
        private readonly ILogger _logger;

        public UserRoleBusiness(UserRoleData userRoleData, ILogger logger)
        {
            _userRoleData = userRoleData;
            _logger = logger;
        }

        public async Task<IEnumerable<UserRoleDTO>> GetAllUsersRolesAsync()
        {
            try
            {
                var usersRoles = await _userRoleData.GetAllAsync();
                var usersRolesDTO = MapToDTOList(usersRoles);
                return usersRolesDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los usersRoles.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de usersRoles", ex);
            }
        }

        public async Task<UserRoleDTO> GetUserRoleByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Se intentó obtener un userRole con ID inválido: {id}");
                throw new Utilities.Exceptions.ValidationException("id", "El id del userRole debe ser mayor que cero.");
            }
            try
            {
                var userRole = await _userRoleData.GetByIdAsync(id);
                if (userRole == null)
                {
                    _logger.LogInformation($"No se encontró ningún userRole con: {id}");
                    throw new EntityNotFoundException("UserRole", id);
                }
                return MapToDTO(userRole);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el userRole con ID: {id} ", ex);

            }
        }

        public async Task<UserRoleDTO> CreateUserRoleAsync(UserRoleDTO userRoleDTO)
        {
            try
            {
                ValidateUserRole(userRoleDTO);
                var model = MapToEntity(userRoleDTO);
                var UserRolCreado = await _userRoleData.CreateAsync(model);

                return MapToDTO(UserRolCreado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo rol para el usuario: {userRoleDTO?.UserName ?? "null"}");
                throw new ExternalServiceException("Base de datos", "Error al crear el rol", ex);
            }
        }


        private void ValidateUserRole(UserRoleDTO userRoleDTO)
        {
            if (userRoleDTO == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto user rol no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(userRoleDTO.UserName))
            {
                _logger.LogWarning("Se intentó crear/actualizar un rol con nombre vacío.");
                throw new Utilities.Exceptions.ValidationException("Name", "El nombre del rol es onbigatorio");
            }
        }


        private UserRoleDTO MapToDTO(UserRole userRole)
        {
            return new UserRoleDTO
            {
                RoleId = userRole.RoleId,
                UserName = userRole.User.Username,
                UserId = userRole.UserId,
                RoleName = userRole.Role.Name
            };
        }

        // Método para mapear de RolDTO a Rol
        private UserRole MapToEntity(UserRoleDTO userRoleDTO)
        {
            return new UserRole
            {
                RoleId = userRoleDTO.RoleId,
                UserId = userRoleDTO.UserId
            };
        }

        // Método para mapear una lista de Rol a una lista de RolDTO
        private IEnumerable<UserRoleDTO> MapToDTOList(IEnumerable<UserRole> usersRoles)
        {
            var usersRolesDTO = new List<UserRoleDTO>();
            foreach (var userRole in usersRoles)
            {
                usersRolesDTO.Add(MapToDTO(userRole));
            }
            return usersRolesDTO;
        }
    }
}
