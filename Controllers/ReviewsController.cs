using System;
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
    [Route("api/movieposters/{moviePosterId:int}/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private MoviePostersDbContext _context;

        public ReviewsController(MoviePostersDbContext context)
        {
            _context = context;
        }

        //NOTE: Only for testing...
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
        
        /* 
        /// <summary>
        /// Updates one specified review
        /// </summary>
        /// <param name="body">Update review schema</param>
        /// <param name="moviePosterId">Search reviews by poster id</param>
        /// <param name="reviewId">Perform action by review id</param>
        /// <response code="200">Provides copy of the updated review</response>
        /// <response code="400">Invalid action parameters</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpPut]
        [Route("{reviewId:int}")]
        // [ValidateModelState]
        // [SwaggerOperation("UpdateReviewById")]
        // [SwaggerResponse(statusCode: 200, type: typeof(Review), description: "Provides copy of the updated review")]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        // [SwaggerResponse(statusCode: 404, type: typeof(Error), description: "Specified resource was not found")]
        public virtual IActionResult UpdateReviewById([FromBody]Review body, [FromRoute][Required]int? moviePosterId, [FromRoute][Required]int? reviewId)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Review));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(Error));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401, default(Error));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(Error));
            string exampleJson = null;
            exampleJson = "{\n  \"moviePosterId\" : 2,\n  \"name\" : \"Hauer\",\n  \"rating\" : 4,\n  \"comment\" : \"Like tears in rain...\",\n  \"postedDate\" : \"2017-07-21T17:32:28.000Z\"\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<Review>(exampleJson)
                        : default(Review);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Deletes one specified review
        /// </summary>
        /// <param name="moviePosterId">Search reviews by poster id</param>
        /// <param name="reviewId">Perform action by review id</param>
        /// <response code="204">Inherent confirmation of deletion</response>
        /// <response code="400">Invalid action parameters</response>
        /// <response code="401">User is unauthorized to access this resource</response>
        /// <response code="404">Specified resource was not found</response>
        [HttpDelete]
        [Route("{reviewId:int}")]
        // [ValidateModelState]
        // [SwaggerOperation("DeleteReviewById")]
        // [SwaggerResponse(statusCode: 400, type: typeof(Error), description: "Invalid action parameters")]
        // [SwaggerResponse(statusCode: 401, type: typeof(Error), description: "User is unauthorized to access this resource")]
        // [SwaggerResponse(statusCode: 404, type: typeof(Error), description: "Specified resource was not found")]
        public virtual IActionResult DeleteReviewById([FromRoute][Required]int? moviePosterId, [FromRoute][Required]int? reviewId)
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