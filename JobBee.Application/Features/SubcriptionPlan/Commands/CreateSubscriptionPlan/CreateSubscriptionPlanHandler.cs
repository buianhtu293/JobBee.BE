using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.SubcriptionPlan.Commands.CreateSubscriptionPlan
{
	public class CreateSubscriptionPlanHandler : IRequestHandler<CreateSubscriptionPlanCommand, ApiResponse<CreateSubscriptionPlanDto>>
	{
		private readonly IMapper _mapper;
		private readonly ISubcriptionPlanRepository _subcriptionPlanRepository;
		private readonly IUnitOfWork<Domain.Entities.SubscriptionPlan, Guid> _unitOfWork;

		public CreateSubscriptionPlanHandler(IMapper mapper, 
			ISubcriptionPlanRepository subcriptionPlanRepository, 
			IUnitOfWork<SubscriptionPlan, Guid> unitOfWork)
		{
			_mapper = mapper;
			_subcriptionPlanRepository = subcriptionPlanRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateSubscriptionPlanDto>> Handle(CreateSubscriptionPlanCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateSubscriptionPlanValidator(_subcriptionPlanRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Subcription Plan", validatorResult);
			}

			var subcriptionPlanToCreate = _mapper.Map<Domain.Entities.SubscriptionPlan>(request);
			subcriptionPlanToCreate.Id = Guid.NewGuid();
			subcriptionPlanToCreate.UpdatedAt = DateTime.Now;
			subcriptionPlanToCreate.CreatedAt = DateTime.Now;

			_subcriptionPlanRepository.Insert(subcriptionPlanToCreate);

			var subscriptionPlanCreated = _mapper.Map<CreateSubscriptionPlanDto>(subcriptionPlanToCreate);
			var data = new ApiResponse<CreateSubscriptionPlanDto>("Success", 200, subscriptionPlanCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;

		}
	}
}
