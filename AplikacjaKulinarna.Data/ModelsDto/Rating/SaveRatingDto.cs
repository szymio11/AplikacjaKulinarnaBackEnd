using System.ComponentModel.DataAnnotations;

namespace AplikacjaKulinarna.Data.ModelsDto.Rating
{
    public class SaveRatingDto
    {
        [Required]
        public int Value { get; set; }
    }
}