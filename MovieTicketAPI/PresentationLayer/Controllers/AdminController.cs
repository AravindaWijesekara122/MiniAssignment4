using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/admin")]
    //[Authorize(Policy = "AdminOnly")]
    public class AdminController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IShowService _showService;
        private readonly ITicketService _ticketService;

        public AdminController(IMovieService movieService, IShowService showService, ITicketService ticketService)
        {
            _movieService = movieService;
            _showService = showService;
            _ticketService = ticketService;
        }

        [HttpPost("addmovie")]
        public IActionResult AddMovie([FromBody] MovieDetailsDTO movieDetailsDTO)
        {
            try
            {
                // Call the movie service to add a movie
                _movieService.AddMovie(movieDetailsDTO);

                return Ok(new { Message = "Movie added successfully!" });
            }
            catch (InvalidOperationException ex)
            {
                // Catch the specific exception related to movie conflicts
                return BadRequest($"Failed to add movie: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Catch any other unexpected exceptions
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("currentshows")]
        public IActionResult GetCurrentShows()
        {
            try
            {
                // Call the show service to get all current shows
                var currentShows = _showService.GetCurrentShows();

                return Ok(currentShows);
            }
            catch (Exception ex)
            {
                return BadRequest($"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete("delete-movie/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                _movieService.DeleteMovie(id);
                return Ok("Movie deleted successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete-ticket/{id}")]
        public IActionResult DeleteTicket(int id)
        {
            try
            {
                _ticketService.DeleteTicket(id);
                return Ok("Ticket deleted successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
