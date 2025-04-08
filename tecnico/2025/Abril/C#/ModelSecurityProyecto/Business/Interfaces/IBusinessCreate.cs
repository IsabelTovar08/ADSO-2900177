using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBusinessCreate<TDTO> where TDTO : class
    {
        Task<TDTO> CreateAsync(TDTO entity);
    }
}
