using JobBee.Application.Features.JobType.Commands.CreateJobType;
using JobBee.Application.Features.JobType.Commands.DeleteJobType;
using JobBee.Application.Features.JobType.Commands.UpdateJobType;
using JobBee.Application.Features.JobType.Queries.GetAllJobType;
using JobBee.Application.Features.JobType.Queries.GetJobTypeDetail;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(JobTypeRoutes.Index)]
	[ApiController]
	public class JobTypesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public JobTypesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route(JobTypeRoutes.ACTION.GetListJobType)]
		public async Task<ActionResult> GetListJobType()
		{
			var jobTypes = await _mediator.Send(new GetAllJobTypeQuery());
			return Ok(jobTypes);
		}

		[HttpGet]
		[Route(JobTypeRoutes.ACTION.GetJobTypeDetail)]
		public async Task<ActionResult> GetJobTypeDetail([FromRoute] Guid id)
		{
			var jobTypeDetail = await _mediator.Send(new JobTypeDetailQuery(id));
			return Ok(jobTypeDetail);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(JobTypeRoutes.ACTION.CreateJobType)]
		public async Task<ActionResult> CreateJobType([FromBody] CreateJobTypeCommand createJobTypeCommand)
		{
			var response = await _mediator.Send(createJobTypeCommand);
			return Ok(response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(JobTypeRoutes.ACTION.UpdateJobType)]
		public async Task<ActionResult> UpdateJobType([FromBody] UpdateJobTypeCommand updateJobTypeCommand)
		{
			var response = await _mediator.Send(updateJobTypeCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(JobTypeRoutes.ACTION.DeleteJobType)]
		public async Task<ActionResult> DeleteJobType([FromRoute] Guid id)
		{
			var command = new DeleteJobTypeCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
