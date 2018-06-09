using AplikacjaKulinarna.Data.ModelsDto.Rating;
using System;
using System.Threading.Tasks;

namespace AplikacjaKulinarna.Service.Interfaces
{
    public interface IRatingService
    {
        Task<RatingDto> CreateRatingAsync(SaveRatingDto saveRatingDto, Guid recipeId, Guid userId);
        Task<RatingDto> GetRatingAsync(Guid recipeId, Guid ratingId);
        Task UpdateRatingAsync(SaveRatingDto saveRatingDto, Guid recipeId, Guid ratingId);
        Task DeleteRatingAsync(Guid recipeId, Guid ratingId);
    }
}