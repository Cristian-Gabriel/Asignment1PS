using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contracts;
using DataAccess.Contracts;

namespace BusinessLayer
{
    public class TicketMapper : ITicketMapper
    {
        public TicketModel Map(TicketEntity ticketEntity)
        {
            return new TicketModel
            {
                Id = ticketEntity.Id,
                Row = ticketEntity.Row,
                Col = ticketEntity.Col,
                Price = ticketEntity.Price,
                Date = ticketEntity.Date,
                ShowId = ticketEntity.ShowId,
                Sold = ticketEntity.Sold
            };
        }
        public TicketEntity Map(TicketModel ticketModel)
        {
            return new TicketEntity
            {
                Id = ticketModel.Id,
                Row = ticketModel.Row,
                Col = ticketModel.Col,
                Price = ticketModel.Price,
                Date = ticketModel.Date,
                ShowId = ticketModel.ShowId,
                Sold = ticketModel.Sold
            };
        }
    }
}
