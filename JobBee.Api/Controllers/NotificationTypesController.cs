using JobBee.Application.Features.NotificationType.Commands.CreateNotificationType;
using JobBee.Application.Features.NotificationType.Commands.DeleteNotificationType;
using JobBee.Application.Features.NotificationType.Commands.UpdateNotificationType;
using JobBee.Application.Features.NotificationType.Queries.GetAllNotificationType;
using JobBee.Application.Features.NotificationType.Queries.GetNotificationTypeDetail;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(NotificationTypeRoutes.Index)]
	[ApiController]
	public class NotificationTypesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public NotificationTypesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route(NotificationTypeRoutes.ACTION.GetListNotificationType)]
		public async Task<ActionResult> GetListNotificationType()
		{
			var notificationTypes = await _mediator.Send(new GetAllNotificationTypeQuery());
			return Ok(notificationTypes);
		}

		[HttpGet]
		[Route(NotificationTypeRoutes.ACTION.GetNotificationTypeDetail)]
		public async Task<ActionResult> GetNotificationTypeDetail([FromRoute] Guid id)
		{
			var notificationTypeDetail = await _mediator.Send(new GetNotificationTypeDetailQuery(id));
			return Ok(notificationTypeDetail);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(NotificationTypeRoutes.ACTION.CreateNotificationType)]
		public async Task<ActionResult> CreateNotificationType([FromBody] CreateNotificationTypeCommand createNotificationTypeCommand)
		{
			var response = await _mediator.Send(createNotificationTypeCommand);
			return Ok(response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(NotificationTypeRoutes.ACTION.UpdateNotificationType)]
		public async Task<ActionResult> UpdateNotificationType([FromBody] UpdateNotificationTypeCommand updateNotificationTypeCommand)
		{
			var response = await _mediator.Send(updateNotificationTypeCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(NotificationTypeRoutes.ACTION.DeleteNotificationType)]
		public async Task<ActionResult> DeleteNotificationType([FromRoute] Guid id)
		{
			var command = new DeleteNotificationTypeCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
