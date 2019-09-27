using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MoviePostersAPI.Services;
using MoviePostersAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace MoviePostersDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase 
    {
        private MoviePostersDbContext _context;

        public MoviesController(MoviePostersDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets matching movies
        /// </summary>
        /// <param name="name">Search by poster name</param>
        /// <param name="year">Search by poster year</param>
        /// <response code="200">Search results matching criteria</response>
        /// <response code="400">Invalid action parameters</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpGet]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        // [SwaggerResponse(statusCode: 404, type: typeof(Error), description: "Specified resource was not found")]
        public async Task<IActionResult> GetMovies([FromQuery]string name, [FromQuery]int? year)
        { 
            return Ok(await (_context.Movies
                .Include(m => m.MoviePosters))
                .AsNoTracking()
                .ToListAsync());

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Error));
        }

        /// <summary>
        /// Gets one specified movie
        /// </summary>
        /// <param name="movieId">Perform action by movie id</param>
        /// <response code="200">Search results matching criteria</response>
        /// <response code="400">Invalid action parameters</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpGet]
        [Route("{movieId:int}")]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        public async Task<IActionResult> GetMovieById([FromRoute][Required]int movieId)
        { 
            var movie = await _context.Movies
                .Include(m => m.MoviePosters)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.MovieId == movieId);
            
            return (movie == null) ? (IActionResult)NotFound(new Error { Code = "404", Message = "Specified movie was not found" })
                                   : (IActionResult)Ok(movie);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));
        }

        /// <summary>
        /// Updates one specified movie
        /// </summary>
        /// <param name="body">Update movie schema</param>
        /// <param name="movieId">Perform action by movie id</param>
        /// <response code="200">Provides copy of the updated movie</response>
        /// <response code="400">Invalid action parameters</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpPut]
        [Route("{movieId:int}")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        public async Task<IActionResult> UpdateMovieById([FromBody]Movie body, [FromRoute][Required]int movieId)
        { 
            if (String.IsNullOrWhiteSpace(body.Name))
            {
                return BadRequest(new Error { Code = "400", Message = "Movie name cannot be empty or whitespace" });
            }
            
            var movie = await _context.Movies.SingleOrDefaultAsync(m => m.MovieId == movieId);

            if (movie == null)
            {
                return NotFound(new Error { Code = "404", Message = "Specified movie was not found for update" } );
            }

            movie.Name = body.Name;
            movie.Year = body.Year;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(movie);
            }
            catch (DbUpdateException e)
            {
                return NotFound(new Error { Code = "404", Message = "Error while updating movie" });
            }

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));
        }
    } 
}