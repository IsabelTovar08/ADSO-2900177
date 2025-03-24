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
        private readonly ILogger _logger;

        public PersonBusiness(PersonData personData, ILogger logger)
        {
            _personData = personData;
            _logger = logger;
        }

        public async Task<IEnumerable<PersonDTO>> GetAllPeopleAsync()
        {
            try
            {
                var people = await _personData.GetAllAsync();
                var peopleDTO = new List<PersonDTO>();

                foreach (var person in people)
                {
                    peopleDTO.Add(new PersonDTO
                    {
                        Id = person.Id,
                        FirstName = person.FirstName,
                        MiddleName = person.MiddleName,
                        LastName = person.LastName,
                        SecondLastName = person.SecondLastName,
                        DocumentType = person.DocumentType,
                        DocumentNumber = person.DocumentNumber,
                        Email = person.Email,
                        PhoneNumber = person.PhoneNumber,
                        Address = person.Address,
                        BlodType = person.BlodType,
                        Photo = person.Photo,
                        CityId = person.CityId,
                        AssignmentId = person.AssignmentId
                    });
                }

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
                return new PersonDTO
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    MiddleName = person.MiddleName,
                    LastName = person.LastName,
                    SecondLastName = person.SecondLastName,
                    DocumentType = person.DocumentType,
                    DocumentNumber = person.DocumentNumber,
                    Email = person.Email,
                    PhoneNumber = person.PhoneNumber,
                    Address = person.Address,
                    BlodType = person.BlodType,
                    Photo = person.Photo,
                    CityId = person.CityId,
                    AssignmentId = person.AssignmentId
                };
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

                var person = new Person
                {
                    FirstName = personDTO.FirstName,
                    MiddleName = personDTO.MiddleName,
                    LastName = personDTO.LastName,
                    SecondLastName = personDTO.SecondLastName,
                    DocumentType = personDTO.DocumentType,
                    DocumentNumber = personDTO.DocumentNumber,
                    Email = personDTO.Email,
                    PhoneNumber = personDTO.PhoneNumber,
                    Address = personDTO.Address,
                    BlodType = personDTO.BlodType,
                    Photo = personDTO.Photo,
                    CityId = personDTO.CityId,
                    AssignmentId = personDTO.AssignmentId
                };

                var personCreado = await _personData.CreateAsync(person);

                return new PersonDTO
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    MiddleName = person.MiddleName,
                    LastName = person.LastName,
                    SecondLastName = person.SecondLastName,
                    DocumentType = person.DocumentType,
                    DocumentNumber = person.DocumentNumber,
                    Email = person.Email,
                    PhoneNumber = person.PhoneNumber,
                    Address = person.Address,
                    BlodType = person.BlodType,
                    Photo = person.Photo,
                    CityId = person.CityId,
                    AssignmentId = person.AssignmentId
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo person: {personDTO?.FirstName ?? "null"}");
                throw new ExternalServiceException("Base de datos", "Error al crear el person", ex);
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
                DocumentType = person.DocumentType,
                DocumentNumber = person.DocumentNumber,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                Address = person.Address,
                BlodType = person.BlodType,
                Photo = person.Photo,
                CityId = person.CityId,
                AssignmentId = person.AssignmentId
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
                DocumentType = personDTO.DocumentType,
                DocumentNumber = personDTO.DocumentNumber,
                Email = personDTO.Email,
                PhoneNumber = personDTO.PhoneNumber,
                Address = personDTO.Address,
                BlodType = personDTO.BlodType,
                Photo = personDTO.Photo,
                CityId = personDTO.CityId,
                AssignmentId = personDTO.AssignmentId
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
