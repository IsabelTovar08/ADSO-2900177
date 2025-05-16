using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.interfaces.crud
{
    public interface ICreate<T>
    {
        Task<T> CreateAsync(T Entity);
    }
}
