using Microsoft.AspNetCore.Mvc;

namespace AplikacjaKulinarna.API.Controllers
{
    [Route("api/recipe/{recipeId}/rating")]
    public class RatingController : ApiControllerBase
    {
        
        public IActionResult Create()
        {
            return null;
        }
    }
}