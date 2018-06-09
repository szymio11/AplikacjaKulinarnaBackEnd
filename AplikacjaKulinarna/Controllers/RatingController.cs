using System;
using System.Threading.Tasks;
using AplikacjaKulinarna.Data.ModelsDto.Rating;
using AplikacjaKulinarna.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AplikacjaKulinarna.API.Controllers
{
    [Authorize]
    [Route("api/recipe/{recipeId}/rating")]
    public class RatingController : ApiControllerBase
    {
        private readonly IRatingService _service;

        public RatingController(IRatingService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddRating(Guid recipeId,[FromBody] SaveRatingDto ratingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.CreateRatingAsync(ratingDto, recipeId, UserId);
            return CreatedAtRoute("GetRating",new { recipeId, ratingId = result.Id},result);
        }
        [HttpPut("{ratingId}")]
        public async Task<IActionResult> UpdateRating(Guid recipeId, Guid ratingId, [FromBody] SaveRatingDto ratingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.UpdateRatingAsync(ratingDto, recipeId, ratingId);
            return Ok();
        }
        [HttpGet("{ratingId}",Name = "GetRating")]
        public async Task<IActionResult> GetRating(Guid recipeId, Guid ratingId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetRatingAsync(recipeId, ratingId);
            return Ok(result);
        }
        [HttpDelete("{ratingId}")]
        public async Task<IActionResult> DeleteRating(Guid recipeId, Guid ratingId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.DeleteRatingAsync(recipeId, ratingId);
            return Ok();
        }
    }
}