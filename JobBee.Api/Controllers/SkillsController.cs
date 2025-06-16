using JobBee.Application.Features.Skill.Commands.AddSkill;
using JobBee.Application.Features.Skill.Commands.DeleteSkill;
using JobBee.Application.Features.Skill.Commands.UpdateSkill;
using JobBee.Application.Features.Skill.Queries.GetAllSkill;
using JobBee.Application.Features.Skill.Queries.GetSkillById;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(SkillRoutes.Index)]
	[ApiController]
	public class SkillsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SkillsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route(SkillRoutes.ACTION.GetListSkill)]
		public async Task<ActionResult> GetListSkill()
		{
			var skills = await _mediator.Send(new GetAllSkillQuery());
			return Ok(skills);
		}

		[HttpGet]
		[Route(SkillRoutes.ACTION.GetSkillDetail)]
		public async Task<ActionResult> GetSkillDetail([FromRoute] Guid id)
		{
			var skillDetail = await _mediator.Send(new GetSkillDetailQuery(id));
			return Ok(skillDetail);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(SkillRoutes.ACTION.CreateSkill)]
		public async Task<ActionResult> CreateSkill([FromBody] CreateSkillCommand createSkillCommand)
		{
			var response = await _mediator.Send(createSkillCommand);
			return Ok(response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(SkillRoutes.ACTION.UpdateSkill)]
		public async Task<ActionResult> UpdateSkill([FromBody] UpdateSkillCommand updateSkillCommand)
		{
			var response = await _mediator.Send(updateSkillCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(SkillRoutes.ACTION.DeleteSkill)]
		public async Task<ActionResult> DeleteSkill([FromRoute] Guid id)
		{
			var command = new DeleteSkillCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
