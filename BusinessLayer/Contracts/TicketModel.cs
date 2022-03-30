using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public class PostTicketModel
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public int ShowId { get; set; }
        public bool Sold { get; set; }
    }
    public class TicketModel
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
