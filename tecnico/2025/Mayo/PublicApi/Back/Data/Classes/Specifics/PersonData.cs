using Data.Classes.Base;
using Entity.Context;
using Entity.Models;
using Microsoft.Extensions.Logging;
namespace Data.Classes.Specifics
{
    public class PersonData : CrudBase<Person>
    {

        public PersonData(ApplicationDbContext context, ILogger<Person> logger) : base(context, logger)
        {

        }
    }
}
