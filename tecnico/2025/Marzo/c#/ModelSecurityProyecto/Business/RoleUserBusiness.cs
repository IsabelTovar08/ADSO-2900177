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
    public class RoleUserBusiness
    {
        private readonly RoleUserData _roleUserData;
        private readonly ILogger _logger;

        public RoleUserBusiness(RoleUserData rolData, ILogger logger)
        {
            _roleUserData = rolData;
            _logger = logger;
        }

        public async Task<IEnumerable<UserRoleDTO>> GetAllUsersRolesAsync()
        {
            try
            {
                var usersRoles = await _roleUserData.GetAllAsync();
                var usersRolesDTO = new List<UserRoleDTO>();

                foreach (var rol in usersRoles)
                {
                    usersRolesDTO.Add(new UserRoleDTO
                    {
                        Id = rol.Id,
                        Name = rol.Name,
                        Description = rol.Description,
                        Active = rol.Active
                    });
                }

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
                var userRole = await _roleUserData.GetByIdAsync(id);
                if (userRole == null)
                {
                    _logger.LogInformation($"No se encontró ningún userRole con: {id}");
                    throw new EntityNotFoundException("UserRole", id);
                }
                return new UserRoleDTO
                {
                    Id = userRole.Id,
                    Name = userRole.Name,
                    Description = userRole.Description,
                    Active = userRole.Active
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el userRole con ID: {id} ", ex);

            }
        }

        public async Task<UserRoleDTO> CreateUserRoleAsync(UserRoleDTO roleDTO)
        {
            try
            {
                ValidateUserRole(roleDTO);

                var userRole = new Role
                {
                    Name = roleDTO.Name,
                    Description = roleDTO.Description,
                    Active = roleDTO.Active
                };

                var UserRolCreado = await _roleUserData.CreateAsync(userRole);

                return new UserRoleDTO
                {
                    Id = rol.Id,
                    Name = rol.Name,
                    Description = rol.Description,
                    Active = rol.Active
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo rol: {roleDTO?.Name ?? "null"}");
                throw new ExternalServiceException("Base de datos", "Error al crear el rol", ex);
            }
        }

        private void ValidateUserRole(UserRoleDTO roleDTO)
        {
            if (roleDTO == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto rol no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(roleDTO.Name))
            {
                _logger.LogWarning("Se intentó crear/actualizar un rol con nombre vacío.");
                throw new Utilities.Exceptions.ValidationException("Name", "El nombre del rol es onbigatorio");
            }
        }


        private UserRoleDTO MapToDTO(Role role)
        {
            return new UserRoleDTO
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description // Si existe en la entidad
            };
        }

        // Método para mapear de RolDTO a Rol
        private Role MapToEntity(UserRoleDTO rolDTO)
        {
            return new Role
            {
                Id = rolDTO.Id,
                Name = rolDTO.Name,
                Description = rolDTO.Description // Si existe en la entidad
            };
        }

        // Método para mapear una lista de Rol a una lista de RolDTO
        private IEnumerable<UserRoleDTO> MapToDTOList(IEnumerable<Role> usersRoles)
        {
            var usersRolesDTO = new List<UserRoleDTO>();
            foreach (var rol in usersRoles)
            {
                usersRolesDTO.Add(MapToDTO(rol));
            }
            return usersRolesDTO;
        }
    }
}
