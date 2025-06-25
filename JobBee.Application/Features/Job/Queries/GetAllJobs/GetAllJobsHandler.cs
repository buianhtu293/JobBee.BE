using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
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
			Func<SearchRequestDescriptor<JobDto>, SearchRequestDescriptor<JobDto>> searchConfig = s => s
				.Size(request.PageSize)
				.From(request.Page * request.PageSize)
				.Query(q =>
				{
					var mustClauses = new List<Query>();

					if (!string.IsNullOrWhiteSpace(request.Keyword))
						mustClauses.Add(new MatchQuery { Field = "title", Query = request.Keyword });

					if (!string.IsNullOrWhiteSpace(request.Location))
						mustClauses.Add(new MatchQuery { Field = "location_city", Query = request.Location });

					if (request.Categories?.Any() == true)
						mustClauses.Add(new TermsQuery
						{
							Field = "job_category.keyword",
							Terms = new TermsQueryField(request.Categories.Select(FieldValue.String).ToList())
						});

					if (request.MinSalary.HasValue)
						mustClauses.Add(new NumberRangeQuery
						{
							Field = "min_salary",
							Gte = (Number?)request.MinSalary.Value
						});

					if (request.MaxSalary.HasValue)
						mustClauses.Add(new NumberRangeQuery
						{
							Field = "max_salary",
							Lte = (Number?)request.MaxSalary.Value
						});

					if (request.JobTypes?.Any() == true)
						mustClauses.Add(new TermsQuery
						{
							Field = "job_type.keyword",
							Terms = new TermsQueryField(request.JobTypes.Select(FieldValue.String).ToList())
						});

					if (request.EducationLevels?.Any() == true)
						mustClauses.Add(new TermsQuery
						{
							Field = "min_education_level.keyword",
							Terms = new TermsQueryField(request.EducationLevels.Select(FieldValue.String).ToList())
						});

					if (!string.IsNullOrWhiteSpace(request.Experience))
						mustClauses.Add(new MatchQuery { Field = "experience_level", Query = request.Experience });

					if (!string.IsNullOrWhiteSpace(request.Level))
						mustClauses.Add(new MatchQuery { Field = "experience_level", Query = request.Level });

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
						q.Bool(b => b.Must(mustClauses.ToArray()));
					}
					else
					{
						q.MatchAll();
					}
				});

			var list = await _elasticSearchService.GetList<string>(searchConfig, null, true, request.Page, request.PageSize);
			var apiResponse = new ApiResponse<PageResult<JobDto>>("Success", 200, list);
			return apiResponse;
		}
	}
}