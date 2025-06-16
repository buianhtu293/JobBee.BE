using JobBee.Application.Features.JobCategory.Commands.CreateJobCategory;
using JobBee.Application.Features.JobCategory.Commands.DeleteJobCategory;
using JobBee.Application.Features.JobCategory.Commands.UpdateJobCategory;
using JobBee.Application.Features.JobCategory.Queries.GetAllJobCategory;
using JobBee.Application.Features.JobCategory.Queries.GetJobCategoryDetail;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(JobCategoryRoutes.Index)]
	[ApiController]
	public class JobCategoriesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public JobCategoriesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route(JobCategoryRoutes.ACTION.GetListJobCategory)]
		public async Task<ActionResult> GetListJobCategory()
		{
			var jobCatogories = await _mediator.Send(new GetAllJobCategoryQuery());
			return Ok(jobCatogories);
		}

		[HttpGet]
		[Route(JobCategoryRoutes.ACTION.GetJobCategoryDetail)]
		public async Task<ActionResult> GetJobCategoryDetail([FromRoute] Guid id)
		{
			var jobCategoryDetail = await _mediator.Send(new GetJobCategoryDetailQuery(id));
			return Ok(jobCategoryDetail);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(JobCategoryRoutes.ACTION.CreateJobCategory)]
		public async Task<ActionResult> CreateJobCategory([FromBody] CreateJobCategoryCommand createJobCategoryCommand)
		{
			var response = await _mediator.Send(createJobCategoryCommand);
			return Ok(response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(JobCategoryRoutes.ACTION.UpdateJobCategory)]
		public async Task<ActionResult> UpdateJobCategory([FromBody] UpdateJobCategoryCommand updateJobCategoryCommand)
		{
			var response = await _mediator.Send(updateJobCategoryCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(JobCategoryRoutes.ACTION.DeleteJobCategory)]
		public async Task<ActionResult> DeleteJobCategory([FromRoute] Guid id)
		{
			var command = new DeleteJobCategoryCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}

	}
}
