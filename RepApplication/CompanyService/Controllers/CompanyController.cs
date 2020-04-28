using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyService.Api.Commands;
using CompanyService.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator mediator;

        public CompanyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCompanyCommand command)
        {
            var result = await mediator.Send(command);
            return new JsonResult(result);
        }

        [HttpGet()]
        public async Task<ActionResult> FindByCode([FromQuery]int codeType, string code)
        {
            var result = await mediator.Send(new FindCompanyByCodeQuery { CodeType = (Api.Queries.CompanyCodeType)codeType, Code = code });
            return new JsonResult(result);
        }
    }
}