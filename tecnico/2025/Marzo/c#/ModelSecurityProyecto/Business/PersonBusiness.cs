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
    public class PersonBusiness
    {
        private readonly PersonData _personData;
        private readonly ILogger<PersonBusiness> _logger;

        public PersonBusiness(PersonData personData, ILogger<PersonBusiness> logger)
        {
            _personData = personData;
            _logger = logger;
        }

        public async Task<IEnumerable<PersonDTO>> GetAllPeopleAsync()
        {
            try
            {
                var people = await _personData.GetAllAsync();
                var peopleDTO = MapToDTOList(people);

                return peopleDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los people.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de people", ex);
            }
        }

        public async Task<PersonDTO> GetPersonByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Se intentó obtener un person con ID inválido: {id}");
                throw new Utilities.Exceptions.ValidationException("id", "El id del person debe ser mayor que cero.");
            }
            try
            {
                var person = await _personData.GetByIdAsync(id);
                if (person == null)
                {
                    _logger.LogInformation($"No se encontró ningún person con: {id}");
                    throw new EntityNotFoundException("Person: ", id);
                }
                return MapToDTO(person);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el person con ID: {id} ", ex);

            }
        }

        public async Task<PersonDTO> CreatePersonAsync(PersonDTO personDTO)
        {
            try
            {
                ValidatePerson(personDTO);

                var person = MapToEntity(personDTO);

                var personCreado = await _personData.CreateAsync(person);

                return MapToDTO(personCreado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo person: {personDTO?.FirstName ?? "null"}");
                throw new ExternalServiceException("Base de datos", "Error al crear el person", ex);
            }
        }

        /// <summary>
        /// Actualiza un persona existente.
        /// </summary>
        public async Task<PersonDTO> UpdatePersonAsync(PersonDTO personDTO)
        {

            if (personDTO.Id <= 0)
            {
                _logger.LogWarning($"Intento de actualizar una persona con ID inválido: {personDTO.Id}");
                throw new ValidationException("Id", "El ID del persona debe ser mayor que cero.");
            }

            try
            {
                ValidatePerson(personDTO);

                var existingPerson = await _personData.GetByIdAsync(personDTO.Id);
                if (existingPerson == null)
                {
                    _logger.LogInformation($"No se encontró ningún persona con ID: {personDTO.Id}");
                    throw new EntityNotFoundException("Rol", personDTO.Id);
                }

                var personEntity = MapToEntity(personDTO);

                bool updated = await _personData.UpdateAsync(personEntity);
                if (!updated)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo actualizar la persona.");
                }

                return MapToDTO(personEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el persona con ID: {personDTO.Id}");
                throw new ExternalServiceException("Base de datos", $"Error al actualizar el persona con ID: {personDTO.Id}", ex);
            }
        }

        /// <summary>
        /// Realiza una eliminación lógica de un persona.
        /// </summary>
        public async Task<bool> SoftDeletePersonAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Intento de eliminación lógica con ID inválido: {id}");
                throw new ValidationException("id", "El ID del persona debe ser mayor que cero.");
            }

            try
            {
                var existingPerson = await _personData.GetByIdAsync(id);
                if (existingPerson == null)
                {
                    _logger.LogInformation($"No se encontró ningún persona con ID: {id}");
                    throw new EntityNotFoundException("Rol", id);
                }

                bool deleted = await _personData.SoftDeleteAsync(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo realizar la eliminación lógica del persona.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar lógicamente el persona con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar lógicamente el persona con ID: {id}", ex);
            }
        }

        /// <summary>
        /// Realiza una eliminación permanente de un persona.
        /// </summary>
        public async Task<bool> HardDeletePersonAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Intento de eliminación permanente con ID inválido: {id}");
                throw new ValidationException("id", "El ID del persona debe ser mayor que cero.");
            }

            try
            {
                var existingPerson = await _personData.GetByIdAsync(id);
                if (existingPerson == null)
                {
                    _logger.LogInformation($"No se encontró ningún persona con ID: {id}");
                    throw new EntityNotFoundException("Rol", id);
                }

                bool deleted = await _personData.HardDeleteAsync(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo eliminar permanentemente el persona.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar permanentemente el persona con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar permanentemente el persona con ID: {id}", ex);
            }
        }

        private void ValidatePerson(PersonDTO personDTO)
        {
            if (personDTO == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto person no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(personDTO.FirstName))
            {
                _logger.LogWarning("Se intentó crear/actualizar un person con nombre vacío.");
                throw new Utilities.Exceptions.ValidationException("FirstName", "El nombre del person es onbigatorio");
            }
        }


        private PersonDTO MapToDTO(Person person)
        {
            return new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                LastName = person.LastName,
                SecondLastName = person.SecondLastName,
                //DocumentTypeId = person.DocumentTypeId,
                DocumentNumber = person.DocumentNumber,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                Address = person.Address,
                BlodType = person.BlodType,
                Photo = person.Photo,
                //CityId = person.CityId,
                //AssignmentId = person.AssignmentId
            };
        }

        // Método para mapear de PersonDTO a Person
        private Person MapToEntity(PersonDTO personDTO)
        {
            return new Person
            {
                Id = personDTO.Id,
                FirstName = personDTO.FirstName,
                MiddleName = personDTO.MiddleName,
                LastName = personDTO.LastName,
                SecondLastName = personDTO.SecondLastName,
                //DocumentTypeId = personDTO.DocumentTypeId,
                DocumentNumber = personDTO.DocumentNumber,
                Email = personDTO.Email,
                PhoneNumber = personDTO.PhoneNumber,
                Address = personDTO.Address,
                BlodType = personDTO.BlodType,
                Photo = personDTO.Photo,
                //CityId = personDTO.CityId,
                //AssignmentId = personDTO.AssignmentId
            };
        }

        // Método para mapear una lista de Person a una lista de PersonDTO
        private IEnumerable<PersonDTO> MapToDTOList(IEnumerable<Person> people)
        {
            var peopleDTO = new List<PersonDTO>();
            foreach (var person in people)
            {
                peopleDTO.Add(MapToDTO(person));
            }
            return peopleDTO;
        }
    }
}
