using System;

namespace AplikacjaKulinarna.Data.ModelsDto.Recipe
{
    public class GetRecipeUpdateDto
    {
        public string Name { get; set; }

        public string Components { get; set; }

        public double PreparationTimeInMinutes { get; set; }

        public uint Difficulty { get; set; }
    }
}