using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface ITicketService
    {
        void BookTicket(Ticket ticket);
        void DeleteTicket(int ticketId);
        IEnumerable<Ticket> GetAllTickets();
        IEnumerable<Ticket> GetTicketsForCustomer(int userId);
    }
}
