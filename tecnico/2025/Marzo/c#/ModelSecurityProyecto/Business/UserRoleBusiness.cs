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
        private readonly ILogger<UserRoleBusiness> _logger;

        public UserRoleBusiness(UserRoleData userRoleData, ILogger<UserRoleBusiness> logger)
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

        public async Task<UserRoleDTO> CreateUserRoleAsync(UserRoleCreateDTO userRoleDTO)
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
                _logger.LogError(ex, $"Error al crear nuevo rol para el usuario");
                throw new ExternalServiceException("Base de datos", "Error al crear el rol para el user", ex);
            }
        }


        public async Task<UserRoleDTO> UpdateUserAsync(UserRoleCreateDTO userRoleDTO)
        {

            if (userRoleDTO.Id <= 0)
            {
                _logger.LogWarning($"Intento de actualizar un user role con ID inválido: {userRoleDTO.Id}");
                throw new ValidationException("Id", "El ID del user debe ser mayor que cero.");
            }

            try
            {
                ValidateUserRole(userRoleDTO);

                var existingUser = await _userRoleData.GetByIdAsync(userRoleDTO.Id);
                if (existingUser == null)
                {
                    _logger.LogInformation($"No se encontró ningún user role con ID: {userRoleDTO.Id}");
                    throw new EntityNotFoundException("Rol", userRoleDTO.Id);
                }

                var usereEntity = MapToEntity(userRoleDTO);

                bool updated = await _userRoleData.UpdateAsync(usereEntity);
                if (!updated)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo actualizar el user role.");
                }

                return MapToDTO(usereEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el user con ID: {userRoleDTO.Id}");
                throw new ExternalServiceException("Base de datos", $"Error al actualizar el user role con ID: {userRoleDTO.Id}", ex);
            }
        }

        /// <summary>
        /// Realiza una eliminación lógica de un user.
        /// </summary>
        public async Task<bool> SoftDeleteUserAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Intento de eliminación lógica con ID inválido: {id}");
                throw new ValidationException("id", "El ID del user debe ser mayor que cero.");
            }

            try
            {
                var existingUser = await _userRoleData.GetByIdAsync(id);
                if (existingUser == null)
                {
                    _logger.LogInformation($"No se encontró ningún user con ID: {id}");
                    throw new EntityNotFoundException("Rol", id);
                }

                bool deleted = await _userRoleData.SoftDeleteAsync(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo realizar la eliminación lógica del user rol.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar lógicamente el user con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar lógicamente el user rol con ID: {id}", ex);
            }
        }

        /// <summary>
        /// Realiza una eliminación permanente de un user.
        /// </summary>
        public async Task<bool> HardDeleteUserAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Intento de eliminación permanente con ID inválido: {id}");
                throw new ValidationException("id", "El ID del user debe ser mayor que cero.");
            }

            try
            {
                var existingUser = await _userRoleData.GetByIdAsync(id);
                if (existingUser == null)
                {
                    _logger.LogInformation($"No se encontró ningún user rol con ID: {id}");
                    throw new EntityNotFoundException("Rol", id);
                }

                bool deleted = await _userRoleData.HardDeleteAsync(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo eliminar permanentemente el user rol.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar permanentemente el user con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar permanentemente el user rol con ID: {id}", ex);
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


        private void ValidateUserRole(UserRoleCreateDTO userRoleCreateDTO)
        {
            if (userRoleCreateDTO == null)
            {
                throw new ValidationException("El objeto user no puede ser nulo.");
            }
        }


        private UserRoleDTO MapToDTO(UserRole userROle)
        {
            return new UserRoleDTO
            {
                Id = userROle.Id,
                RoleId = userROle.RoleId,
                UserId = userROle.UserId,
                RoleName = userROle.Role?.Name ?? "",
                UserName = userROle.User?.Username ?? ""
            };
        }

        private UserRole MapToEntity(UserRoleDTO userRoleDTO)
        {
            return new UserRole
            {
                Id = userRoleDTO.Id,
                RoleId = userRoleDTO.RoleId,
                UserId = userRoleDTO.UserId,
            };
        }

        private UserRole MapToEntity(UserRoleCreateDTO userRoleCreateDTO)
        {
            return new UserRole
            {
                Id = userRoleCreateDTO.Id,
                RoleId = userRoleCreateDTO.RoleId,
                UserId = userRoleCreateDTO.UserId,
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
