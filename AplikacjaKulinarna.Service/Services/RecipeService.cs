using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AplikacjaKulinarna.Data.DbModels;
using AplikacjaKulinarna.Data.ModelsDto.Recipe;
using AplikacjaKulinarna.Repository.Interfaces;
using AplikacjaKulinarna.Service.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaKulinarna.Service.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RecipeDto> CreateRecipeAsync(SaveRecipeDto saveRecipeDto,Guid userId)
        {
            var recipe = _mapper.Map<SaveRecipeDto, Recipe>(saveRecipeDto);
            recipe.UserId = userId;
            recipe.Created = DateTime.Now;
            var timeSpaninMinutes = recipe.PreparationTime.Add(new TimeSpan(0, saveRecipeDto.PreparationTimeInMinutes , 0));
            recipe.PreparationTime = timeSpaninMinutes;
            await _repository.AddAsyn(recipe);
            return await GetRecipeAsync(recipe.Id);
        }

        public async Task<RecipeDto> GetRecipeAsync(Guid id)
        {
            if (!await _repository.ExistAsync(a=>a.Id==id))
            {
                throw new Exception("Nie ma takiego przepisu.");
            }
            var recipe = await _repository.GetAllIncluding(u => u.User,r=>r.Ratings).SingleOrDefaultAsync(r => r.Id == id);
            var result = _mapper.Map<RecipeDto>(recipe);
            return result;
        }

        public async Task UpdateRecipeAsync(SaveRecipeDto saveRecipeDto,Guid id)
        {
            if (!await _repository.ExistAsync(a => a.Id == id))
            {
                throw new Exception("Nie ma takiego przepisu.");
            }
            var recipe = await _repository.GetAsync(id);
            var recipeMapped = _mapper.Map(saveRecipeDto, recipe);
            recipe.PreparationTime= TimeSpan.Zero;
            var timeSpaninMinutes = recipe.PreparationTime.Add(new TimeSpan(0, saveRecipeDto.PreparationTimeInMinutes, 0));
            recipeMapped.PreparationTime = timeSpaninMinutes;
          
            await _repository.SaveAsync();
        }

        public async Task DeleteRecipe(Guid id)
        {
            if (!await _repository.ExistAsync(a => a.Id == id))
            {
                throw new Exception("Nie ma takiego przepisu.");
            }
            var recipe = await _repository.GetAsync(id);
            await _repository.DeleteAsyn(recipe);
        }
        public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync()
        {
            var recipes = await _repository.GetRecipesAsync();
            var result = _mapper.Map<IEnumerable<RecipeDto>>(recipes);
            return result;
        }

        public async Task<GetRecipeUpdateDto> GetUpdate(Guid id)
        {
            if (!await _repository.ExistAsync(a => a.Id == id))
            {
                throw new Exception("Nie ma takiego przepisu.");
            }

            var recipe = await _repository.GetAsync(id);
            var result = _mapper.Map<GetRecipeUpdateDto>(recipe);
            return result;
        }
    }
}