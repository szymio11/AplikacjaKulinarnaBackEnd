using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AplikacjaKulinarna.Data.DbModels
{
    public class Recipe : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Components { get; set; }
        [Required]
        public TimeSpan PreparationTime { get; set; }
        [Required]
        public int Difficulty { get; set; }
        public DateTime Created { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Rating> Ratings { get; set; }        
        public Recipe()
        {
            Ratings = new Collection<Rating>();
        }
    }
}