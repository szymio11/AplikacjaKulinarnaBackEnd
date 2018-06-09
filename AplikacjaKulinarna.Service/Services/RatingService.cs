using System;
using System.Threading.Tasks;
using AplikacjaKulinarna.Data.DbModels;
using AplikacjaKulinarna.Data.ModelsDto.Rating;
using AplikacjaKulinarna.Repository.Interfaces;
using AplikacjaKulinarna.Service.Interfaces;
using AutoMapper;

namespace AplikacjaKulinarna.Service.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRepository<Rating> _ratingRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RatingService(IRepository<Rating> ratingRepository,IRecipeRepository recipeRepository,IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }
        public async Task<RatingDto> CreateRatingAsync(SaveRatingDto saveRatingDto, Guid recipeId, Guid userId)
        {
            if (!await _recipeRepository.ExistAsync(a=>a.Id==recipeId))
            {
                throw new Exception("Nie ma takiego Przepisu");
            }
            var rating = _mapper.Map<SaveRatingDto,Rating>(saveRatingDto);
            rating.UserId = userId;
            rating.RecipeId = recipeId;
            await _ratingRepository.AddAsyn(rating);
         
            return await GetRatingAsync(rating.RecipeId,rating.Id);
        }

        public async Task<RatingDto> GetRatingAsync(Guid recipeId, Guid ratingId)
        {
            if (!await _recipeRepository.ExistAsync(a => a.Id == recipeId))
            {
                throw new Exception("Nie ma takiego Przepisu");
            }

            if (!await _ratingRepository.ExistAsync(a=>a.Id==ratingId))
            {
                throw new Exception("Nie ma takiej oceny");
            }

            var rating = await _ratingRepository.FindByAsyn(a => a.RecipeId == recipeId, s => s.Id == ratingId);
            var result = _mapper.Map<RatingDto>(rating);
            return result;
        }

        public async Task UpdateRatingAsync(SaveRatingDto saveRatingDto, Guid recipeId, Guid ratingId)
        {
            if (!await _recipeRepository.ExistAsync(a => a.Id == recipeId))
            {
                throw new Exception("Nie ma takiego Przepisu");
            }

            if (!await _ratingRepository.ExistAsync(a => a.Id == ratingId))
            {
                throw new Exception("Nie ma takiej oceny");
            }
            var rating = await _ratingRepository.FindByAsyn(a => a.RecipeId == recipeId, s => s.Id == ratingId);
            _mapper.Map(saveRatingDto, rating);
            await _ratingRepository.SaveAsync();
        }

        public async Task DeleteRatingAsync(Guid recipeId, Guid ratingId)
        {
            if (!await _recipeRepository.ExistAsync(a => a.Id == recipeId))
            {
                throw new Exception("Nie ma takiego Przepisu");
            }

            if (!await _ratingRepository.ExistAsync(a => a.Id == ratingId))
            {
                throw new Exception("Nie ma takiej oceny");
            }
            var rating = await _ratingRepository.FindByAsyn(a => a.RecipeId == recipeId, s => s.Id == ratingId);
            await _ratingRepository.DeleteAsyn(rating);
        }
    }
}