using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.SubcriptionPlan.Queries.GetSubscriptionPlanDetail
{
	public record GetSubscriptonPlanDetailQuery(Guid id) : IRequest<ApiResponse<SubscriptionPlanDetailDto>>;
}
