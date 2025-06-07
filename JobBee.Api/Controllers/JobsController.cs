using JobBee.Application.Features.Job.Commands.CreateJob;
using JobBee.Application.Features.Job.Queries.GetAllJobs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;

namespace JobBee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetJobs([FromQuery] GetAllJobsQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobCommand command, IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
