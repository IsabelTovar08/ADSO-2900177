using System;
using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    /// <summary>
    /// Clase para la gestión de personas en la base de datos.
    /// </summary>
    public class PersonData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PersonData> _logger;

        public PersonData(ApplicationDbContext context, ILogger<PersonData> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todas las personas con LINQ.
        /// </summary>
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            try
            {
                return await _context.Set<Person>()
                    .Where(p => p.Status) // Filtra solo las personas activas
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener todas las personas activas: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las personas con SQL.
        /// </summary>
        public async Task<IEnumerable<Person>> GetAllAsyncSQL()
        {
            try
            {
                const string query = "SELECT * FROM Person WHERE Status = 1;";
                return await _context.QueryAsync<Person>(query);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener las personas activas. {ex}");
                throw;
            }
        }


        /// <summary>
        /// Obtiene una persona por ID con LINQ.
        /// </summary>
        public async Task<Person?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Person>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener la persona con ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene una persona por ID con SQL.
        /// </summary>
        public async Task<Person?> GetByIdAsyncSQL(int id)
        {
            try
            {
                const string query = "SELECT * FROM Person WHERE Id = @Id;";
                var parameters = new { Id = id };
                return await _context.QueryFirstOrDefaultAsync<Person>(query, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener la persona con ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Crea una persona con LINQ.
        /// </summary>
        public async Task<Person> CreateAsync(Person person)
        {
            try
            {
                person.Status = true; // Asegura que el estado sea true por defecto
                await _context.Set<Person>().AddAsync(person);
                await _context.SaveChangesAsync();
                return person;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear la persona: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea una persona con SQL.
        /// </summary>
        //public async Task<Person> CreateAsyncSQLPro(Person person)
        //{
        //    try
        //    {
        //        person.Status = true; // Asegura que el estado sea true por defecto

        //        const string query = @"
        //    INSERT INTO Person (FirstName, MiddleName, LastName, SecondLastName, DocumentType, DocumentNumber, PhoneNumber, Email, Address, BlodType, Photo, CityId, AssignmentId, Status) 
        //    OUTPUT INSERTED.Id 
        //    VALUES (@FirstName, @MiddleName, @LastName, @SecondLastName, @DocumentType, @DocumentNumber, @PhoneNumber, @Email, @Address, @BlodType, @Photo, @CityId, @AssignmentId, @Status);";

        //        var parameters = new
        //        {
        //            person.FirstName,
        //            person.MiddleName,
        //            person.LastName,
        //            person.SecondLastName,
        //            person.DocumentType,
        //            person.DocumentNumber,
        //            person.PhoneNumber,
        //            person.Email,
        //            person.Address,
        //            person.BlodType,
        //            person.Photo,
        //            person.CityId,
        //            person.AssignmentId,
        //            person.Status
        //        };

        //        person.Id = await _context.ExecuteScalarAsync<int>(query, parameters);
        //        return person;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error al crear la persona: {ex.Message}");
        //        throw;
        //    }
        //}

        public async Task<Person> CreateAsyncSQL(Person person)
        {
            try
            {
                person.Status = true; // Asegura que el estado sea true por defecto

                const string query = @"
            INSERT INTO Person (FirstName, MiddleName, LastName, SecondLastName, DocumentNumber, PhoneNumber, Email, Address, BlodType, Photo, Status) 
            OUTPUT INSERTED.Id 
            VALUES (@FirstName, @MiddleName, @LastName, @SecondLastName, @DocumentNumber, @PhoneNumber, @Email, @Address, @BlodType, @Photo, @Status);";

                var parameters = new
                {
                    person.FirstName,
                    person.MiddleName,
                    person.LastName,
                    person.SecondLastName,
                    person.DocumentNumber,
                    person.PhoneNumber,
                    person.Email,
                    person.Address,
                    person.BlodType,
                    person.Photo,
                    person.Status
                };

                person.Id = await _context.ExecuteScalarAsync<int>(query, parameters);
                return person;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear la persona: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Actualiza una persona con LINQ.
        /// </summary>
        public async Task<bool> UpdateAsync(Person person)
        {
            try
            {
                var existingPerson = await _context.Set<Person>().FindAsync(person.Id);
                if (existingPerson == null)
                {
                    _logger.LogWarning($"No se encontró la persona con ID {person.Id} para actualizar.");
                    return false;
                }

                _context.Entry(existingPerson).State = EntityState.Detached; // Evita conflictos de seguimiento
                person.Status = existingPerson.Status; // Mantiene el estado actual

                _context.Set<Person>().Update(existingPerson);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la persona {person.Id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Actualiza una persona con SQL.
        /// </summary>
        //public async Task<bool> UpdateAsyncSQLPRO(Person person)
        //{
        //    try
        //    {
        //        const string query = @"
        //    UPDATE Person 
        //    SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, SecondLastName = @SecondLastName, 
        //        DocumentType = @DocumentType, DocumentNumber = @DocumentNumber, PhoneNumber = @PhoneNumber, 
        //        Email = @Email, Address = @Address, BlodType = @BlodType, Photo = @Photo, 
        //        CityId = @CityId, AssignmentId = @AssignmentId, Status = @Status 
        //    WHERE Id = @Id;";

        //        var parameters = new
        //        {
        //            person.Id,
        //            person.FirstName,
        //            person.MiddleName,
        //            person.LastName,
        //            person.SecondLastName,
        //            person.DocumentType,
        //            person.DocumentNumber,
        //            person.PhoneNumber,
        //            person.Email,
        //            person.Address,
        //            person.BlodType,
        //            person.Photo,
        //            person.CityId,
        //            person.AssignmentId,
        //            person.Status
        //        };

        //        int rowsAffected = await _context.ExecuteAsync(query, parameters);
        //        return rowsAffected > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error al actualizar la persona {person.Id}: {ex.Message}");
        //        throw;
        //    }
        //}


        public async Task<bool> UpdateAsyncSQL(Person person)
        {
            try
            {
                const string query = @"
            UPDATE Person 
            SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, SecondLastName = @SecondLastName, 
                DocumentNumber = @DocumentNumber, PhoneNumber = @PhoneNumber, 
                Email = @Email, Address = @Address, BlodType = @BlodType, Photo = @Photo, 
                Status = @Status 
            WHERE Id = @Id;";

                var parameters = new
                {
                    person.Id,
                    person.FirstName,
                    person.MiddleName,
                    person.LastName,
                    person.SecondLastName,
                    person.DocumentNumber,
                    person.PhoneNumber,
                    person.Email,
                    person.Address,
                    person.BlodType,
                    person.Photo,
                    person.Status
                };

                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la persona {person.Id}: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Desactiva una persona (eliminación lógica) con LINQ.
        /// </summary>
        public async Task<bool> SoftDeleteAsync(int id)
        {
            try
            {
                var person = await _context.Set<Person>().FindAsync(id);
                if (person == null) return false;
                person.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar la persona {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Desactiva una persona (eliminación lógica) con SQL.
        /// </summary>
        public async Task<bool> SoftDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "UPDATE Person SET Status = 0 WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar la persona {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente una persona con LINQ.
        /// </summary>
        public async Task<bool> HardDeleteAsync(int id)
        {
            try
            {
                var person = await _context.Set<Person>().FindAsync(id);
                if (person == null) return false;
                _context.Set<Person>().Remove(person);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la persona: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente una persona con SQL.
        /// </summary>
        public async Task<bool> HardDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "DELETE FROM Person WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la persona: {ex.Message}");
                return false;
            }
        }
    }
}

