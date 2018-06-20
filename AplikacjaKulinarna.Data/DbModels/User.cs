using System;
using System.ComponentModel.DataAnnotations;

namespace AplikacjaKulinarna.Data.DbModels
{
    public class User : BaseEntity
    {
        public string Role { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime Created { get; set; }
    }
}