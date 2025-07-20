using OpenSearch.Client;
using JobBee.Application.ElasticSearchService;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.Job.Queries.GetAllJobs
{
	public class GetAllJobsHandler : IRequestHandler<GetAllJobsQuery, ApiResponse<PageResult<JobDto>>>
	{
		private readonly IElasticSearchService<JobDto> _elasticSearchService;

		public GetAllJobsHandler(IElasticSearchService<JobDto> elasticSearchService)
		{
			_elasticSearchService = elasticSearchService;
		}

		public async Task<ApiResponse<PageResult<JobDto>>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
		{
			Func<SearchDescriptor<JobDto>, ISearchRequest> searchConfig = s => s
				.Size(request.PageSize)
				.From(request.Page * request.PageSize)
				.Query(q =>
				{
					var mustClauses = new List<QueryContainer>();

					if (!string.IsNullOrWhiteSpace(request.Keyword))
					{
						mustClauses.Add(new MatchQuery
						{
							Field = "title",
							Query = request.Keyword
						});
					}

					if (!string.IsNullOrWhiteSpace(request.Location))
					{
						mustClauses.Add(new MatchQuery
						{
							Field = "location_city",
							Query = request.Location
						});
					}

					if (request.Categories?.Any() == true)
					{
						mustClauses.Add(new TermsQuery
						{
							Field = "job_category.keyword",
							Terms = request.Categories.Cast<object>().ToList()
						});
					}

					if (request.MinSalary.HasValue)
					{
						mustClauses.Add(new NumericRangeQuery
						{
							Field = "min_salary",
							GreaterThanOrEqualTo = (double)request.MinSalary.Value
						});
					}

					if (request.MaxSalary.HasValue)
					{
						mustClauses.Add(new NumericRangeQuery
						{
							Field = "max_salary",
							LessThanOrEqualTo = (double)request.MaxSalary.Value
						});
					}

					if (request.JobTypes?.Any() == true)
					{
						mustClauses.Add(new TermsQuery
						{
							Field = "job_type.keyword",
							Terms = request.JobTypes.Cast<object>().ToList()
						});
					}

					if (request.EducationLevels?.Any() == true)
					{
						mustClauses.Add(new TermsQuery
						{
							Field = "min_education_level.keyword",
							Terms = request.EducationLevels.Cast<object>().ToList()
						});
					}

					if (!string.IsNullOrWhiteSpace(request.Experience))
					{
						mustClauses.Add(new MatchQuery
						{
							Field = "experience_level",
							Query = request.Experience
						});
					}

					if (!string.IsNullOrWhiteSpace(request.Level))
					{
						mustClauses.Add(new MatchQuery
						{
							Field = "experience_level",
							Query = request.Level
						});
					}

					if (request.IsFeatured.HasValue)
					{
						mustClauses.Add(new TermQuery
						{
							Field = "is_featured",
							Value = request.IsFeatured.Value
						});
					}

					if (mustClauses.Any())
					{
						return q.Bool(b => b.Must(mustClauses.ToArray()));
					}
					else
					{
						return q.MatchAll();
					}
				});

			var list = await _elasticSearchService.GetList<string>(searchConfig, null, true, request.Page, request.PageSize);
			return new ApiResponse<PageResult<JobDto>>("Success", 200, list);
		}
	}
}
