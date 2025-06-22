using JobBee.Application.Features.JobApplication.Commands.CreateJobAppliaction;
using JobBee.Application.Features.JobApplication.Commands.DeleteJobApplication;
using JobBee.Application.Features.JobApplication.Commands.UpdateJobApplication;
using JobBee.Application.Features.JobApplication.Queries.GetJobAppicationByCandidateId;
using JobBee.Application.Features.JobApplication.Queries.GetJobApplicationByJobId;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(JobApplicationRoutes.Index)]
	[ApiController]
	public class JobApplicationsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public JobApplicationsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(JobApplicationRoutes.ACTION.CreateJobApplication)]
		public async Task<ActionResult> CreateJobApplication([FromBody] CreateJobApplicationCommand createJobApplicationCommand)
		{
			var response = await _mediator.Send(createJobApplicationCommand);
			return Ok(response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(JobApplicationRoutes.ACTION.UpdateJobApplication)]
		public async Task<ActionResult> UpdateJobApplication([FromBody] UpdateJobApplicationCommand updateJobApplicationCommand)
		{
			var response = await _mediator.Send(updateJobApplicationCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(JobApplicationRoutes.ACTION.DeleteJobApplication)]
		public async Task<ActionResult> DeleteJobApplication([FromRoute] Guid id)
		{
			var command = new DeleteJobApplicationCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpGet]
		[Route(JobApplicationRoutes.ACTION.GetJobApplicationByCandidateId)]
		public async Task<ActionResult> GetJobApplicationByCandidateId([FromQuery] GetJobApplicationByCandidateIdQuery query)
		{
			var jobApplications = await _mediator.Send(query);
			return Ok(jobApplications);
		}

		[HttpGet]
		[Route(JobApplicationRoutes.ACTION.GetCandidateApplicationByJobId)]
		public async Task<ActionResult> GetCandidateApplicationByJobId([FromQuery] GetCandidateApplicationByJobQuery query)
		{
			var candidateApplications = await _mediator.Send(query);
			return Ok(candidateApplications);
		}

	}
}
