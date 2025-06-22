using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.Employer.Queries.GetAllEmployer
{
	public class EmployerPageResultHandler : IRequestHandler<EmployerPageResultQuery, ApiResponse<PageResult<EmployerPageResultDto>>>
	{
		private readonly IMapper _mapper;
		private readonly IEmployerRepository _employerRepository;

		public EmployerPageResultHandler(IMapper mapper, 
			IEmployerRepository employerRepository)
		{
			_mapper = mapper;
			_employerRepository = employerRepository;
		}

		public async Task<ApiResponse<PageResult<EmployerPageResultDto>>> Handle(EmployerPageResultQuery request, CancellationToken cancellationToken)
		{
			Func<IQueryable<Domain.Entities.Employer>, IQueryable<Domain.Entities.Employer>>? filter = null;
			if (!string.IsNullOrEmpty(request.SearchName))
			{
				filter = query => query.Where(c => c.CompanyName.Contains(request.SearchName));
			}

			Func<IQueryable<Domain.Entities.Employer>, IOrderedQueryable<Domain.Entities.Employer>>? orderBy = null;
			//if (request.IsAscCreateAt)
			//{
			//	orderBy = query => query.OrderByDescending(c => c.CreatedAt);
			//}

			var result = await _employerRepository.GetPaginatedAsyncIncluding(
					request.PageIndex,
					request.PageSize,
					filter,
					orderBy,
					u => u.User,
					i => i.Industry,
					c => c.CompanySize
				);

			var dtoItems = _mapper.Map<List<EmployerPageResultDto>>(result.Items);

			var employerList = new PageResult<EmployerPageResultDto>(
					dtoItems,
					result.TotalItems,
					result.PageIndex,
					result.PageSize
				);

			return new ApiResponse<PageResult<EmployerPageResultDto>>("Success", 200, employerList);

		}
	}
}
