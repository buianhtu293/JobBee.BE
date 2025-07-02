using JobBee.Application.Features.Company.Queries.GetTopCompany;
using JobBee.Application.Features.Employer.Commands.CreateEmployer;
using JobBee.Application.Features.Employer.Queries.GetAllEmployer;
using JobBee.Application.Features.Employer.Queries.GetEmployerByUserId;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(EmployerRoutes.Index)]
	[ApiController]
	public class EmployersController(
		IMediator mediator
	) : ControllerBase
	{
		[HttpPost(EmployerRoutes.ACTION.Create)]
		public async Task<IActionResult> Create([FromBody] CreateEmployerCommand command)
		{
			var result = await mediator.Send(command);
			return Ok(result);
		}

		[HttpGet]
		[Route(EmployerRoutes.ACTION.GetListPageResult)]
		public async Task<ActionResult> GetListPageResult([FromQuery] EmployerPageResultQuery query)
		{
			var employers = await mediator.Send(query);
			return Ok(employers);
		}

		[HttpGet(EmployerRoutes.ACTION.GetTopEmployer)]
		public async Task<IActionResult> GetTopEmployer([FromQuery] TopCompanyQuery query)
		{
			var result = await mediator.Send(query);
			return Ok(result);
		}

		[HttpGet(EmployerRoutes.ACTION.GetEmployerByUserId)]
		public async Task<IActionResult> GetEmployerByUserId([FromRoute] Guid id)
		{
			var result = await mediator.Send(new GetEmployerByUserIdQuery { Id = id});
			return Ok(result);
		}
	}
}
