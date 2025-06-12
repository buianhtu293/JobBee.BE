using JobBee.Application.Features.CandidateEducation.Commands.AddCandidateEducation;
using JobBee.Application.Features.CandidateEducation.Commands.DeleteCandidateEducation;
using JobBee.Application.Features.CandidateEducation.Commands.UpdateCandidateEducation;
using JobBee.Application.Features.CandidateEducation.Queries.GetAllCandidateEducation;
using JobBee.Application.Features.CandidateEducation.Queries.GetCandidateEducationByCandidateId;
using JobBee.Application.Features.CandidateEducation.Queries.GetCandidateEducationById;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(CandidateEducationRoutes.Index)]
	[ApiController]
	public class CandidateEducationsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CandidateEducationsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route(CandidateEducationRoutes.ACTION.GetListCandidateEducation)]
		public async Task<ActionResult> GetListCandidateEducation()
		{
			var candidateEducations = await _mediator.Send(new CandidateEducationQuery());
			return Ok(candidateEducations);
		}

		[HttpGet]
		[Route(CandidateEducationRoutes.ACTION.GetCandidateEducationDetail)]
		public async Task<ActionResult> GetCandidateEducationDetail([FromRoute] Guid id)
		{
			var candidateEducationDetail = await _mediator.Send(new CandidateEducationDetailQuery(id));
			return Ok(candidateEducationDetail);
		}

		[HttpGet]
		[Route(CandidateEducationRoutes.ACTION.GetCandidateEducationByCandidateId)]
		public async Task<ActionResult> GetCandidateEducationByCandidateId([FromRoute] Guid id)
		{
			var candidateEducations = await _mediator.Send(new CandidateEducationByCandidateIdQuery(id));
			return Ok(candidateEducations);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(CandidateEducationRoutes.ACTION.CreateCandidateEducation)]
		public async Task<ActionResult> CreateCandidateEducation([FromBody] CreateCandidateEducationCommand createCandidateEducationCommand)
		{
			var response = await _mediator.Send(createCandidateEducationCommand);
			return Ok(response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(CandidateEducationRoutes.ACTION.UpdateCandidateEducation)]
		public async Task<ActionResult> UpdateCandidateEducation([FromBody] UpdateCandidateEducationCommand updateCandidateEducationCommand)
		{
			var response = await _mediator.Send(updateCandidateEducationCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(CandidateEducationRoutes.ACTION.DeleteCandidateEducation)]
		public async Task<ActionResult> DeleteCandidateEducation([FromRoute] Guid id)
		{
			var command = new DeleteCandidateEducationCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}

	}
}
