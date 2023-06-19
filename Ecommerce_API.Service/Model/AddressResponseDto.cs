using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Service.Model
{
    public class AddressResponseDto
    {
        public int AddressId { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string District { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Ward { get; set; } = string.Empty;

        [Required]
        [StringLength(256)]
        public string AddressLine { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public bool IsDefault { get; set; }
    }
}
