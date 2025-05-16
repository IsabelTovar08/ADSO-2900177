using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUpdate<T>
    {
        Task<bool> UpdateAsync(T entity);
    }
}
