using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.SubcriptionPlan.Queries.GetSubscriptionPlanDetail
{
	public class GetSubscriptionPlanDetailHandler : IRequestHandler<GetSubscriptonPlanDetailQuery, ApiResponse<SubscriptionPlanDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly ISubcriptionPlanRepository _subcriptionPlanRepository;

		public GetSubscriptionPlanDetailHandler(IMapper mapper, 
			ISubcriptionPlanRepository subcriptionPlanRepository)
		{
			_mapper = mapper;
			_subcriptionPlanRepository = subcriptionPlanRepository;
		}

		public async Task<ApiResponse<SubscriptionPlanDetailDto>> Handle(GetSubscriptonPlanDetailQuery request, CancellationToken cancellationToken)
		{
			var subsciptionPlan = _subcriptionPlanRepository.GetById(request.id);

			if (subsciptionPlan == null)
			{
				throw new NotFoundException(nameof(subsciptionPlan), request.id);
			}

			var subscriptionPlanDetail = _mapper.Map<SubscriptionPlanDetailDto>(subsciptionPlan);
			var data = new ApiResponse<SubscriptionPlanDetailDto>("Success", 200, subscriptionPlanDetail);

			return data;

		}
	}
}
