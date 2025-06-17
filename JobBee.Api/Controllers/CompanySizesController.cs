using JobBee.Application.Features.CompanySize.Commands.CreateCompanySize;
using JobBee.Application.Features.CompanySize.Commands.DeleteCompanySize;
using JobBee.Application.Features.CompanySize.Commands.UpdateCompanySize;
using JobBee.Application.Features.CompanySize.Queries.GetAllCompanySize;
using JobBee.Application.Features.CompanySize.Queries.GetCompanySizeDetail;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(CompanySizeRoutes.Index)]
	[ApiController]
	public class CompanySizesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CompanySizesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route(CompanySizeRoutes.ACTION.GetListCompanySize)]
		public async Task<ActionResult> GetListCompanySize()
		{
			var companySizes = await _mediator.Send(new GetAllCompanySizeQuery());
			return Ok(companySizes);
		}

		[HttpGet]
		[Route(CompanySizeRoutes.ACTION.GetCompanySizeDetail)]
		public async Task<ActionResult> GetCompanySizeDetail([FromRoute] Guid id)
		{
			var companySizeDetail = await _mediator.Send(new GetCompanySizeDetailQuery(id));
			return Ok(companySizeDetail);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(CompanySizeRoutes.ACTION.CreateCompanySize)]
		public async Task<ActionResult> CreateCompanySize([FromBody] CreateCompanySizeCommand createCompanySizeCommand)
		{
			var response = await _mediator.Send(createCompanySizeCommand);
			return Ok(response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(CompanySizeRoutes.ACTION.UpdateCompanySize)]
		public async Task<ActionResult> UpdateSkill([FromBody] UpdateCompanySizeCommand updateCompanySizeCommand)
		{
			var response = await _mediator.Send(updateCompanySizeCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(CompanySizeRoutes.ACTION.DeleteCompanySize)]
		public async Task<ActionResult> DeleteCompanySize([FromRoute] Guid id)
		{
			var command = new DeleteCompanySizeCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
