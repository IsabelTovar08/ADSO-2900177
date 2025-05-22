using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfases
{
    public interface IBaseBusiness<T, D>
    {
        Task<IEnumerable<D>> getAll();

        Task<D?> getById(int id);
        Task<D> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
        Task<bool> ToggleActiveAsync(int id);
    }
}
