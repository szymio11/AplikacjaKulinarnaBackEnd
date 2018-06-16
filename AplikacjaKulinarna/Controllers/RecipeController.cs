using System;
using System.Threading.Tasks;
using AplikacjaKulinarna.Data.ModelsDto.Recipe;
using AplikacjaKulinarna.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AplikacjaKulinarna.API.Controllers
{
    [Authorize(Policy = "HasAdminRole")]
    [Route("api/recipe")]
    public class RecipeController : ApiControllerBase
    {
        private readonly IRecipeService _service;

        public RecipeController(IRecipeService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] SaveRecipeDto recipeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _service.CreateRecipeAsync(recipeDto, UserId);
            return CreatedAtRoute("GetRecipe", new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(Guid id,[FromBody] SaveRecipeDto recipeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _service.UpdateRecipeAsync(recipeDto, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            await _service.DeleteRecipe(id); 
            return Ok();
        }
        //get do pobrania danych potrzbnych dla updata 
        [HttpGet("{id}/update")]
        public async Task<IActionResult> GetRecipeUpdate(Guid id)
        {
            var result = await _service.GetUpdate(id);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet("{id}",Name = "GetRecipe")]
        public async Task<IActionResult> GetRecipe(Guid id)
        {
            var result = await _service.GetRecipeAsync(id);
            return Ok(result);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetRecipes()
        {
            var result = await _service.GetAllRecipesAsync();
            return Ok(result);
        }


    }
}