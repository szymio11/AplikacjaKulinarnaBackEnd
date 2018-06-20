using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AplikacjaKulinarna.Data.ModelsDto.Rating;
using AplikacjaKulinarna.Data.ModelsDto.User;

namespace AplikacjaKulinarna.Data.ModelsDto.Recipe
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Components { get; set; }
        public TimeSpan PreparationTime { get; set; }
        public DateTime Created { get; set; }
        public AccountDto User { get; set; }
        public uint Difficulty { get; set; }
        public double Rating { get; set; }
    }
}