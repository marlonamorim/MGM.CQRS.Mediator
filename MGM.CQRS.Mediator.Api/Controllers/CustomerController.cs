using System.Threading.Tasks;
using MediatR;
using MGM.CQRS.Mediator.Domain.Commands.Requests;
using MGM.CQRS.Mediator.Domain.Queries.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MGM.CQRS.Mediator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetById(
            [FromServices]IMediator mediator,
            [FromQuery]FindCustomerByIdRequest querie
        )
        {
            var result = await mediator.Send(querie);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(
                   [FromServices]IMediator mediator,
                   [FromBody]CreateCustomerRequest command
               )
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}