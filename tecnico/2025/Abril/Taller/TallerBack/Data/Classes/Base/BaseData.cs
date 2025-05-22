using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfases;
using Entity.Context;
using Entity.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Data.Classes.Base
{
    public class BaseData<T> : ICrudBase<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _context;
        public BaseData(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            var existingEntity = await _context.Set<T>().FindAsync(entity.Id);
            if (existingEntity == null)
            {
                return false;
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            int rowsAffected = await _context.Set<T>().Where(e => e.Id == id).ExecuteDeleteAsync();
            return rowsAffected > 0;
        }
        public async Task<bool> ToggleActiveAsync(int id)
        {
            T ?entity = await _context.Set<T>().FirstOrDefaultAsync(i => i.Id == id);
            entity.IsDeleted = !entity.IsDeleted;
            await UpdateAsync(entity);
            return entity.IsDeleted;
        }


    }
}
