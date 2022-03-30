using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface ITicketService
    {
        List<TicketModel> GetTickets();
        List<TicketModel> GetTicketsShow(int showId);
        bool ExistTicket(int row, int col);
        void PostTicket(TicketModel ticketModel);
        void DeleteTicket(int id);
        void PutTicket(TicketModel ticketModel, int id);
    }
}
