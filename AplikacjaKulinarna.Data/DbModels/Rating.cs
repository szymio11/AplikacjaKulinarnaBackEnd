using System;
using System.ComponentModel.DataAnnotations;

namespace AplikacjaKulinarna.Data.DbModels
{
    public class Rating : BaseEntity
    {
        [Required]
        public int Value { get; set; }

        public Guid? UserId { get; set; }
        public User User { get; set; }

        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}