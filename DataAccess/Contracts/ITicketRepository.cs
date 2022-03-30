using System.Collections.Generic;

namespace DataAccess.Contracts
{
    public interface ITicketRepository
    {
        List<TicketEntity> GetAll();
        List<TicketEntity> GetAllTicketsShow(int id);
        void Add(TicketEntity ticket);
        void ChangeTicket(TicketEntity ticketModel, int id);
        void RemoveTicket(int id);
    }
}
