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
			Func<IQueryable<Domain.Entities.Candidate>, IQueryable<Domain.Entities.Candidate>>? filter = query =>
			{
				if (!string.IsNullOrWhiteSpace(request.SearchName))
				{
					query = query.Where(c =>
						(c.FirstName + " " + c.LastName).Contains(request.SearchName) ||
						c.FirstName.Contains(request.SearchName) ||
						c.LastName.Contains(request.SearchName));
				}

				if (!string.IsNullOrWhiteSpace(request.Gender))
				{
					query = query.Where(c => c.Gender == request.Gender);
				}

				if (!string.IsNullOrWhiteSpace(request.City))
				{
					query = query.Where(c => c.City == request.City);
				}

				if (!string.IsNullOrWhiteSpace(request.State))
				{
					query = query.Where(c => c.State == request.State);
				}

				if (!string.IsNullOrWhiteSpace(request.Country))
				{
					query = query.Where(c => c.Country == request.Country);
				}

				if (request.SalaryExpectation.HasValue)
				{
					query = query.Where(c => c.SalaryExpectation >= request.SalaryExpectation.Value);
				}

				if (request.ExperienceYears.HasValue)
				{
					query = query.Where(c => c.ExperienceYears >= request.ExperienceYears.Value);
				}

				if (request.IsAvailableForHire.HasValue)
				{
					query = query.Where(c => c.IsAvailableForHire == request.IsAvailableForHire.Value);
				}

				return query;
			};


			// Build sort
			Func<IQueryable<Domain.Entities.Candidate>, IOrderedQueryable<Domain.Entities.Candidate>>? orderBy = null;

			if (request.IsAscCreateAt)
			{
				orderBy = query => query.OrderBy(c => c.CreatedAt);
			}
			else
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
