using BusinessLayer.Contracts;
using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ShowMapper : IShowMapper
    {
        private readonly ITicketMapper _ticketMapper;
        public ShowModel Map(ShowEntity showEntity)
        {
            ShowModel model = new ShowModel();
            model.Id = showEntity.Id;
            model.Date = showEntity.Date;
            model.Time = showEntity.Time;
            model.Title = showEntity.Title;
            model.Genre = showEntity.Genre;
            model.NumberOfTickets = showEntity.NumberOfTickets;
            model.TotalNumberOfTickets = showEntity.TotalNumberOfTickets;
            return model;
        }
        public ShowEntity Map(ShowModel showModel)
        {
            ShowEntity model = new ShowEntity();
            model.Id = showModel.Id;
            model.Date = showModel.Date;
            model.Time = showModel.Time;
            model.Title = showModel.Title;
            model.Genre = showModel.Genre;
            model.NumberOfTickets = showModel.NumberOfTickets;
            model.TotalNumberOfTickets= showModel.TotalNumberOfTickets;
            return model;
        }
    }
}
