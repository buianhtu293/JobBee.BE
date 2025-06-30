using JobBee.Application.Features.SubcriptionPlan.Commands.CreateSubscriptionPlan;
using JobBee.Application.Features.SubcriptionPlan.Commands.DeleteSubscriptionPlan;
using JobBee.Application.Features.SubcriptionPlan.Commands.UpdateSubscriptionPlan;
using JobBee.Application.Features.SubcriptionPlan.Queries.GetAllSubscriptionPlan;
using JobBee.Application.Features.SubcriptionPlan.Queries.GetSubscriptionPlanDetail;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(SubscriptionPlanRoutes.Index)]
	[ApiController]
	public class SubscriptionPlansController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SubscriptionPlansController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route(SubscriptionPlanRoutes.ACTION.GetListSubscriptionPlan)]
		public async Task<ActionResult> GetListSubscriptionPlan()
		{
			var subscriptionPlans = await _mediator.Send(new GetAllSubscriptionPlanQuery());
			return Ok(subscriptionPlans);
		}

		[HttpGet]
		[Route(SubscriptionPlanRoutes.ACTION.GetSubscriptionPlanDetail)]
		public async Task<ActionResult> GetSubscriptionPlanDetail([FromRoute] Guid id)
		{
			var subscriptionPlanDetail = await _mediator.Send(new GetSubscriptonPlanDetailQuery(id));
			return Ok(subscriptionPlanDetail);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Route(SubscriptionPlanRoutes.ACTION.CreateSubscriptionPlan)]
		public async Task<ActionResult> CreateSubscriptionPlan([FromBody] CreateSubscriptionPlanCommand createSubscriptionPlanCommand)
		{
			var response = await _mediator.Send(createSubscriptionPlanCommand);
			return Ok(response);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(400)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(SubscriptionPlanRoutes.ACTION.UpdateSubscriptionPlan)]
		public async Task<ActionResult> UpdateSubscriptionPlan([FromBody] UpdateSubscriptionPlanCommand updateSubscriptionPlanCommand)
		{
			var response = await _mediator.Send(updateSubscriptionPlanCommand);
			return Ok(response);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		[Route(SubscriptionPlanRoutes.ACTION.DeleteSubscriptionPlan)]
		public async Task<ActionResult> DeleteSubscriptionPlan([FromRoute] Guid id)
		{
			var command = new DeleteSubscriptionPlanCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
