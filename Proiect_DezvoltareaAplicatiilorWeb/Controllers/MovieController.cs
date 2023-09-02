using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;
using Proiect_DezvoltareaAplicatiilorWeb.Services.MovieService;

namespace Proiect_DezvoltareaAplicatiilorWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public readonly IMovieService movieService;

        public MovieController(IMovieService movieService) 
        {
            this.movieService = movieService;
        }

        [HttpPut("update-movie")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> UpdateMovie(MovieDTO _movie, Guid movieId)
        {
            var movie = await movieService.Update(movieId, _movie);
            if (movie == null) 
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet("get-all-movies")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> GetAllMovies()
        {
            return Ok(await movieService.GetAll());
        }

        [HttpPost("add-a-movie")]
        public async Task<IActionResult> AddMovie(MovieDTO _movie)
        {
            await movieService.Create(_movie);
            return Ok();
        }

        [HttpDelete("delete-movie")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> DeleteMovie(Guid Id)
        {
            await movieService.Delete(Id);
            return Ok("Movie was succesfully deleted.");
        }

        [HttpGet("get-movies-by-studio")]
        public async Task<IActionResult> GetMovieByStudio(string Studio)
        {
            var movies = movieService.GetByStudio(Studio);
            return Ok(movies);
        }
    }
}
