using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.API.ExceptionHelpers;
using Server.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly ExceptionMessageService _messageService;
        public HomeController(ExceptionMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> Home(int request)
        {
            if (request == 0)
            {
                throw new CustomAppExeption(_messageService.Serializer(
                    new ExceptionResult { ExceptionMessage = "Exsits ID", ResultType = ResultType.Conflict }));
            }

            else if (request == 1)
            {
                throw new CustomAppExeption( _messageService.Serializer(
                    new ExceptionResult { ExceptionMessage = "Ivalid Id", ResultType = ResultType.BadRequest }));
            }
            return Ok();
        }


    }
}

