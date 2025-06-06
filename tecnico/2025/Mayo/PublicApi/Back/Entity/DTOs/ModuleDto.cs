﻿using System.ComponentModel.DataAnnotations;

namespace Entity.DTOs
{
    public class ModuleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
