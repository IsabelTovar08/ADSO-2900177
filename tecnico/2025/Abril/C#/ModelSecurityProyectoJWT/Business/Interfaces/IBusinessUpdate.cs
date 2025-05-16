using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBusinessUpdate<TDTO> where TDTO : class
    {
        Task<bool> UpdateAsync(TDTO entity);
    }
}
