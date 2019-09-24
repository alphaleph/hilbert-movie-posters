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

namespace MoviePostersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviePostersController : ControllerBase
    {
        private MoviePostersDbContext _context;

        public MoviePostersController(MoviePostersDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets matching movie posters (default limit is 20)
        /// </summary>
        /// <param name="name">Search by poster name</param>
        /// <param name="artist">Search by poster artist</param>
        /// <param name="year">Search by poster year</param>
        /// <param name="movie">Search by poster movie name</param>
        /// <param name="rating">Search by poster rating</param>
        /// <param name="skip">Number of records to skip for pagination</param>
        /// <param name="limit">Maximum number of records to return</param>
        /// <response code="200">Search results matching criteria</response>
        /// <response code="400">Invalid action parameters</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpGet]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        // [SwaggerResponse(statusCode: 404, type: typeof(Error), description: "Specified resource was not found")]
        public async Task<IActionResult> GetMoviePosters([FromQuery]string name, [FromQuery]string artist, [FromQuery]int? year, [FromQuery]string movie, [FromQuery]int? rating, [FromQuery]int? skip, [FromQuery][Range(1, 50)]int? limit)
        { 
            return Ok(await _context.MoviePosters
                .Include(mp => mp.Reviews)
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
        /// Gets one specified movie poster
        /// </summary>
        /// <param name="moviePosterId">Perform action by poster id</param>
        /// <response code="200">Search results matching criteria</response>
        /// <response code="400">Invalid action parameters</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpGet]
        [Route("{moviePosterId:int}")]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        public async Task<IActionResult> GetMoviePosterById([FromRoute][Required]int moviePosterId)
        { 
            var moviePoster = await _context.MoviePosters
                                .Include(mp => mp.Reviews)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(mp => mp.MoviePosterId == moviePosterId);

            return (moviePoster == null) ? (IActionResult)NotFound(new Error { Code = "404", Message = "Specified resource was not found"})
                                         : (IActionResult)Ok(moviePoster);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));
        }

        /// <summary>
        /// Adds a new movie poster
        /// </summary>
        /// <remarks>Adds a new movie poster</remarks>
        /// <param name="body">Movie poster to add</param>
        /// <response code="201">Provides copy of the added movie poster</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpPost]
        // [ValidateAntiForgeryToken]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        public async Task<IActionResult> AddMoviePoster([FromBody]MoviePoster body)
        {
            //TODO: More robust dup check
            if (await _context.MoviePosters.AsNoTracking().SingleOrDefaultAsync(mp => mp.Name == body.Name || 
                                                                                    mp.PosterImageUrl == body.PosterImageUrl) != null)
            {
                return BadRequest(new Error { Code = "400", Message = "Movie Poster already exists."});
            }

            var newMoviePoster = new MoviePoster()
            {
                Name = body.Name,
                Year = body.Year,
                Artist = body.Artist,
                PosterImageUrl = body.PosterImageUrl,
                Reviews = new List<Review>()
            };

            //TODO: Improve uniqueness check, e.g. flatten names, add directors?
            var movie = await _context.Movies.SingleOrDefaultAsync(m => m.Name == body.Name && m.Year == body.Year);
    
            // Create a new Movie for poster if it does not yet exist. Otherwise, update current one.
            if (movie == null) 
            {
                //TODO: Improve Movie<->MoviePoster nav props?
                movie = new Movie { Name = body.Name, Year = body.Year, MoviePosters = new List<MoviePoster> { newMoviePoster } };
                newMoviePoster.Movie = movie;
                _context.Movies.Add(movie);
            } 
            else
            {
                movie.MoviePosters.Add(newMoviePoster);
            }

            _context.MoviePosters.Add(newMoviePoster);

            try
            {
                await _context.SaveChangesAsync();
                return StatusCode(201, newMoviePoster);
            }
            catch (DbUpdateException e)
            {
                return NotFound(new Error { Code = "404", Message = "Error while creating movie poster"});
            }
            
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));
        }

        
        /// <summary>
        /// Updates one specified movie poster
        /// </summary>
        /// <param name="body">Update movie poster schema</param>
        /// <param name="moviePosterId">Perform action by poster id</param>
        /// <response code="200">Provides copy of the updated movie poster</response>
        /// <response code="400">Invalid action parameters</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpPut]
        [Route("{moviePosterId:int}")]
        // [ValidateAntiForgeryToken]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        public async Task<IActionResult> UpdateMoviePosterById([FromBody]MoviePoster body, [FromRoute][Required]int moviePosterId)
        { 
            var moviePoster = await _context.MoviePosters.SingleOrDefaultAsync(mp => mp.MoviePosterId == moviePosterId);

            if (moviePoster == null)
            {
                return NotFound(new Error { Code = "404", Message = "Specified movie poster was not found" });
            }

            moviePoster.Name = body.Name;
            moviePoster.Artist = body.Artist;
            moviePoster.Year = body.Year;
            moviePoster.PosterImageUrl = body.PosterImageUrl;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(moviePoster);
            }
            catch (DbUpdateException e)
            {
                return NotFound(new Error { Code = "404", Message = "Error while updating movie poster"});
            }

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));
        }

        
        /// <summary>
        /// Deletes one specified movie poster
        /// </summary>
        /// <param name="moviePosterId">Deletes one specified movie poster</param>
        /// <response code="204">Inherent confirmation of deletion</response>
        /// <response code="400">Invalid action parameters</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpDelete]
        [Route("{moviePosterId:int}")]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        public async Task<IActionResult> DeleteMoviePosterById([FromRoute][Required]int moviePosterId)
        { 
            var moviePoster = await _context.MoviePosters
                                        .AsNoTracking()
                                        .SingleOrDefaultAsync(mp => mp.MoviePosterId == moviePosterId);
            if (moviePoster == null)
            {
                return NotFound(new Error { Code = "404", Message = "Movie poster not found for deletion"});
            }

            try
            {
                _context.MoviePosters.Remove(moviePoster);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException e)
            {
                return NotFound(new Error { Code = "404", Message = "Error in movie poster deletion"});
            }

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));
        }
    }
}