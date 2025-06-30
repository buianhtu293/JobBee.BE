using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.SubcriptionPlan.Queries.GetAllSubscriptionPlan
{
	public class GetAllSubscriptionPlanHandler : IRequestHandler<GetAllSubscriptionPlanQuery, ApiResponse<List<SubscriptionPlanDto>>>
	{
		private readonly IMapper _mapper;
		private readonly ISubcriptionPlanRepository _subcriptionPlanRepository;

		public GetAllSubscriptionPlanHandler(IMapper mapper, 
			ISubcriptionPlanRepository subcriptionPlanRepository)
		{
			_mapper = mapper;
			_subcriptionPlanRepository = subcriptionPlanRepository;
		}

		public async Task<ApiResponse<List<SubscriptionPlanDto>>> Handle(GetAllSubscriptionPlanQuery request, CancellationToken cancellationToken)
		{
			var subscriptionPlans = await _subcriptionPlanRepository.GetAllListAsync();

			var subscriptionPlanList = _mapper.Map<List<SubscriptionPlanDto>>(subscriptionPlans);
			var data = new ApiResponse<List<SubscriptionPlanDto>>("Success", 200, subscriptionPlanList);

			return data;
		}
	}
}
