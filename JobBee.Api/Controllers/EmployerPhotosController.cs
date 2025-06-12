using JobBee.Application.Features.EmployerPhoto;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(EmployerPhotoRoutes.Index)]
	[ApiController]
	public class EmployerPhotosController
		(
			IMediator mediator
		)
	: ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> InsertLogoAndBanner([FromForm] CreateEmployerPhotoCommand command)
		{
			var result = await mediator.Send(command);
			return Ok(result);
		}
	}
}
