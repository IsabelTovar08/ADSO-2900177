using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Strategy.Interface
{
    public interface IDeletedstrategy<T>
    {
        
        Task ExecuteAsync( int id);
    }
}
