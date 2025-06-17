using JobBee.Application.Features.Industry.Commands.CreateIndustry;
using JobBee.Application.Features.Industry.Commands.DeleteIndustry;
using JobBee.Application.Features.Industry.Commands.UpdateIndustry;
using JobBee.Application.Features.Industry.Queries.GetAllIndustry;
using JobBee.Application.Features.Industry.Queries.GetIndustryDetail;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(IndustryRoutes.Index)]
	[ApiController]
	public class IndustriesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public IndustriesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route(IndustryRoutes.ACTION.GetListIndustry)]
		public async Task<ActionResult> GetListIndustry()
		{
			var industries = await _mediator.Send(new GetAllIndustryQuery());
			return Ok(industries);
		}

		[HttpGet]
		[Route(IndustryRoutes.ACTION.GetIndustryDetail)]
		public async Task<ActionResult> GetIndustryDetail([FromRoute] Guid id)
		{
			var industryDetail = await _mediator.Send(new GetIndustryDetailQuery(id));
			return Ok(industryDetail);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(IndustryRoutes.ACTION.CreateIndustry)]
		public async Task<ActionResult> CreateIndustry([FromBody] CreateIndustryCommand createIndustryCommand)
		{
			var response = await _mediator.Send(createIndustryCommand);
			return Ok(response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(IndustryRoutes.ACTION.UpdateIndustry)]
		public async Task<ActionResult> UpdateIndustry([FromBody] UpdateIndustryCommand updateIndustryCommand)
		{
			var response = await _mediator.Send(updateIndustryCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(IndustryRoutes.ACTION.DeleteIndustry)]
		public async Task<ActionResult> DeleteIndustry([FromRoute] Guid id)
		{
			var command = new DeleteIndustryCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
