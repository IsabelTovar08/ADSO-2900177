﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.factories;
using Data.repositories.Global;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;

namespace Business.services
{
    public class UserRolBusiness : GenericBusiness<UserRol, UserRolDto>
    {
        private readonly UserRolData _dataUserRol;
        public UserRolBusiness
            (IDataFactoryGlobal factory, ILogger<UserRol> logger, IMapper mapper, UserRolData dataUserRol) : base(factory.CreateUserRolData(), logger, mapper)
        {
            _dataUserRol = dataUserRol;
        }

        protected override void Validate(UserRolDto userRolDto)
        {
            if (userRolDto == null)
                throw new ValidationException("El formulario no puede ser nulo.");

            //if (string.IsNullOrWhiteSpace(userRolDto.Name))
            //    throw new ValidationException("El título del formulario es obligatorio.");

            // Agrega más validaciones si necesitas
        }

        protected void Validate(UserRolCreateDto userRolDto)
        {
            if (userRolDto == null)
                throw new ValidationException("El formulario no puede ser nulo.");

            //if (string.IsNullOrWhiteSpace(userRolDto.Name))
            //    throw new ValidationException("El título del formulario es obligatorio.");

            // Agrega más validaciones si necesitas
        }

        public async Task<UserRolCreateDto> CreateAsyncNew(UserRolCreateDto dtoExp)
        {
            try
            {
                Validate(dtoExp);
                var entity = _mapper.Map<UserRol>(dtoExp);
                var created = await _data.CreateAsync(entity);
                return _mapper.Map<UserRolCreateDto>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear el UserRol {dtoExp.Id}");
                throw new ExternalServiceException("Base de datos", $"Error al crear {dtoExp.Id}", ex);
            }
        }

        public async Task<UserRolCreateDto> UpdateNew(UserRolCreateDto dtoExp)
        {
            if (dtoExp == null)
                throw new ValidationException("Entidad", $"{dtoExp.Id} no puede ser nulo");

            try
            {
                Validate(dtoExp);


                if (dtoExp.Id == null || dtoExp.Id <= 0)
                    throw new ValidationException("Id", "El ID debe ser mayor que cero");

                var entity = _mapper.Map<UserRol>(dtoExp);
                var updated = await _data.UpdateAsync(entity);

                if (!updated)
                    throw new ExternalServiceException("Base de datos", $"No se pudo actualizar {dtoExp.Id}");

                return dtoExp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar {dtoExp.Id}");
                throw new ExternalServiceException("Base de datos", $"Error al actualizar {dtoExp.Id}", ex);
            }
        }

        public async Task<List<string>> GetRolesByUserId(int id)
        {
            if (id == null)
                throw new ValidationException("UserRol", $"{id} no puede ser nulo");

            try
            {

                if (id == null || id <= 0)
                    throw new ValidationException("Id", "El ID debe ser mayor que cero");

                var roles = await _dataUserRol.GetRolesByUserIdAsync(id);

                return roles;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener la lista de roles para el usuario con id: {id}");
                throw;
            }
        }
    }
}
