﻿

namespace Entity.DTOs
{
    public class UserRolDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RolId { get; set; }
        public string RolName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
