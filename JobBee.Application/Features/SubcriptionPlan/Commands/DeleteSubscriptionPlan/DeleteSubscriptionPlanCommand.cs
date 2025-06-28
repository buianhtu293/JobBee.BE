using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace JobBee.Application.Features.SubcriptionPlan.Commands.DeleteSubscriptionPlan
{
	public class DeleteSubscriptionPlanCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
	}
}
