using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.PublicApi
{
    public class AlbumsPublic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public UserPublic User { get; set; }
    }
}
