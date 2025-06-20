using JobBee.Application.Features.SavedCandidate.Commands.CreateSavedCandidate;
using JobBee.Application.Features.SavedCandidate.Commands.DeleteSavedCandidate;
using JobBee.Application.Features.SavedCandidate.Queries.GetSavedCandidateByEmployer;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(SavedCandidateRoutes.Index)]
	[ApiController]
	public class SavedCandidatesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SavedCandidatesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(SavedCandidateRoutes.ACTION.CreateSavedCandidate)]
		public async Task<ActionResult> CreateSavedCandidate([FromBody] CreateSavedCandidateCommand createSavedCandidateCommand)
		{
			var response = await _mediator.Send(createSavedCandidateCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(SavedCandidateRoutes.ACTION.DeleteSavedCandidate)]
		public async Task<ActionResult> DeleteSavedCandidate([FromBody] DeleteSavedCandidateCommand deleteSavedCandidateCommand)
		{
			var command = new DeleteSavedCandidateCommand { EmployerId = deleteSavedCandidateCommand.EmployerId, CandidateId = deleteSavedCandidateCommand.CandidateId };
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpGet]
		[Route(SavedCandidateRoutes.ACTION.GetSavedCandidateByEmployer)]
		public async Task<ActionResult> GetSavedCandidateByEmployer([FromQuery] GetSavedCandidateByEmployerQuery query)
		{
			var savedCandidates = await _mediator.Send(query);
			return Ok(savedCandidates);
		}
	}
}
