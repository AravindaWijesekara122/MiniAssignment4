using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.IServices;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IMovieService _movieService;

        public CustomerController(ITicketService ticketService, IMovieService movieService)
        {
            _ticketService = ticketService;
            _movieService = movieService;
        }
        [HttpPost("bookticket")]
        public IActionResult BookTicket([FromBody] TicketBookingRequest request)
        {
            try
            {
                Ticket newTicket = new Ticket();
                
                newTicket.ShowDate = request.ShowDate;
                newTicket.ShowTime = request.ShowTime;
                newTicket.NoOfSeatBooked = request.NoOfSeatBooked;
                newTicket.UserId = request.UserId;
                newTicket.ShowId = request.ShowId;

                _ticketService.BookTicket(newTicket);

                //TicketDetailsDTO ticketDetailsDTO = new TicketDetailsDTO();
                //Movie movie = _movieService.GetMovie(request.ShowId);
                //Show show = _movieService.GetShow(request.ShowId);
                //Console.WriteLine(movie.MovieName);
                //ticketDetailsDTO.MovieName = movie.MovieName;
                //ticketDetailsDTO.ScreenNumber = show.ScreenNumber;
                //ticketDetailsDTO.NoOfSeatsBooked = request.NoOfSeatBooked;
                //ticketDetailsDTO.PerPersonPrice = show.Price;
                //ticketDetailsDTO.TotalAmount = 


                return Ok(new { Message = "Ticket booked successfully!"});
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to book ticket: {ex.Message}");
            }
        }

        [HttpGet("all-tickets")]
        public IActionResult GetAllTickets()
        {
            try
            {
                var tickets = _ticketService.GetAllTickets();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to load tickets: {ex.Message}");
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
            try
            {
                var shows = _movieService.GetAllShows(movieId);
                return Ok(shows);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        [HttpGet("tickets/{userId}")]
        public IActionResult GetTicketsForCustomer(int userId)
        {
            try
            {
                var tickets = _ticketService.GetTicketsForCustomer(userId);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to load tickets: {ex.Message}");
            }
            
        }
    }
}
