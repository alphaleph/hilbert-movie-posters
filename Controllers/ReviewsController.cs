using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MoviePostersAPI.Services;

namespace MoviePostersAPI.Controllers
{
    [Route("api/movieposters/{moviePosterId:int}/[controller]")]
    public class ReviewsController : Controller
    {
        private MoviePostersDbContext _context;

        public ReviewsController(MoviePostersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReviews(int moviePosterId)
        {
            var reviews = await _context.Reviews.ToListAsync();
            return reviews.Exists( r => r.MoviePosterId == moviePosterId) 
                ? (IActionResult)Ok(reviews.FindAll(r => r.MoviePosterId == moviePosterId)) 
                : (IActionResult)NotFound();
        }
    }
}