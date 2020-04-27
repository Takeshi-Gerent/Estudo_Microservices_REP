using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using EmployeeService.Api.Queries;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET api/employess/{pis}
        [HttpGet("{pis}")]
        public async Task<ActionResult> GetByPis([FromRoute]string pis)
        {
            var result = await mediator.Send(new FindEmployeeByPisQuery { Pis = pis });
            return new JsonResult(result);
        }
    }
}