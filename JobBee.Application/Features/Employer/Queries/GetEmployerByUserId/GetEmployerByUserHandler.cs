using AutoMapper.Execution;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.Employer.Queries.GetEmployerDetail;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Employer.Queries.GetEmployerByUserId
{
	public class GetEmployerByUserHandler(
		IUnitOfWork<Domain.Entities.Employer, Guid> unitOfWork
	) : IRequestHandler<GetEmployerByUserIdQuery, ApiResponse<Guid>>
	{
		public async Task<ApiResponse<Guid>> Handle(GetEmployerByUserIdQuery request, CancellationToken cancellationToken)
		{
			var employer = await unitOfWork.GenericRepository.FirstOrDefaultAsync(e => e.UserId == request.Id);
			if (employer == null)
			{
				throw new NotFoundException(nameof(employer), request);
			}
			return new ApiResponse<Guid>("success", 200, employer.Id);
		}
	}
}
