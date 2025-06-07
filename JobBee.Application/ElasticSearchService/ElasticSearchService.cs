using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Nodes;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Transport;
using JobBee.Domain.Config;
using JobBee.Shared.Paginators;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using SearchRequest = Elastic.Clients.Elasticsearch.SearchRequest;

namespace JobBee.Application.ElasticSearchService
{
	public class ElasticSearchService<TModel> : IElasticSearchService<TModel> where TModel : class
	{

		private readonly ElasticsearchClient _elasticsearchClient;
		private readonly ElasticSearchSettings _elasticsearchSettings;

		public ElasticSearchService(IOptions<ElasticSearchSettings> optionsMonitor)
		{
			_elasticsearchSettings = optionsMonitor.Value;

			var settings = new ElasticsearchClientSettings(new Uri(_elasticsearchSettings.Url))
				.Authentication(new BasicAuthentication(_elasticsearchSettings.Username, _elasticsearchSettings.Password))
				.DefaultIndex(_elasticsearchSettings.DefaultIndex);

			_elasticsearchClient = new ElasticsearchClient(settings);
		}

		public async Task<bool> AddOrUpdate(TModel model)
		{
			var response = await _elasticsearchClient.IndexAsync(model, idx => idx.Index(_elasticsearchSettings.DefaultIndex).OpType(OpType.Index)
			);

			return response.IsValidResponse;
		}

		public async Task<bool> AddOrUpdateBulk(IEnumerable<TModel> models, string indexName)
		{
			var response = await _elasticsearchClient.BulkAsync(
				b => b.Index(_elasticsearchSettings.DefaultIndex)
					.UpdateMany(models, (ud, u) => ud.Doc(u).DocAsUpsert(true))
			);
			return response.IsValidResponse;
		}

		public async Task CreateIndexIfNotExistesAsync(string indexName)
		{
			// check index has been existed
			if (!_elasticsearchClient.Indices.Exists(indexName).Exists)
			{
				await _elasticsearchClient.CreateAsync(indexName);
			}
		}

		public async Task<TModel?> Get(string key, string? index = null)
		{
			var response = await _elasticsearchClient.GetAsync<TModel>(key, g => g.Index(index ?? _elasticsearchSettings.DefaultIndex));

			return response.Source;
		}

		public async Task<PageResult<TModel>> GetList<TProperty>(
			Func<SearchRequestDescriptor<TModel>, SearchRequestDescriptor<TModel>>? searchConfig = null,
			Expression<Func<TModel, TProperty>>? orderBy = null,
			bool? ascending = true,
			int? page = 0,
			int? pageSize = 20,
			string? index = null)
		{
			var searchResponse = await _elasticsearchClient.SearchAsync<TModel>(s =>
			{
				s.Indices(index ?? _elasticsearchSettings.DefaultIndex);

				// Apply custom search configuration
				if (searchConfig != null)
				{
					s = searchConfig(s);
				}

				// Apply sorting
				if (orderBy != null)
				{
					s.Sort(sort =>
					{
						if (orderBy != null)
						{
							var fieldName = GetPropertyName<TProperty>(orderBy);
							sort.Field(fieldName, descriptor => descriptor
								.Order(ascending!.Value ? SortOrder.Asc : SortOrder.Desc)
							);
						}
					});
				}

				// Apply pagination
				if (page.HasValue && pageSize.HasValue)
				{
					int from = page.Value;
					s.From(from).Size(pageSize.Value);
				}
			});

			if (!searchResponse.IsValidResponse)
			{
				throw new Exception("Invalid");
			}

			return new PageResult<TModel>(searchResponse.Documents.ToList(), searchResponse.Total, page!.Value, pageSize!.Value);
		}

		private string GetPropertyName<TProperty>(Expression<Func<TModel, TProperty>> expression)
		{
			if (expression.Body is MemberExpression memberExpression)
			{
				return memberExpression.Member.Name.ToLowerInvariant();
			}
			throw new ArgumentException("Expression must be a member expression");
		}

		public async Task<bool> Remove(string key, string? index = null)
		{
			var response = await _elasticsearchClient.DeleteAsync<TModel>(key,
				d => d.Index(index ?? _elasticsearchSettings.DefaultIndex));

			return response.IsValidResponse;
		}

		public async Task<long?> RemoveAll(string? index = null)
		{
			var response = await _elasticsearchClient.DeleteByQueryAsync<TModel>(d => d.Indices(index ??_elasticsearchSettings.DefaultIndex));

			return response.IsValidResponse ? response.Deleted : default;
		}
	}
}
