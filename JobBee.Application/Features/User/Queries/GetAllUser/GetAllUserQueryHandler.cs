using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using JobBee.Application.ElasticSearchService;
using JobBee.Application.Features.User.Queries.GetAllUser;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using JobBee.Shared.Paginators;
using MediatR;
using OpenSearch.Client;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, ApiResponse<PageResult<UserDto>>>
{
	private readonly IElasticSearchService<UserDto> _elasticSearchService;

	public GetAllUserQueryHandler(IElasticSearchService<UserDto> elasticSearchService)
	{
		_elasticSearchService = elasticSearchService;
	}

	public async Task<ApiResponse<PageResult<UserDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
	{
		Func<SearchDescriptor<UserDto>, ISearchRequest> searchConfig = s => s
			.Query(q => q.Bool(b =>
			{
				var mustQueries = new List<Func<QueryContainerDescriptor<UserDto>, QueryContainer>>();

				if (!string.IsNullOrWhiteSpace(request.UserName))
				{
					mustQueries.Add(m => m.Match(ma => ma
						.Field(f => f.UserName)
						.Query(request.UserName)
					));
				}

				if (!string.IsNullOrWhiteSpace(request.Email))
				{
					mustQueries.Add(m => m.Match(ma => ma
						.Field(f => f.Email)
						.Query(request.Email)
					));
				}

				if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
				{
					mustQueries.Add(m => m.Match(ma => ma
						.Field(f => f.PhoneNumber)
						.Query(request.PhoneNumber)
					));
				}

				if (mustQueries.Count > 0)
				{
					b.Must(mustQueries.ToArray());
				}
				else
				{
					b.Must(m => m.MatchAll());
				}

				return b;
			}));

		var list = await _elasticSearchService.GetList<string>(searchConfig, null, true, request.Page, request.PageSize);

		return new ApiResponse<PageResult<UserDto>>("Success", 200, list);
	}
}
