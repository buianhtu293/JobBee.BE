using JobBee.Application.Features.JobAlert.Commands.CreateJobAlert;
using JobBee.Application.Features.JobAlert.Commands.DeleteJobAlert;
using JobBee.Application.Features.JobAlert.Queries.GetJobAlertByCandidateId;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(JobAlertRoutes.Index)]
	[ApiController]
	public class JobAlertsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public JobAlertsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(JobAlertRoutes.ACTION.CreateJobAlert)]
		public async Task<ActionResult> CreateJobAlert([FromBody] CreateJobAlertCommand createJobAlertCommand)
		{
			var response = await _mediator.Send(createJobAlertCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(JobAlertRoutes.ACTION.DeleteJobAlert)]
		public async Task<ActionResult> DeleteJobAlert([FromBody] DeleteJobAlertCommand deleteJobAlertCommand)
		{
			var command = new DeleteJobAlertCommand { CandidateId = deleteJobAlertCommand.CandidateId, JobId = deleteJobAlertCommand.JobId };
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpGet]
		[Route(JobAlertRoutes.ACTION.GetJobAlertByCandidateId)]
		public async Task<ActionResult> GetJobAlertByCandidateId([FromQuery] GetJobAlertByCandidateQuery query)
		{
			var jobAlerts = await _mediator.Send(query);
			return Ok(jobAlerts);
		}

	}
}
