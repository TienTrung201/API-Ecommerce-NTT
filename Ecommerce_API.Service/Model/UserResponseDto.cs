﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Service.Model
{
    public class UserResponseDto
    {
        public string? UserId { get; set; }
        [StringLength(50)]
        [Required]
        public string UserName { get; set; } = string.Empty;

        [StringLength(100)]
        [Required]
        public string Email { get; set; } = string.Empty;

        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [StringLength(100)]
        [Required]
        public string FullName { get; set; } = string.Empty;

        public string? Avatar { get; set; }

        [StringLength(200)]
        public string? Bio { get; set; }
        public int? Gender { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
