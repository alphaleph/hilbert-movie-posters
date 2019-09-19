using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetMoviePosters()
        {
            return Ok(await _context.MoviePosters.ToListAsync());
        }
    }
}