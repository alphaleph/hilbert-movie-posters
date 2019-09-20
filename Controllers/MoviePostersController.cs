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

        // [HttpGet]
        // public async Task<IActionResult> GetMoviePosters()
        // {
        //     return Ok(await (_context.MoviePosters
        //         .Include(mp => mp.Reviews)).ToListAsync());
        // }

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
        // [ValidateModelState]
        // [SwaggerOperation("GetMoviePosters")]
        // [SwaggerResponse(statusCode: 200, type: typeof(List<MoviePoster>), description: "Search results matching criteria")]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        // [SwaggerResponse(statusCode: 404, type: typeof(Error), description: "Specified resource was not found")]
        public async Task<IActionResult> GetMoviePosters([FromQuery]string name, [FromQuery]string artist, [FromQuery]int? year, [FromQuery]string movie, [FromQuery]int? rating, [FromQuery]int? skip, [FromQuery][Range(1, 50)]int? limit)
        { 
            Console.WriteLine("Sending MoviePosters: " + _context.MoviePosters.ToList());
            return Ok(await (_context.MoviePosters
                .Include(mp => mp.Reviews)).ToListAsync());

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Error));

            // string exampleJson = null;
            // exampleJson = "[ {\n  \"moviePosterId\" : 2,\n  \"movie\" : {\n    \"moviePosters\" : [ null, null ],\n    \"year\" : 1984,\n    \"name\" : \"Highlander\",\n    \"movieId\" : 2\n  },\n  \"reviews\" : [ {\n    \"moviePosterId\" : 2,\n    \"name\" : \"Hauer\",\n    \"rating\" : 4,\n    \"comment\" : \"Like tears in rain...\",\n    \"postedDate\" : \"2017-07-21T17:32:28.000Z\"\n  }, {\n    \"moviePosterId\" : 2,\n    \"name\" : \"Hauer\",\n    \"rating\" : 4,\n    \"comment\" : \"Like tears in rain...\",\n    \"postedDate\" : \"2017-07-21T17:32:28.000Z\"\n  } ],\n  \"artist\" : \"Enzo Nistri\",\n  \"year\" : 1984,\n  \"name\" : \"Vertigo by Enzo Nistri\",\n  \"rating\" : 3,\n  \"movieId\" : 2,\n  \"ratingCount\" : 42,\n  \"posterImage\" : {\n    \"image\" : \"\",\n    \"moviePosterId\" : 2,\n    \"posterImageId\" : 2\n  }\n}, {\n  \"moviePosterId\" : 2,\n  \"movie\" : {\n    \"moviePosters\" : [ null, null ],\n    \"year\" : 1984,\n    \"name\" : \"Highlander\",\n    \"movieId\" : 2\n  },\n  \"reviews\" : [ {\n    \"moviePosterId\" : 2,\n    \"name\" : \"Hauer\",\n    \"rating\" : 4,\n    \"comment\" : \"Like tears in rain...\",\n    \"postedDate\" : \"2017-07-21T17:32:28.000Z\"\n  }, {\n    \"moviePosterId\" : 2,\n    \"name\" : \"Hauer\",\n    \"rating\" : 4,\n    \"comment\" : \"Like tears in rain...\",\n    \"postedDate\" : \"2017-07-21T17:32:28.000Z\"\n  } ],\n  \"artist\" : \"Enzo Nistri\",\n  \"year\" : 1984,\n  \"name\" : \"Vertigo by Enzo Nistri\",\n  \"rating\" : 3,\n  \"movieId\" : 2,\n  \"ratingCount\" : 42,\n  \"posterImage\" : {\n    \"image\" : \"\",\n    \"moviePosterId\" : 2,\n    \"posterImageId\" : 2\n  }\n} ]";
            
            //             var example = exampleJson != null
            //             ? JsonConvert.DeserializeObject<List<MoviePoster>>(exampleJson)
            //             : default(List<MoviePoster>);            //TODO: Change the data returned
            // return new ObjectResult(example);
        }

        /*
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
        // [ValidateModelState]
        // [SwaggerOperation("GetMoviePosterById")]
        // [SwaggerResponse(statusCode: 200, type: typeof(List<MoviePoster>), description: "Search results matching criteria")]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        // [SwaggerResponse(statusCode: 404, type: typeof(Error), description: "Specified resource was not found")]
        public virtual IActionResult GetMoviePosterById([FromRoute][Required]int? moviePosterId)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<MoviePoster>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Error));
            string exampleJson = null;
            exampleJson = "[ {\n  \"moviePosterId\" : 2,\n  \"movie\" : {\n    \"moviePosters\" : [ null, null ],\n    \"year\" : 1984,\n    \"name\" : \"Highlander\",\n    \"movieId\" : 2\n  },\n  \"reviews\" : [ {\n    \"moviePosterId\" : 2,\n    \"name\" : \"Hauer\",\n    \"rating\" : 4,\n    \"comment\" : \"Like tears in rain...\",\n    \"postedDate\" : \"2017-07-21T17:32:28.000Z\"\n  }, {\n    \"moviePosterId\" : 2,\n    \"name\" : \"Hauer\",\n    \"rating\" : 4,\n    \"comment\" : \"Like tears in rain...\",\n    \"postedDate\" : \"2017-07-21T17:32:28.000Z\"\n  } ],\n  \"artist\" : \"Enzo Nistri\",\n  \"year\" : 1984,\n  \"name\" : \"Vertigo by Enzo Nistri\",\n  \"rating\" : 3,\n  \"movieId\" : 2,\n  \"ratingCount\" : 42,\n  \"posterImage\" : {\n    \"image\" : \"\",\n    \"moviePosterId\" : 2,\n    \"posterImageId\" : 2\n  }\n}, {\n  \"moviePosterId\" : 2,\n  \"movie\" : {\n    \"moviePosters\" : [ null, null ],\n    \"year\" : 1984,\n    \"name\" : \"Highlander\",\n    \"movieId\" : 2\n  },\n  \"reviews\" : [ {\n    \"moviePosterId\" : 2,\n    \"name\" : \"Hauer\",\n    \"rating\" : 4,\n    \"comment\" : \"Like tears in rain...\",\n    \"postedDate\" : \"2017-07-21T17:32:28.000Z\"\n  }, {\n    \"moviePosterId\" : 2,\n    \"name\" : \"Hauer\",\n    \"rating\" : 4,\n    \"comment\" : \"Like tears in rain...\",\n    \"postedDate\" : \"2017-07-21T17:32:28.000Z\"\n  } ],\n  \"artist\" : \"Enzo Nistri\",\n  \"year\" : 1984,\n  \"name\" : \"Vertigo by Enzo Nistri\",\n  \"rating\" : 3,\n  \"movieId\" : 2,\n  \"ratingCount\" : 42,\n  \"posterImage\" : {\n    \"image\" : \"\",\n    \"moviePosterId\" : 2,\n    \"posterImageId\" : 2\n  }\n} ]";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<List<MoviePoster>>(exampleJson)
                        : default(List<MoviePoster>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Adds a new movie poster
        /// </summary>
        /// <remarks>Adds a new movie poster</remarks>
        /// <param name="body">Movie poster to add</param>
        /// <response code="201">Provides copy of the added movie poster</response>
        /// <response code="400">Invalid action parameters</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpPost]
        // [ValidateModelState]
        // [SwaggerOperation("AddMoviePoster")]
        // [SwaggerResponse(statusCode: 201, type: typeof(MoviePoster), description: "Provides copy of the added movie poster")]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        // [SwaggerResponse(statusCode: 404, type: typeof(Error), description: "Specified resource was not found")]
        public virtual IActionResult AddMoviePoster([FromBody]MoviePoster body)
        { 
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(MoviePoster));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Error));
            string exampleJson = null;
            exampleJson = "{\n  \"moviePosterId\" : 2,\n  \"movie\" : {\n    \"moviePosters\" : [ null, null ],\n    \"year\" : 1984,\n    \"name\" : \"Highlander\",\n    \"movieId\" : 2\n  },\n  \"reviews\" : [ {\n    \"moviePosterId\" : 2,\n    \"name\" : \"Hauer\",\n    \"rating\" : 4,\n    \"comment\" : \"Like tears in rain...\",\n    \"postedDate\" : \"2017-07-21T17:32:28.000Z\"\n  }, {\n    \"moviePosterId\" : 2,\n    \"name\" : \"Hauer\",\n    \"rating\" : 4,\n    \"comment\" : \"Like tears in rain...\",\n    \"postedDate\" : \"2017-07-21T17:32:28.000Z\"\n  } ],\n  \"artist\" : \"Enzo Nistri\",\n  \"year\" : 1984,\n  \"name\" : \"Vertigo by Enzo Nistri\",\n  \"rating\" : 3,\n  \"movieId\" : 2,\n  \"ratingCount\" : 42,\n  \"posterImage\" : {\n    \"image\" : \"\",\n    \"moviePosterId\" : 2,\n    \"posterImageId\" : 2\n  }\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<MoviePoster>(exampleJson)
                        : default(MoviePoster);            //TODO: Change the data returned
            return new ObjectResult(example);
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
        // [ValidateModelState]
        // [SwaggerOperation("UpdateMoviePosterById")]
        // [SwaggerResponse(statusCode: 200, type: typeof(MoviePoster), description: "Provides copy of the updated movie poster")]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        // [SwaggerResponse(statusCode: 404, type: typeof(Error), description: "Specified resource was not found")]
        public virtual IActionResult UpdateMoviePosterById([FromBody]MoviePoster body, [FromRoute][Required]int? moviePosterId)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(MoviePoster));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Error));
            string exampleJson = null;
            exampleJson = "{\n  \"moviePosterId\" : 2,\n  \"movie\" : {\n    \"moviePosters\" : [ null, null ],\n    \"year\" : 1984,\n    \"name\" : \"Highlander\",\n    \"movieId\" : 2\n  },\n  \"reviews\" : [ {\n    \"moviePosterId\" : 2,\n    \"name\" : \"Hauer\",\n    \"rating\" : 4,\n    \"comment\" : \"Like tears in rain...\",\n    \"postedDate\" : \"2017-07-21T17:32:28.000Z\"\n  }, {\n    \"moviePosterId\" : 2,\n    \"name\" : \"Hauer\",\n    \"rating\" : 4,\n    \"comment\" : \"Like tears in rain...\",\n    \"postedDate\" : \"2017-07-21T17:32:28.000Z\"\n  } ],\n  \"artist\" : \"Enzo Nistri\",\n  \"year\" : 1984,\n  \"name\" : \"Vertigo by Enzo Nistri\",\n  \"rating\" : 3,\n  \"movieId\" : 2,\n  \"ratingCount\" : 42,\n  \"posterImage\" : {\n    \"image\" : \"\",\n    \"moviePosterId\" : 2,\n    \"posterImageId\" : 2\n  }\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<MoviePoster>(exampleJson)
                        : default(MoviePoster);            //TODO: Change the data returned
            return new ObjectResult(example);
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
        [Route("{moviePosterId}")]
        // [ValidateModelState]
        // [SwaggerOperation("DeleteMoviePosterById")]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        // [SwaggerResponse(statusCode: 404, type: typeof(Error), description: "Specified resource was not found")]
        public virtual IActionResult DeleteMoviePosterById([FromRoute][Required]int? moviePosterId)
        { 
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Error));

            throw new NotImplementedException();
        }
        */
    }
}