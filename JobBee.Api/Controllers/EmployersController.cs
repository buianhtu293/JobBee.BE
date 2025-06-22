using JobBee.Application.Features.Employer.Commands.CreateEmployer;
using JobBee.Application.Features.Employer.Queries.GetAllEmployer;
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

	}
}
