using JobBee.Application.Features.ExperienceLevel.Commands.CreateExperienceLevel;
using JobBee.Application.Features.ExperienceLevel.Commands.DeleteExperienceLevel;
using JobBee.Application.Features.ExperienceLevel.Commands.UpdateExperienceLevel;
using JobBee.Application.Features.ExperienceLevel.Queries.GetAllExperienceLevel;
using JobBee.Application.Features.ExperienceLevel.Queries.GetExperienceLevelDetail;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(ExperienceLevelRoutes.Index)]
	[ApiController]
	public class ExperienceLevelsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ExperienceLevelsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route(ExperienceLevelRoutes.ACTION.GetListExperienceLevel)]
		public async Task<ActionResult> GetListExperienceLevel()
		{
			var experienceLevels = await _mediator.Send(new GetAllExperienceLevelQuery());
			return Ok(experienceLevels);
		}

		[HttpGet]
		[Route(ExperienceLevelRoutes.ACTION.GetExperienceLevelDetail)]
		public async Task<ActionResult> GetExperienceLevelDetail([FromRoute] Guid id)
		{
			var experienceLevelDetail = await _mediator.Send(new GetExperienceLevelDetailQuery(id));
			return Ok(experienceLevelDetail);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(ExperienceLevelRoutes.ACTION.CreateExperienceLevel)]
		public async Task<ActionResult> CreateExperienceLevel([FromBody] CreateExperienceLevelCommand createExperienceLevelCommand)
		{
			var response = await _mediator.Send(createExperienceLevelCommand);
			return Ok(response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(ExperienceLevelRoutes.ACTION.UpdateExperienceLevel)]
		public async Task<ActionResult> UpdateExperienceLevel([FromBody] UpdateExperienceLevelCommand updateExperienceLevelCommand)
		{
			var response = await _mediator.Send(updateExperienceLevelCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(ExperienceLevelRoutes.ACTION.DeleteExperienceLevel)]
		public async Task<ActionResult> DeleteExperienceLevel([FromRoute] Guid id)
		{
			var command = new DeleteExperienceLevelCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}

	}
}
