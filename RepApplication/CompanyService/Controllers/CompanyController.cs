using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyService.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator bus;

        public CompanyController(IMediator bus)
        {
            this.bus = bus;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCompanyCommand command)
        {
            var result = await bus.Send(command);
            return new JsonResult(result);
        }
    }
}