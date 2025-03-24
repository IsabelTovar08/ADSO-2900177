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
    public class UserBusiness
    {
        private readonly UserData _userData;
        private readonly ILogger _logger;

        public UserBusiness(UserData userData, ILogger logger)
        {
            _userData = userData;
            _logger = logger;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userData.GetAllAsync();
                var usersDTO = new List<UserDTO>();

                foreach (var user in users)
                {
                    usersDTO.Add(new UserDTO
                    {
                        Id = user.Id,
                        Username = user.Username,
                        PersonId = user.PersonId,
                    });
                }

                return usersDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los users.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de users", ex);
            }
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Se intentó obtener un user con ID inválido: {id}");
                throw new Utilities.Exceptions.ValidationException("id", "El id del user debe ser mayor que cero.");
            }
            try
            {
                var user = await _userData.GetByIdAsync(id);
                if (user == null)
                {
                    _logger.LogInformation($"No se encontró ningún user con: {id}");
                    throw new EntityNotFoundException("User: ", id);
                }
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.Username,
                    PersonId = user.PersonId
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el user con ID: {id} ", ex);

            }
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            try
            {
                ValidateUser(userDTO);

                var user = new User
                {
                    Username = userDTO.Username,
                    PersonId = userDTO.PersonId
                };

                var userCreado = await _userData.CreateAsync(user);

                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.Username,
                    PersonId = user.PersonId
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo user: {userDTO?.Username ?? "null"}");
                throw new ExternalServiceException("Base de datos", "Error al crear el user", ex);
            }
        }

        private void ValidateUser(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto user no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(userDTO.Username))
            {
                _logger.LogWarning("Se intentó crear/actualizar un user con nombre vacío.");
                throw new Utilities.Exceptions.ValidationException("Username", "El nombre del user es onbigatorio");
            }
        }


        private UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                PersonId = user.PersonId 
            };
        }

        // Método para mapear de UserDTO a User
        private User MapToEntity(UserDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                Username = userDTO.Username,
                PersonId = userDTO.PersonId 
            };
        }

        // Método para mapear una lista de User a una lista de UserDTO
        private IEnumerable<UserDTO> MapToDTOList(IEnumerable<User> users)
        {
            var usersDTO = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDTO.Add(MapToDTO(user));
            }
            return usersDTO;
        }
    }
}
