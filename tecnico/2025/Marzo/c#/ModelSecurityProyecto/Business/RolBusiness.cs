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
    public class RolBusiness
    {
        private readonly RolData _rolData;
        private readonly ILogger _logger;

        public RolBusiness(RolData rolData, ILogger logger)
        {
            _rolData = rolData;
            _logger = logger;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            try
            {
                var roles = await _rolData.GetAllAsync();
                var rolesDTO = new List<RoleDTO>();

                foreach (var rol in roles)
                {
                    rolesDTO.Add(new RoleDTO
                    {
                        Id = rol.Id,
                        Name = rol.Name,
                        Description = rol.Description,
                        Active = rol.Active
                    });
                }

                return rolesDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los roles.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de roles", ex);
            }
        }

        public async Task<RoleDTO> GetRoleByIdAsync(int id)
        {
            if(id <= 0)
            {
                _logger.LogWarning($"Se intentó obtener un rol con ID inválido: {id}");
                throw new Utilities.Exceptions.ValidationException("id", "El id del rol debe ser mayor que cero.");
            }
            try
            {
                var rol = await _rolData.GetByIdAsync(id);
                if (rol == null)
                {
                    _logger.LogInformation($"No se encontró ningún rol con: {id}");
                    throw new EntityNotFoundException("Rol", id);
                }
                return new RoleDTO
                {
                    Id = rol.Id,
                    Name = rol.Name,
                    Description = rol.Description,
                    Active = rol.Active
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el rol con ID: {id} ", ex);

            }
        }

        public async Task<RoleDTO> CreateRoleAsync(RoleDTO roleDTO)
        {
            try
            {
                ValidateRol(roleDTO);

                var rol = new Role
                {
                    Name = roleDTO.Name,
                    Description = roleDTO.Description,
                    Active = roleDTO.Active
                };

                var rolCreado = await _rolData.CreateAsync(rol);

                return new RoleDTO
                {
                    Id = rol.Id,
                    Name = rol.Name,
                    Description = rol.Description,
                    Active = rol.Active
                };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo rol: {roleDTO?.Name ?? "null"}");
                throw new ExternalServiceException("Base de datos", "Error al crear el rol", ex);
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
                Description = rolDTO.Description // Si existe en la entidad
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
