using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public class PutShowModel
    {
        public DateTime Date { get; set; }
        public int Time { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int NumberOfTickets { get; set; }
        public int TotalNumberOfTickets { get; set; }
    }
    public class PostShowModel
    {
        public DateTime Date { get; set; }
        public int Time { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int NumberOfTickets { get; set; }
        public int TotalNumberOfTickets { get; set; }
    }
    public class ShowModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Time { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int NumberOfTickets { get; set; }
        public int TotalNumberOfTickets { get; set; }
    }
}
