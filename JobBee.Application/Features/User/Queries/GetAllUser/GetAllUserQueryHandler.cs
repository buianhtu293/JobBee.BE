using AutoMapper;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.ElasticSearchService;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.User.Queries.GetAllUser
{
	public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, ApiResponse<PageResult<UserDto>>>
	{
		private readonly IElasticSearchService<UserDto> _elasticSearchService;

		public GetAllUserQueryHandler(IElasticSearchService<UserDto> elasticSearchService)
		{
			_elasticSearchService = elasticSearchService;
		}

		public async Task<ApiResponse<PageResult<UserDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
		{
			Func<SearchRequestDescriptor<UserDto>, SearchRequestDescriptor<UserDto>> searchConfig = s => s
				.Size(request.PageSize)
				.From(request.Page * request.PageSize)
				.Query(q =>
				{
					var mustClauses = new List<Query>();

					if (!string.IsNullOrWhiteSpace(request.UserName))
						mustClauses.Add(new MatchQuery { Field = "user_name", Query = request.UserName });

					if (!string.IsNullOrWhiteSpace(request.Email))
						mustClauses.Add(new MatchQuery { Field = "email", Query = request.Email });

					if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
						mustClauses.Add(new MatchQuery { Field = "phone_number", Query = request.PhoneNumber });

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
			var apiResponse = new ApiResponse<PageResult<UserDto>>("Success", 200, list);
			return apiResponse;
		}
	}
}
