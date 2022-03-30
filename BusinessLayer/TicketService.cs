using BusinessLayer.Contracts;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;
        private readonly ITicketMapper ticketMapper;
        public TicketService(ITicketRepository ticketRepository, ITicketMapper ticketMapper)
        {
            this.ticketRepository = ticketRepository;
            this.ticketMapper = ticketMapper;
        }

        public void DeleteTicket(int id)
        {
            ticketRepository.RemoveTicket(id);
        }

        public bool ExistTicket(int row, int col)
        {
            List<TicketEntity> shows = ticketRepository.GetAll();
            List<TicketModel> results = new List<TicketModel>();
            shows.ForEach(x => results.Add(ticketMapper.Map(x)));
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].Row == row && results[i].Col == col)
                    return true;
            }
            return false;
        }
        public List<TicketModel> GetTickets()
        {
            List<TicketEntity> ticket = ticketRepository.GetAll();
            List<TicketModel> results = new List<TicketModel>();
            ticket.ForEach(x => results.Add(ticketMapper.Map(x)));
            return results;
        }

        public List<TicketModel> GetTicketsShow(int showId)
        {
            List<TicketEntity> ticket = ticketRepository.GetAllTicketsShow(showId);
            List<TicketModel> results = new List<TicketModel>();
            ticket.ForEach(x => results.Add(ticketMapper.Map(x)));
            return results;
        }

        public void PostTicket(TicketModel ticketModel)
        {
            var ticket = ticketMapper.Map(ticketModel);
            ticketRepository.Add(ticket);
        }

        public void PutTicket(TicketModel ticketModel, int id)
        {
            ticketRepository.ChangeTicket(ticketMapper.Map(ticketModel), id);
        }
    }
}
