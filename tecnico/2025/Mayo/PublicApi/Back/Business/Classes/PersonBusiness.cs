
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Data.Interfases;
using Entity.DTOs;
using Entity.DTOs.Create;
using Entity.Models;
using Microsoft.Extensions.Logging;

namespace Business.Classes
{
    public class PersonBusiness : BusinessBase<Person, PersonDto, PersonCreate>
    {

        public PersonBusiness(ICrudBase<Person> data, ILogger<Person> logger, IMapper mapper) : base(data, logger, mapper)
        {
        
        }

        protected override void Validate(PersonCreate person)
        {
            if (person == null)
                throw new ValidationException("la persona no puede ser nula.");

            if (string.IsNullOrWhiteSpace(person.FirstName))
                throw new ValidationException("El Primer Nombre de la persona es obligatorio.");
            if (string.IsNullOrWhiteSpace(person.LastName))
                throw new ValidationException("El Primer Apellido de la persona es obligatorio.");
            if (string.IsNullOrWhiteSpace(person.Identification))
                throw new ValidationException("El número de identificación de la persona es obligatorio.");
        }

    }
}
