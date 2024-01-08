using BusinessLogicLayer.IServices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("all-movies")]
        public IActionResult GetAllMovies()
        {
            var movies = _movieService.GetAllMovies();
            return Ok(movies);
        }

        [HttpGet("today-movies")]
        public IActionResult GetMoviesForToday()
        {
            try
            {
                var movies = _movieService.GetMoviesForToday();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }          
        }

        [HttpGet("selected-movies")]
        public IActionResult GetMoviesForDate([FromQuery] DateTime selectedDate)
        {
            try
            {
                var movies = _movieService.GetMoviesForDate(selectedDate);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("shows/{movieId}")]
        public IActionResult GetAllShows(int movieId)
        {
            var shows = _movieService.GetAllShows(movieId);
            return Ok(shows);
        }


        [HttpGet("for-show/{showId}")]
        public IActionResult GetMovieForShow(int showId)
        {
            try
            {
                var movie = _movieService.GetMovie(showId);
                Console.WriteLine(movie.MovieName);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to load Movie: {ex.Message}");
            }    
        }


        [HttpGet("{showId}")]
        public IActionResult GetShow(int showId)
        {
            var show = _movieService.GetShow(showId);

            if (show == null)
            {
                return NotFound(); // Return 404 if the show is not found for the given showId
            }

            return Ok(show);
        }
    }
}
