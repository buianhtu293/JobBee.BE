using JobBee.Application.Features.Job.Queries.GetAllJobs;
using JobBee.Application.Features.Job.Queries.GetDetail;
using JobBee.Application.Features.Job.Queries.GetPostedJobs;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
    [Route(JobRoutes.Index)]
    [ApiController]
    public class JobsController(IMediator mediator) : ControllerBase
    {
        [HttpGet(JobRoutes.ACTION.GetListJobs)]
        public async Task<IActionResult> GetJobs([FromQuery] GetAllJobsQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route(JobRoutes.ACTION.GetDetail)]
        public async Task<IActionResult> GetDetail([FromRoute] Guid id)
        {
            var job = await mediator.Send(new GetJobDetailQuery() { Id = id });
            return Ok(job);
        }

        [HttpPost(JobRoutes.ACTION.Create)]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPost(JobRoutes.ACTION.GetPostedJob)]
		public async Task<IActionResult> GetPostedJob([FromBody] GetPostedJobQuery query)
		{
            var result = await mediator.Send(query);
            return Ok(result);
		}
	}
}
