using System;

namespace DataAccess.Contracts
{
    public class TicketEntity
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public int ShowId { get; set; }
        public bool Sold { get; set; }
    }
}
