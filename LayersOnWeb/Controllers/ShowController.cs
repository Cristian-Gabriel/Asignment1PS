using BusinessLayer.Contracts;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;
        public ShowController(IShowService showService)
        {
            _showService = showService;
        }
        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        public async Task<List<ShowModel>> GetShows()
        {
            var result = _showService.GetShows();
            return result;
        }
        [HttpPost("")]
        [Authorize(Roles = "Admin")]
        public void PostShow(ShowModel showModel)
        {
            _showService.PostShow(showModel);
        }
        [HttpGet("Exist")]
        [AllowAnonymous]
        public bool ExistShow(DateTime date)
        {
            return _showService.ExistShow(date);
        }
        [HttpDelete("")]
        [Authorize(Roles = "Admin")]
        public void DeleteShow(int id)
        {
            _showService.DeleteShow(id);
        }
        [HttpPut("")]
        [Authorize(Roles = "Admin")]
        public void ChangeShow(ShowEntity showEntity, int id)
        {
            _showService.ChangeShow(showEntity, id);
        }
    }
}
