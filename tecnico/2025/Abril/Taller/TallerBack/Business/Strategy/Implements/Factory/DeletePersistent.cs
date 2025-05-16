using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Strategy.Interface;
using Data.Classes.Base;
using Data.Interfases;

namespace Business.Strategy.Implements.Factory
{
    public class DeletePersistent<T> : IDeletedstrategy<T> where T : class
    {

        private readonly ICrudBase<T> _data;
        public DeletePersistent(ICrudBase<T> data)
        {
            _data = data;
        }

        public Task ExecuteAsync(int id)
        {
            return _data.DeleteAsync(id);
        }
    }
}
