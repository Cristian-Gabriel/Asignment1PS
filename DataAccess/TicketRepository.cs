using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TicketRepository : ITicketRepository
    {
        private readonly WeatherDbContext weatherDbContext;
        public TicketRepository(WeatherDbContext weatherDbContext)
        {
            this.weatherDbContext = weatherDbContext;
        }
        public void Add(TicketEntity weather)
        {
            weatherDbContext.Add(weather);
            weatherDbContext.SaveChanges();
        }

        public void ChangeTicket(TicketEntity ticketModel, int id)
        {
            var ticket = weatherDbContext.TicketEntities.Find(id);
            ticket.Price=ticketModel.Price;
            ticket.Col=ticketModel.Col;
            ticket.Row=ticketModel.Row;
            ticket.Sold=ticketModel.Sold;
            weatherDbContext.SaveChanges();
        }
        public List<TicketEntity> GetAll()
        {
            return weatherDbContext.TicketEntities.ToList();
        }
        public List<TicketEntity> GetAllTicketsShow(int id)
        {
            List<TicketEntity> tickets;
            tickets = weatherDbContext.TicketEntities.ToList();
            for(int i = 0; i < tickets.Count; i++)
            {
                if (tickets[i].ShowId != id || (tickets[i].ShowId != id && tickets[i].Sold == true))
                {
                    tickets.Remove(tickets[i]);
                    i--;
                }
            }
            return tickets;
        }
        public void RemoveTicket(int id)
        {
            weatherDbContext.Remove(weatherDbContext.TicketEntities.First(s => s.Id == id));
            weatherDbContext.SaveChanges();
        }
    }
}
