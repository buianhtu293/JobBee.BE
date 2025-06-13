using JobBee.Application.Features.Candidate.Commands.CreateCandidate;
using JobBee.Application.Features.Candidate.Commands.DeleteCandidate;
using JobBee.Application.Features.Candidate.Commands.UpdateCandidate;
using JobBee.Application.Features.Candidate.Queries.GetAllCandidate;
using JobBee.Application.Features.Candidate.Queries.GetCandidateDetail;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobBee.Api.Controllers
{
	[Route(CandidateRoutes.Index)]
	[ApiController]
	public class CandidatesController : ControllerBase
	{

		private readonly IMediator _mediator;

		public CandidatesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		
		[HttpGet]
		[Route(CandidateRoutes.ACTION.GetListCandidate)]
		public async Task<ActionResult> GetAllCandidate()
		{
			var candidates = await _mediator.Send(new CandidateQuery());
			return Ok(candidates);
		}

		
		[HttpGet]
		[Route(CandidateRoutes.ACTION.GetCandidateDetail)]
		public async Task<ActionResult> GetCandidateDetail([FromRoute] Guid id)
		{
			var candidateDetails = await _mediator.Send(new CandidateDetailQuery(id));
			return Ok(candidateDetails);
		}

		
		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(CandidateRoutes.ACTION.CreateCandidate)]
		public async Task<ActionResult> CreateCandidate([FromBody] CreateCandidateCommand createCandidateCommand)
		{
			var response = await _mediator.Send(createCandidateCommand);
			return Ok(response);
		}

		
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(CandidateRoutes.ACTION.UpdateCandidate)]
		public async Task<ActionResult> Put([FromBody] UpdateCandidateCommand updateCandidateCommand)
		{
			var response = await _mediator.Send(updateCandidateCommand);
			return Ok(response);
		}

		
		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(CandidateRoutes.ACTION.DeleteCandidate)]
		public async Task<ActionResult> Delete([FromRoute] Guid id)
		{
			var command = new DeleteCandidateCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
