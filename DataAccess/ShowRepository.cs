using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ShowRepository : IShowRepository
    {
        private readonly WeatherDbContext weatherDbContext;
        public ShowRepository(WeatherDbContext weatherDbContext)
        {
            this.weatherDbContext = weatherDbContext;
        }
        public void Add(ShowEntity show)
        {
            weatherDbContext.Add(show);
            weatherDbContext.SaveChanges();
            var p = (new Random().Next()) % 100;
            for (int i = 0; i < show.TotalNumberOfTickets; i++)
            {
                TicketEntity ticket = new TicketEntity();
                ticket.Price = p;
                ticket.Row = (i / 20) + 1;
                ticket.Col = (i % 20) + 1;
                ticket.ShowId = show.Id;
                ticket.Sold = false;
                weatherDbContext.Add(ticket);
                weatherDbContext.SaveChanges();
            }
        }
        public List<ShowEntity> GetAll()
        {
            return weatherDbContext.ShowEntities.ToList();
        }
        public void RemoveShow(int id)
        {
            weatherDbContext.Remove(weatherDbContext.ShowEntities.First(s => s.Id == id));
            weatherDbContext.SaveChanges();
        }
        public void ChangeShow(ShowEntity showEntity, int id)
        {
            var show = weatherDbContext.ShowEntities.Find(id);
            show.Genre=showEntity.Genre;
            show.Title=showEntity.Title;
            show.NumberOfTickets=showEntity.NumberOfTickets;
            show.Time=showEntity.Time;
            weatherDbContext.SaveChanges();
        }
    }
}
