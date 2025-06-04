using JobBee.Application.Features.SkillCategory.Commands.CreateSkillCategory;
using JobBee.Application.Features.SkillCategory.Commands.DeleteSkillCategory;
using JobBee.Application.Features.SkillCategory.Commands.UpdateSkillCategory;
using JobBee.Application.Features.SkillCategory.Queries.GetAllSkillCategories;
using JobBee.Application.Features.SkillCategory.Queries.GetSkillCategoryDetails;
using JobBee.Application.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobBee.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SkillCategoriesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SkillCategoriesController(IMediator mediator)
        {
			this._mediator = mediator;
		}

        // GET: api/<SkillCategoriesController>
        [HttpGet]
		public async Task<ApiResponse<List<SkillCategoryDto>>> Get()
		{
			var SkillCategories = await _mediator.Send(new GetSkillCategoryQuery());
			return SkillCategories;
		}

		// GET api/<SkillCategoriesController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<ApiResponse<SkillCategoryDetailDto>>> Get(Guid id)
		{
			var skillCategory = await _mediator.Send(new GetSkillCategoryDetailQuery(id));
			return Ok(skillCategory);
		}

		// POST api/<SkillCategoriesController>
		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ApiResponse<SkillCategoryDto>> Post([FromBody] CreateSkillCategoryCommand skillCategory)
		{
			var response = await _mediator.Send(skillCategory);
			return response;
		}

		// PUT api/<SkillCategoriesController>/5
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ApiResponse<SkillCategoryDto>> Put([FromBody] UpdateSkillCategoryCommand updateSkillCategoryCommand)
		{
			var command = await _mediator.Send(updateSkillCategoryCommand);
			return command;
		}

		// DELETE api/<SkillCategoriesController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(Guid id)
		{
			var command = new DeleteSkillcategoryCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
