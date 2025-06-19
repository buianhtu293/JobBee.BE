using JobBee.Application.Features.Notification.Commands.CreateNotification;
using JobBee.Application.Features.Notification.Commands.DeleteNotification;
using JobBee.Application.Features.Notification.Queries.GetNotificationByUser;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(NotificationRoutes.Index)]
	[ApiController]
	public class NotificationsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public NotificationsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route(NotificationRoutes.ACTION.GetListNotification)]
		public async Task<ActionResult> GetListNotification([FromQuery] GetNotificationByUserQuery query)
		{
			var notifications = await _mediator.Send(query);
			return Ok(notifications);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(NotificationRoutes.ACTION.CreateNotification)]
		public async Task<ActionResult> CreateNotification([FromBody] CreateNotificationCommand createNotificationCommand)
		{
			var response = await _mediator.Send(createNotificationCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(NotificationRoutes.ACTION.DeleteNotification)]
		public async Task<ActionResult> DeleteNotification([FromRoute] Guid id)
		{
			var command = new DeleteNotificationCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
