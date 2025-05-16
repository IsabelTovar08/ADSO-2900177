using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class DeleteRequest
    {
        public int Id { get; set; }
        public DeleteStrategyType Strategy { get; set; }
    }
}
