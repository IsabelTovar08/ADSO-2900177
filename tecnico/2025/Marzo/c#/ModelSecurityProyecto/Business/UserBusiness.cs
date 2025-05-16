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
        private readonly ILogger<UserBusiness> _logger;

        public UserBusiness(UserData userData, ILogger<UserBusiness> logger)
        {
            _userData = userData;
            _logger = logger;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userData.GetAllAsyncSQL();
                var usersDTO = MapToDTOList(users);

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
                var user = await _userData.GetByIdAsyncSQL(id);
                if (user == null)
                {
                    _logger.LogInformation($"No se encontró ningún user con: {id}");
                    throw new EntityNotFoundException("User: ", id);
                }
                return MapToDTO(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el user con ID: {id} ", ex);

            }
        }

        public async Task<UserFormDTO> CreateUserAsync(UserFormDTO userDTO)
        {
            try
            {
                ValidateUser(userDTO);

                var user = MapToEntity(userDTO);
                var userCreado = await _userData.CreateAsyncSQL(user);

                return new UserFormDTO
                {
                    Id = userCreado.Id,
                    Username = userCreado.Username,
                    PersonId = userCreado.PersonId
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo user.");
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

        private void ValidateUser(UserFormDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new ValidationException("El objeto user no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(userDTO.Username))
            {
                _logger.LogWarning("Se intentó crear un user con nombre vacío.");
                throw new ValidationException("Username", "El nombre del user es obligatorio");
            }

            if (string.IsNullOrWhiteSpace(userDTO.Password))
            {
                _logger.LogWarning("Se intentó crear un user sin contraseña.");
                throw new ValidationException("Password", "La contraseña es obligatoria");
            }
        }


        /// <summary>
        /// Actualiza un user existente.
        /// </summary>
        public async Task<UserDTO> UpdateUserAsync(UserFormDTO userDTO)
        {

            if (userDTO.Id <= 0)
            {
                _logger.LogWarning($"Intento de actualizar un user con ID inválido: {userDTO.Id}");
                throw new ValidationException("Id", "El ID del user debe ser mayor que cero.");
            }

            try
            {
                ValidateUser(userDTO);

                var existingUser = await _userData.GetByIdAsyncSQL(userDTO.Id);
                if (existingUser == null)
                {
                    _logger.LogInformation($"No se encontró ningún user con ID: {userDTO.Id}");
                    throw new EntityNotFoundException("Rol", userDTO.Id);
                }

                var usereEntity = MapToEntity(userDTO);

                bool updated = await _userData.UpdateAsync(usereEntity);
                if (!updated)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo actualizar el user.");
                }

                return MapToDTO(usereEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el user con ID: {userDTO.Id}");
                throw new ExternalServiceException("Base de datos", $"Error al actualizar el user con ID: {userDTO.Id}", ex);
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
                var existingUser = await _userData.GetByIdAsyncSQL(id);
                if (existingUser == null)
                {
                    _logger.LogInformation($"No se encontró ningún user con ID: {id}");
                    throw new EntityNotFoundException("Rol", id);
                }

                bool deleted = await _userData.SoftDeleteAsync(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo realizar la eliminación lógica del user.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar lógicamente el user con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar lógicamente el user con ID: {id}", ex);
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
                var existingUser = await _userData.GetByIdAsync(id);
                if (existingUser == null)
                {
                    _logger.LogInformation($"No se encontró ningún user con ID: {id}");
                    throw new EntityNotFoundException("Rol", id);
                }

                bool deleted = await _userData.HardDeleteAsyncSQL(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo eliminar permanentemente el user.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar permanentemente el user con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar permanentemente el user con ID: {id}", ex);
            }
        }


        private UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                PersonId = user.PersonId,
                PersonFirstName = user.Person?.FirstName ?? "", // Manejo de posibles valores nulos
                PersonLastName = user.Person?.LastName ?? "",
            };
        }

        private User MapToEntity(UserDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                Username = userDTO.Username,
                PersonId = userDTO.PersonId
            };
        }

        private User MapToEntity(UserFormDTO userDTO)
        {
            return new User
            {
                Username = userDTO.Username,
                Password = userDTO.Password,
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