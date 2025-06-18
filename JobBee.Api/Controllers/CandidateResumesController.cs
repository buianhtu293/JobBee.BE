using JobBee.Application.Features.CandidateResume.Commands.CreateCandidateResume;
using JobBee.Application.Features.CandidateResume.Commands.DeleteCandidateResume;
using JobBee.Application.Features.CandidateResume.Queries.GetAllCandidateResume;
using JobBee.Application.Features.CandidateResume.Queries.GetCandidateResumeDetail;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(CandidateResumeRoutes.Index)]
	[ApiController]
	public class CandidateResumesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CandidateResumesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		[Route(CandidateResumeRoutes.ACTION.CreateCandidateResume)]
		public async Task<IActionResult> CreateCandidateResume([FromForm] CreateCandidateResumeCommand createCandidateResumeCommand)
		{
			var result = await _mediator.Send(createCandidateResumeCommand);
			return Ok(result);
		}

		[HttpDelete]
		[Route(CandidateResumeRoutes.ACTION.DeleteCandidateResume)]
		public async Task<ActionResult> DeleteCandidateResume([FromRoute] Guid id)
		{
			var command = new DeleteCandidateResumeCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpGet]
		[Route(CandidateResumeRoutes.ACTION.GetCandidateResumeByCandidateId)]
		public async Task<ActionResult> GetCandidateResumeByCandidateId([FromRoute] Guid id)
		{
			var candidateResumes = await _mediator.Send(new GetCandidateResumeByCandidateIdQuery(id));
			return Ok(candidateResumes);
		}

		[HttpGet]
		[Route(CandidateResumeRoutes.ACTION.GetCandidateResumeDetail)]
		public async Task<ActionResult> GetCandidateResumeDetail([FromRoute] Guid id)
		{
			var candidateResume = await _mediator.Send(new GetCandidateResumeDetailQuery(id));
			return Ok(candidateResume);
		}
	}
}
