using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.SubcriptionPlan.Commands.DeleteSubscriptionPlan
{
	public class DeleteSubscriptionPlanHandler : IRequestHandler<DeleteSubscriptionPlanCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ISubcriptionPlanRepository _subcriptionPlanRepository;
		private readonly IUnitOfWork<Domain.Entities.SubscriptionPlan, Guid> _unitOfWork;

		public DeleteSubscriptionPlanHandler(IMapper mapper, 
			ISubcriptionPlanRepository subcriptionPlanRepository, 
			IUnitOfWork<SubscriptionPlan, Guid> unitOfWork)
		{
			_mapper = mapper;
			_subcriptionPlanRepository = subcriptionPlanRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteSubscriptionPlanCommand request, CancellationToken cancellationToken)
		{
			var subscriptionPlanToDelete = _subcriptionPlanRepository.GetById(request.Id);

			if (subscriptionPlanToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.SubscriptionPlan), request.Id);
			}

			_subcriptionPlanRepository.Delete(subscriptionPlanToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;

		}
	}
}
