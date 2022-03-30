using BusinessLayer;
using BusinessLayer.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayersOnWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService ticketService;
        private readonly IShowService showService;
        private readonly IShowMapper showMapper;
        public TicketsController(ITicketService ticketService, IShowService showService, IShowMapper showMapper)
        {
            this.ticketService = ticketService;
            this.showMapper = showMapper;
            this.showService = showService;
        }

        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Cashier")]
        public async Task<List<TicketModel>> GetTickets()
        {
            var result = ticketService.GetTickets();
            return result;
        }
        [HttpPost("")]
        [Authorize(Roles = "Admin")]
        public void PostTicket(TicketModel ticketModel)
        {
            ticketService.PostTicket(ticketModel);
        }
        [HttpGet("Exist")]
        [AllowAnonymous]
        public bool ExistTicket(int row, int col)
        {
            return ticketService.ExistTicket(row, col);
        }
        [HttpDelete("")]
        [Authorize(Roles = "Admin")]
        public void DeleteTicket(int id)
        {
            ticketService.DeleteTicket(id);
        }
        [HttpPut("")]
        [Authorize(Roles = "Admin")]
        public void ChangeTicket(TicketModel ticketModel, int id)
        {
            ticketService.PutTicket(ticketModel, id);
        }
        [HttpPut("SellTickets")]
        [Authorize(Roles = "Cashier")]
        public void SellTickets(int idShow, int row, int col)
        {
            var resultShows = showService.GetShows();
            for (int i = 0; i < resultShows.Count(); i++)
            {
                if (resultShows[i].Id == idShow)
                {
                    if (resultShows[i].NumberOfTickets > 0)
                    {
                        resultShows[i].NumberOfTickets -= 1;
                        showService.ChangeShow(showMapper.Map(resultShows[i]), resultShows[i].Id);
                        var result = ticketService.GetTickets();
                        for(int j=0;j<result.Count(); j++)
                        {
                            if(result[j].Sold == false && result[j].ShowId == idShow && result[j].Row == row && result[j].Col == col)
                            {
                                result[j].Sold = true;
                                ticketService.PutTicket(result[j], result[j].Id);
                                break;
                            }
                        }
                        break;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
        }
        [HttpPut("CancelReservation")]
        [Authorize(Roles = "Cashier")]
        public void CancelReservation(int idShow, int row, int col)
        {
            var resultShows = showService.GetShows();
            for (int i = 0; i < resultShows.Count(); i++)
            {
                if (resultShows[i].Id == idShow)
                {
                    if (resultShows[i].NumberOfTickets > 0)
                    {
                        resultShows[i].NumberOfTickets += 1;
                        showService.ChangeShow(showMapper.Map(resultShows[i]), resultShows[i].Id);
                        var result = ticketService.GetTickets();
                        for (int j = 0; j < result.Count(); j++)
                        {
                            if (result[j].Sold == true && result[j].ShowId == idShow && result[j].Row == row && result[j].Col == col)
                            {
                                result[j].Sold = false;
                                ticketService.PutTicket(result[j], result[j].Id);
                                break;
                            }
                        }
                        break;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
        }
        [HttpPut("EditReservedSeat")]
        [Authorize(Roles = "Cashier")]
        public void EditReservedSeat(int idShow, int initialRow, int initialCol, int newRow, int newCol)
        {
            var resultShows = showService.GetShows();
            for (int i = 0; i < resultShows.Count(); i++)
            {
                if (resultShows[i].Id == idShow)
                {
                    if (resultShows[i].NumberOfTickets > 0)
                    {
                        var result = ticketService.GetTickets();
                        for (int j = 0; j < result.Count(); j++)
                        {
                            if (result[j].Sold == true && result[j].ShowId == idShow && result[j].Row == initialRow && result[j].Col == initialCol)
                            {
                                result[j].Sold = false;
                                ticketService.PutTicket(result[j], result[j].Id);
                                resultShows[i].NumberOfTickets += 1;
                                showService.ChangeShow(showMapper.Map(resultShows[i]), resultShows[i].Id);
                            }
                            if (result[j].Sold == false && result[j].ShowId == idShow && result[j].Row == newRow && result[j].Col == newCol)
                            {
                                result[j].Sold = true;
                                ticketService.PutTicket(result[j], result[j].Id);
                                resultShows[i].NumberOfTickets -= 1;
                                showService.ChangeShow(showMapper.Map(resultShows[i]), resultShows[i].Id);
                            }
                        }
                        break;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
        }
        [HttpGet("ShowTickets")]
        [Authorize(Roles = "Cashier")]
        public async Task<List<TicketModel>> GetTicketsShow(int id)
        {
            var result = ticketService.GetTicketsShow(id);
            return result;
        }
        [HttpGet("csv")]
        [Authorize(Roles = "Admin")]
        public void TicketsToCsv(int id)
        {
            List<TicketModel> result = ticketService.GetTickets();
            var csv = new StreamWriter("file.csv");
            if (result != null)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    if (id == result[i].ShowId && result[i].Sold == true)
                    {
                        var line = "id: " + result[i].Id;
                        csv.WriteLine(line);
                        csv.Flush();
                    }
                }
            }
        }
    }
}
