using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Interfaces
{
    public interface IBusinessBase<TDTO> : IBusinessRead<TDTO>, IBusinessCreate<TDTO>, IBusinessUpdate<TDTO>, IBusinessDelete<TDTO> where TDTO : class
    {
    }

}
