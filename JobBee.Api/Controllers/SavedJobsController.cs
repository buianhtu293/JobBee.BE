using JobBee.Application.Features.SavedJob.Commands.CreateSavedJob;
using JobBee.Application.Features.SavedJob.Commands.DeleteSavedJob;
using JobBee.Application.Features.SavedJob.Queries.GetSavedJobByCandidateId;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(SavedJobRoutes.Index)]
	[ApiController]
	public class SavedJobsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SavedJobsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(SavedJobRoutes.ACTION.CreateSavedJob)]
		public async Task<ActionResult> CreateSavedJob([FromBody] CreateSavedJobCommand createSavedJobCommand)
		{
			var response = await _mediator.Send(createSavedJobCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(SavedJobRoutes.ACTION.DeleteSavedJob)]
		public async Task<ActionResult> DeleteSavedJob([FromBody] DeleteSavedJobCommand deleteSavedJobCommand)
		{
			var command = new DeleteSavedJobCommand { CandidateId = deleteSavedJobCommand.CandidateId, JobId = deleteSavedJobCommand.JobId};
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpGet]
		[Route(SavedJobRoutes.ACTION.GetSavedJobByCandidateId)]
		public async Task<ActionResult> GetSavedJobByCandidateId([FromQuery] GetSavedJobByCandidateQuery query)
		{
			var savedJobs = await _mediator.Send(query);
			return Ok(savedJobs);
		}

	}
}
