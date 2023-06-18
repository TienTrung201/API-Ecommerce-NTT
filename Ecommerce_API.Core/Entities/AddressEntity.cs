using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.Core.Entities
{
    public class AddressEntity:BaseEntity
    {
        [Key]
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

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public UserEntity? User { get; set; }

    }
}
