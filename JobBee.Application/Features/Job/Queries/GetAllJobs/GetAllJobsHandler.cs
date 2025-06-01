using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using JobBee.Application.ElasticSearchService;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;
using Nest;

namespace JobBee.Application.Features.Job.Queries.GetAllJobs
{
	public class GetAllJobsHandler (
			IElasticSearchService<GetAllJobsQuery> elasticSearchService
		)
		: IRequestHandler<GetAllJobsQuery, ApiResponse<PageResult<GetAllJobsQuery>>>
	{
		public async Task<ApiResponse<PageResult<GetAllJobsQuery>>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
		{
			Func<SearchRequestDescriptor<GetAllJobsQuery>, SearchRequestDescriptor<GetAllJobsQuery>> searchConfig =
			s => s
				.Size(request.PageSize)
				.From(request.Page * request.PageSize)
				.Query(q => q
					.Bool(b => b
						.Must(must =>
						{
							if (!string.IsNullOrWhiteSpace(request.Keyword))
							{
								must.Match(mt => mt
									.Field(f => f.Keyword)
									.Query(request.Keyword!));
							}

							if (!string.IsNullOrWhiteSpace(request.Location))
							{
								must.Match(mt => mt
									.Field(f => f.Location)
									.Query(request.Location!));
							}

							if (request.Categories != null && request.Categories.Any())
							{
								must.Terms(t => t
									.Field(f => f.Categories)
									.Terms((TermsQueryField)request.Categories.Select(FieldValue.String).ToList())
								);
							}

							if (request.MinSalary.HasValue)
							{
								must.Range(r => r
									.Number(nr => nr
										.Field(f => f.MinSalary)
										.Gte((double)request.MinSalary.Value)));
							}

							if (request.MaxSalary.HasValue)
							{
								must.Range(r => r
									.Number(nr => nr
										.Field(f => f.MaxSalary)
										.Lte((double)request.MaxSalary.Value)));
							}

							if (request.JobTypes != null && request.JobTypes.Any())
							{
								must.Terms(t => t
									.Field(f => f.JobTypes)
									.Terms((TermsQueryField)request.JobTypes.Select(FieldValue.String).ToList()));
							}

							if (request.EducationLevels != null && request.EducationLevels.Any())
							{
								must.Terms(t => t
									.Field(f => f.EducationLevels)
									.Terms((TermsQueryField)request.EducationLevels.Select(FieldValue.String).ToList()));
							}

							if (!string.IsNullOrWhiteSpace(request.Experience))
							{
								must.Match(mt => mt
									.Field(f => f.Experience)
									.Query(request.Experience!));
							}

							if (!string.IsNullOrWhiteSpace(request.Level))
							{
								must.Match(mt => mt
									.Field(f => f.Level)
									.Query(request.Level!));
							}
						})
					)
				);

			var list = await elasticSearchService.GetList<string>(searchConfig, null, true, request.Page, request.PageSize);
			var apiResponse = new ApiResponse<PageResult<GetAllJobsQuery>>("Sucess", 200, list);
			return apiResponse;
		}
	}
}
