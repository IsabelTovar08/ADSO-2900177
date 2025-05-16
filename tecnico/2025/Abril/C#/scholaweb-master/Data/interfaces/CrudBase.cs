using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.interfaces.crud;

namespace Data.interfaces
{
    public interface CrudBase<T> : ICreate<T>, IRead<T>, IUpdate<T>, IDelete, ISoftDelete where T : class
    {

    }
}
