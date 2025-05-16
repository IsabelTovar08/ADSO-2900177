using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.interfaces.crud
{
    public interface IDelete
    {
        Task<bool> DeletePersistent(int id);
     
    }
}
