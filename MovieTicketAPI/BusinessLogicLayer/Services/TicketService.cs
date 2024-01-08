using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.IServices;
using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _dbContext;
        public TicketService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void BookTicket(Ticket ticket)
        {
            try
            {
                var show = _dbContext.Shows.Find(ticket.ShowId);
                var user = _dbContext.Users.Find(ticket.UserId);

                if (show == null || user == null)
                {
                    throw new CustomException("Show or User is NULL");
                }
                else
                {
                    if (show.NoOfSeats > 0 && show.NoOfSeats > ticket.NoOfSeatBooked && ticket.NoOfSeatBooked <= 10)
                    {
                        var newTicket = new Ticket
                        {
                            BookingDate = DateTime.Now,
                            ShowDate = ticket.ShowDate,
                            ShowTime = ticket.ShowTime,
                            NoOfSeatBooked = ticket.NoOfSeatBooked,
                            TotalAmount = show.Price * ticket.NoOfSeatBooked,
                            UserId = ticket.UserId,
                            ShowId = ticket.ShowId,
                            User = user,
                            Show = show

                        };

                        show.NoOfSeats = show.NoOfSeats - ticket.NoOfSeatBooked;
                        user.Tickets.Add(newTicket);
                        show.Tickets.Add(newTicket);
                        _dbContext.Tickets.Add(newTicket);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        throw new CustomException("Seat Limit Exceeded.");
                    }
                }
            }

            catch (CustomException Ex)
            {
                throw new CustomException(Ex.Message); 
            } 
        }


        public void DeleteTicket(int ticketId)
        {
            try
            {
                var ticketToDelete = _dbContext.Tickets.Find(ticketId);
                if (ticketToDelete == null)
                {
                    throw new CustomException("Ticket Not Found.");
                }
                _dbContext.Tickets.Remove(ticketToDelete);
                _dbContext.SaveChanges();
            }
            catch (CustomException Ex)
            {
                throw new CustomException(Ex.Message);
            }

        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            try
            {
                var ticketList = _dbContext.Tickets.ToList();
                if (ticketList.Count == 0) 
                {
                    throw new CustomException("No tickets found");
                }

                return ticketList;
            }
            catch (CustomException Ex)
            {
                throw new CustomException(Ex.Message);
            }
            
        }

        public IEnumerable<Ticket> GetTicketsForCustomer(int userId)
        {
            try
            {
                var tickets = _dbContext.Tickets
                .Where(ticket => ticket.UserId == userId)
                .ToList();

                if (tickets.Count == 0)
                {
                    throw new CustomException("User Not Found");
                }
                return tickets;
            }
            catch (CustomException Ex)
            {
                throw new CustomException(Ex.Message);
            }
            
        }
    }
}
