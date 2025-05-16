using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Strategy.Implements.Factory;
using Business.Strategy.Interface;
using Data.Interfases;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Strategy.Implements
{
    // En SelectorFactoryStrategy
    public static class SelectorFactoryStrategy
    {
        public static Task Execute<T>(DeleteStrategyType type, ICrudBase<T> repository, int id) where T : class
        {
            return type switch
            {
                DeleteStrategyType.DeletePersistent => new DeletePersistent<T>(repository).ExecuteAsync(id),
                DeleteStrategyType.DeleteLogical => new DeleteLogical<T>(repository).ExecuteAsync(id),
                _ => throw new NotImplementedException("Estrategia no implementada")
            };
        }
    }



}
