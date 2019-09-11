using Microsoft.AspNetCore.Mvc;
using MoviePostersAPI.Services;

namespace MoviePostersAPI.Controllers
{
    [Route("api/[controller]")]
    public class MoviePostersController : Controller
    {
        private MoviePostersDbContext _context;

        public MoviePostersController(MoviePostersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMoviePosters()
        {
            return Ok(_context.MoviePosters);
        }
    }
}