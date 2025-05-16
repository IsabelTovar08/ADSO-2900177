using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBusinessDelete<TDTO> where TDTO : class
    {
        Task<bool> DeleteAsync(int id);
    }
}
