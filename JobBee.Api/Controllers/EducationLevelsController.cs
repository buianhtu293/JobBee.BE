using JobBee.Application.Features.EducationLevel.Commands.CreateEducationLevel;
using JobBee.Application.Features.EducationLevel.Commands.UpdateEducationLevel;
using JobBee.Application.Features.EducationLevel.Queries.GetAllEducationLevel;
using JobBee.Application.Features.EducationLevel.Queries.GetEducationLevelDetail;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(EducationLevelRoutes.Index)]
	[ApiController]
	public class EducationLevelsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public EducationLevelsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route(EducationLevelRoutes.ACTION.GetListEducationLevel)]
		public async Task<ActionResult> GetListEducationLevel()
		{
			var educationLevels = await _mediator.Send(new EducationLevelQuery());
			return Ok(educationLevels);
		}

		[HttpGet]
		[Route(EducationLevelRoutes.ACTION.GetEducationLevelDetail)]
		public async Task<ActionResult> GetEducationLevelDetail([FromRoute] Guid id)
		{
			var educationLevelDetail = await _mediator.Send(new EducationLevelDetailQuery(id));
			return Ok(educationLevelDetail);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(EducationLevelRoutes.ACTION.CreateEducationLevel)]
		public async Task<ActionResult> CreateEducationLevel([FromBody] CreateEducationLevelCommand createEducationLevelCommand)
		{
			var response = await _mediator.Send(createEducationLevelCommand);
			return Ok(response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(EducationLevelRoutes.ACTION.UpdateEducationLevel)]
		public async Task<ActionResult> UpdateEducationLevel([FromBody] UpdateEducationLevelCommand updateEducationLevelCommand)
		{
			var response = await _mediator.Send(updateEducationLevelCommand);
			return Ok(response);
		}
	}
}
