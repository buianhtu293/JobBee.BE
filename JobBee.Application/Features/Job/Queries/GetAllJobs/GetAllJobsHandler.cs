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
			IElasticSearchService<JobDto> elasticSearchService
		)
		: IRequestHandler<GetAllJobsQuery, ApiResponse<PageResult<JobDto>>>
	{
		public async Task<ApiResponse<PageResult<JobDto>>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
		{
			Func<SearchRequestDescriptor<JobDto>, SearchRequestDescriptor<JobDto>> searchConfig =
			s => s
				.Size(request.PageSize)
				.From(request.Page * request.PageSize)
				.Query(q =>
				{
					// Kiểm tra xem có điều kiện nào được áp dụng không
					var hasConditions = false;
					var boolQuery = new Elastic.Clients.Elasticsearch.QueryDsl.BoolQuery();

					// Tạo danh sách các điều kiện must
					var mustClauses = new List<Query>();

					if (!string.IsNullOrWhiteSpace(request.Keyword))
					{
						mustClauses.Add(new Elastic.Clients.Elasticsearch.QueryDsl.MatchQuery
						{
							Field = "title",
							Query = request.Keyword
						});
						hasConditions = true;
					}

					if (!string.IsNullOrWhiteSpace(request.Location))
					{
						mustClauses.Add(new Elastic.Clients.Elasticsearch.QueryDsl.MatchQuery
						{
							Field = "location_city",
							Query = request.Location
						});
						hasConditions = true;
					}

					if (request.Categories != null && request.Categories.Any())
					{
						mustClauses.Add(new Elastic.Clients.Elasticsearch.QueryDsl.TermsQuery
						{
							Field = "job_category",
							Terms = (TermsQueryField)request.Categories.Select(FieldValue.String).ToList()
						});
						hasConditions = true;
					}

					if (request.MinSalary.HasValue)
					{
						mustClauses.Add(new NumberRangeQuery
						{
							Field = "min_salary",
							Gte = (double)request.MinSalary.Value
						});
						hasConditions = true;
					}

					if (request.MaxSalary.HasValue)
					{
						mustClauses.Add(new NumberRangeQuery
						{
							Field = "max_salary",
							Lte = (double)request.MaxSalary.Value
						});
						hasConditions = true;
					}

					if (request.JobTypes != null && request.JobTypes.Any())
					{
						mustClauses.Add(new Elastic.Clients.Elasticsearch.QueryDsl.TermsQuery
						{
							Field = "job_type",
							Terms = (TermsQueryField)request.JobTypes.Select(FieldValue.String).ToList()
						});
						hasConditions = true;
					}

					if (request.EducationLevels != null && request.EducationLevels.Any())
					{
						mustClauses.Add(new Elastic.Clients.Elasticsearch.QueryDsl.TermsQuery
						{
							Field = "min_education_level",
							Terms = (TermsQueryField)request.EducationLevels.Select(FieldValue.String).ToList()
						});
						hasConditions = true;
					}

					if (!string.IsNullOrWhiteSpace(request.Experience))
					{
						mustClauses.Add(new Elastic.Clients.Elasticsearch.QueryDsl.MatchQuery
						{
							Field = "experience_level",
							Query = request.Experience
						});
						hasConditions = true;
					}

					if (!string.IsNullOrWhiteSpace(request.Level))
					{
						mustClauses.Add(new Elastic.Clients.Elasticsearch.QueryDsl.MatchQuery
						{
							Field = "experience_level",
							Query = request.Level
						});
						hasConditions = true;
					}

					// Nếu có điều kiện, sử dụng bool query với must
					if (hasConditions)
					{
						boolQuery.Must = mustClauses;
						q.Bool(b => b = (Elastic.Clients.Elasticsearch.QueryDsl.BoolQueryDescriptor<JobDto>)boolQuery);
					}
					else
					{
						// Nếu không có điều kiện, sử dụng match_all để lấy tất cả tài liệu
						q.MatchAll();
					}

				});

			var list = await elasticSearchService.GetList<string>(searchConfig, null, true, request.Page, request.PageSize);
			var apiResponse = new ApiResponse<PageResult<JobDto>>("Sucess", 200, list);
			return apiResponse;
		}
	}
}
