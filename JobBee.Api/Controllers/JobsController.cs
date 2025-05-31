using JobBee.Application.Features.Job.Commands.CreateJob;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
