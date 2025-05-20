using JobBee.Application.Features.SkillCategory.Queries.GetAllSkillCategories;
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
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<SkillCategoriesController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<SkillCategoriesController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<SkillCategoriesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
