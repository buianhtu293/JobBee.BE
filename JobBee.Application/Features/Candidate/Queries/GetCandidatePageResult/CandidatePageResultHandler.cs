using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Features.Candidate.Queries.GetAllCandidate;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.Candidate.Queries.GetCandidatePageResult
{
	public class CandidatePageResultHandler : IRequestHandler<CandidatePageResultQuery, ApiResponse<PageResult<CandidateDto>>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateRepository _candidateRepository;

		public CandidatePageResultHandler(IMapper mapper,
			ICandidateRepository candidateRepository)
		{
			_mapper = mapper;
			_candidateRepository = candidateRepository;
		}

		public async Task<ApiResponse<PageResult<CandidateDto>>> Handle(CandidatePageResultQuery request, CancellationToken cancellationToken)
		{
			// Build filter
			Func<IQueryable<Domain.Entities.Candidate>, IQueryable<Domain.Entities.Candidate>>? filter = null;
			if (!string.IsNullOrWhiteSpace(request.SearchName))
			{
				filter = query => query.Where(c => c.City == request.SearchName);
			}

			// Build sort
			Func<IQueryable<Domain.Entities.Candidate>, IOrderedQueryable<Domain.Entities.Candidate>>? orderBy = null;
			if (request.IsAscCreateAt)
			{
				orderBy = query => query.OrderByDescending(c => c.CreatedAt);
			}

			// Fetch from repository
			var result = await _candidateRepository.GetPaginatedAsyncIncluding(
				request.PageIndex,
				request.PageSize,
				filter,
				orderBy,
				c => c.User
			);

			// Map to DTOs
			var dtoItems = _mapper.Map<List<CandidateDto>>(result.Items);

			// Wrap and return
			var candidateList =  new PageResult<CandidateDto>(
				dtoItems,
				result.TotalItems,
				result.PageIndex,
				result.PageSize
			);

			return new ApiResponse<PageResult<CandidateDto>>("Success", 200, candidateList);

		}
	}
}
