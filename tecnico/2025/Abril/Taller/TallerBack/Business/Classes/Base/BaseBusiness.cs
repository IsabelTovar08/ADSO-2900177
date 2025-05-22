using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfases;
using Data.Interfases;
using Entity.Models.Base;

namespace Business.Classes.Base
{
    public class BaseBusiness<T, D> : IBaseBusiness<T, D> where T : BaseModel
    {
        private readonly ICrudBase<T> _data;
        private readonly IMapper _mapper;
        public BaseBusiness(ICrudBase<T> data, IMapper mapper) 
        {
            _data = data;
            _mapper = mapper;
        }

        public async Task<D> Create(T entity)
        {
            BaseModel newEntity = _mapper.Map<T>(entity);
            newEntity = await _data.CreateAsync((T)newEntity);
            return _mapper.Map<D>(newEntity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _data.DeleteAsync(id);
        }

        public async Task<IEnumerable<D>> getAll()
        {
            IEnumerable<T> list = await _data.GetAllAsync();
            IEnumerable<D> listDto = _mapper.Map<IEnumerable<D>>(list);
            return listDto.ToList();
        }

        public async Task<D?> getById(int id)
        {
            T entity = await _data.GetByIdAsync(id);
            D dto = _mapper.Map<D>(entity);
            return dto;
        }

        public async Task<bool> ToggleActiveAsync(int id)
        {
            return await _data.ToggleActiveAsync(id);
        }

        public async Task<bool> Update(T entity)
        {
            BaseModel newEntity = _mapper.Map<T>(entity);
            await _data.UpdateAsync((T)newEntity);
            return true;
        }
    }
}
