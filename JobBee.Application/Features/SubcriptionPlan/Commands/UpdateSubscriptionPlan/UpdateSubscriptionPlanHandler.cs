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

namespace JobBee.Application.Features.SubcriptionPlan.Commands.UpdateSubscriptionPlan
{
	public class UpdateSubscriptionPlanHandler : IRequestHandler<UpdateSubscriptionPlanCommand, ApiResponse<UpdateSubscriptionPlanDto>>
	{
		private readonly IMapper _mapper;
		private readonly ISubcriptionPlanRepository _subcriptionPlanRepository;
		private readonly IUnitOfWork<Domain.Entities.SubscriptionPlan, Guid> _unitOfWork;

		public UpdateSubscriptionPlanHandler(IMapper mapper, 
			ISubcriptionPlanRepository subcriptionPlanRepository, 
			IUnitOfWork<SubscriptionPlan, Guid> unitOfWork)
		{
			_mapper = mapper;
			_subcriptionPlanRepository = subcriptionPlanRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<UpdateSubscriptionPlanDto>> Handle(UpdateSubscriptionPlanCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateSubscriptionPlanValidator(_subcriptionPlanRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Subscription Plan", validatorResult);
			}

			var subscriptionPlan = _subcriptionPlanRepository.GetById(request.Id);

			var subscriptionPlanToUpdate = _mapper.Map<Domain.Entities.SubscriptionPlan>(request);
			subscriptionPlanToUpdate.CreatedAt = subscriptionPlan.CreatedAt;
			subscriptionPlanToUpdate.UpdatedAt = DateTime.Now;

			_subcriptionPlanRepository.Update(subscriptionPlanToUpdate);

			var subscriptionPlanUpdated = _mapper.Map<UpdateSubscriptionPlanDto>(subscriptionPlanToUpdate);
			var data = new ApiResponse<UpdateSubscriptionPlanDto>("Success", 200, subscriptionPlanUpdated);

			await _unitOfWork.SaveChangesAsync();

			return data;

		}
	}
}
