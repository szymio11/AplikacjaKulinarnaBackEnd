using System.ComponentModel.DataAnnotations;

namespace AplikacjaKulinarna.Data.ModelsDto.Recipe
{
    public class SaveRecipeDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Components { get; set; }
        [Required]
        public int PreparationTimeInMinutes { get; set; }
        [Required]
        public uint Difficulty { get; set; }

    }
}