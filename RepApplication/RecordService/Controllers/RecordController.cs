using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecordService.Api.Commands;

namespace RecordService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IMediator mediator;

        public RecordController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RegisterRecordCommand command)
        {
            var result = await mediator.Send(command);
            return new JsonResult(result);
        }
    }
}